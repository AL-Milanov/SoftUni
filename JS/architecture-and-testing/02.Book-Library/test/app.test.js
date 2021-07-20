const { assert } = require('chai');
const { chromium } = require('playwright-chromium');

const fakeDB = '**/jsonstore/collections/books';
const baseUrl = 'http://127.0.0.1:5500/02.Book-Library/index.html';

let expectedAlertMessage = 'All fields are required!';


function fakeResponse(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    }
}

let testBooks = {
    1: {
        author: 'Mario Puzo',
        title: 'The Godfather'
    },
    2: {
        author: 'Douglas Adams',
        title: 'Hitchhiker\'s Guide to the Galaxy'
    }
};

let browser, page;

describe('Test Book-Library functionality', function () {

    before(async () => { browser = await chromium.launch({ headless: false, slowMo: 950 }); });

    after(async () => { await browser.close(); });

    beforeEach(async () => { page = await browser.newPage(); });

    afterEach(async () => { await page.close(); });


    describe('Load button should load all titles in tableElement', () => {

        it('When load books button is click should show all books', async () => {

            await page.route(fakeDB, rotue => rotue.fulfill(fakeResponse(testBooks)));

            await page.goto(baseUrl);
            await page.click('#loadBooks');

            await page.waitForSelector('tbody');

            let expected = `
<td>The Godfather</td>
<td>Mario Puzo</td>
<td>
<button class="editBtn">Edit</button>
<button class="deleteBtn">Delete</button>
</td>


<td>Hitchhiker's Guide to the Galaxy</td>
<td>Douglas Adams</td>
<td>
<button class="editBtn">Edit</button>
<button class="deleteBtn">Delete</button>
`;

            let actual = await page.$eval('tbody', t => {
                let result = [];
                for (const iterator of t.children) {
                    result.push(iterator.innerHTML);
                };
                return result.join('\n').split('    ', 40).join('');
            });

            assert.equal(actual, expected);
        });

        it('Submit title with correct data create Post request', async () => {
            let requestData = undefined
            let newTitle = {
                title: 'Cats of Ulthar',
                author: 'H.P.Lovecraft'
            }

            await page.route(fakeDB, (rotue, request) => {
                if (request.method() == 'POST') {
                    requestData = request.postData();
                    rotue.fulfill(fakeResponse(newTitle));
                }
            });

            await page.goto(baseUrl);

            await page.fill('input[name="title"]', 'Cats of Ulthar');
            await page.fill('input[name="author"]', 'H.P.Lovecraft');

            await page.click(':is(button:has-text("Submit"))');

            let actual = JSON.parse(requestData);

            let titleAfterRequest = await page.$eval('input[name="title"]', (textArea) => textArea.value);
            let authorAfterRequest = await page.$eval('input[name="author"]', (textArea) => textArea.value);

            assert.deepEqual(actual, newTitle);
            assert.equal(titleAfterRequest, '');
            assert.equal(authorAfterRequest, '');
        });

        it('Submit title with uncorrect data alert', async () => {

            await page.goto(baseUrl);

            await page.fill('input[name="author"]', 'H.P.Lovecraft');

            let actualAlertMessage = undefined;
            page.on('dialog', alert => {
                actualAlertMessage = alert.message();
                alert.accept()
            });

            await page.click(':is(button:has-text("Submit"))');

            assert.equal(actualAlertMessage, expectedAlertMessage);

            await page.fill('input[name="title"]', 'Cats of Ulthar');
            await page.fill('input[name="author"]', '');

            actualAlertMessage = undefined;
            page.on('dialog', alert => {
                actualAlertMessage = alert.message();
                alert.accept()
            });

            await page.click(':is(button:has-text("Submit"))');

            assert.equal(actualAlertMessage, expectedAlertMessage);
        });

        it('Should make delete request when clicked delete button', async () => {

            await page.goto(baseUrl);

            await page.route(fakeDB, rotue => rotue.fulfill(fakeResponse(testBooks)));

            await page.click('#loadBooks');

            await page.waitForSelector('#all-books');

            page.on('dialog', dialog => dialog.accept());

            const [request] = await Promise.all([
                page.waitForRequest(fakeDB + '/1'),
                page.click('#all-books [data-id="1"] .deleteBtn')
            ]);

            assert.equal(request.method(), 'DELETE');

        });

        it('Should alert when field is not filled', async () => {

            await page.goto(baseUrl);

            await page.route(fakeDB, rotue => rotue.fulfill(fakeResponse(testBooks)));

            await page.click('#loadBooks');

            await page.waitForSelector('#all-books');
            await page.click('#all-books [data-id="1"] .editBtn');

            page.on('dialog', dialog => dialog.accept());

            await page.fill('#editForm input[name="title"]', 'Cats of Ulthar');
            await page.fill('#editForm input[name="author"]', '');

            actualAlertMessage = undefined;
            page.on('dialog', alert => {
                actualAlertMessage = alert.message();
                alert.accept()
            });

            await page.click('#editForm button');

            assert.equal(actualAlertMessage, expectedAlertMessage);

        });
    });
});
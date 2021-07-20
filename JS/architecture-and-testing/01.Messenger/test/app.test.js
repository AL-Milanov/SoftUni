const { assert } = require('chai');
const { chromium } = require('playwright-chromium');

const fakeDB = '**/jsonstore/messenger';
const baseUrl = 'http://127.0.0.1:5500/01.Messenger/index.html';

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

let testMessages = {
  1: {
    author: 'Ani',
    content: 'Hello World!'
  },
  2: {
    author: 'World',
    content: 'Hello Ani!'
  }
}

let browser = undefined;
let page = undefined; // Declare reusable variables

describe('E2E tests', function () {

  before(async () => { browser = await chromium.launch({ headless: false, slowMo: 50 }); });

  after(async () => { await browser.close(); });

  beforeEach(async () => { page = await browser.newPage(); });

  afterEach(async () => { await page.close(); });

  describe('Test Messenger functionality', async () => {
    it('Send GET request to server and shows result', async () => {

      await page.route(fakeDB, rotue => rotue.fulfill(fakeResponse(testMessages)));
      
      await page.goto(baseUrl);
      await page.click('#refresh');

      let expected = Object.values(testMessages).map(m => `${m.author}: ${m.content}`).join('\n');
      let actual = await page.$eval('#messages', (textArea) => textArea.value);;

      assert.equal(actual, expected);
    });

    it('Send POST request to server', async () => {
      let requestData = undefined;

      let newMessage = {
        author: 'Alex',
        content: 'Hello All!'
      }

      await page.route(fakeDB, (rotue, request) => {
        if (request.method() == 'POST') {
          requestData = request.postData();
          rotue.fulfill(fakeResponse(newMessage));
        }
      });

      await page.goto(baseUrl);

      await page.fill('#author', 'Alex');
      await page.fill('#content', 'Hello All!');

      await page.click('#submit');

      let actual = JSON.parse(requestData);

      assert.deepEqual(actual, newMessage);
    });
  });
});
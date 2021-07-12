const catchesBaseUrl = 'http://localhost:3030/data/catches';

let catchesDivElement = document.querySelector('#catches');
clearCatches();

let loginBtn = document.querySelector('#loginBtn');
let logoutBtn = document.querySelector('#logoutBtn');
loginLogoutHandler();

function loginLogoutHandler() {

    if (localStorage.token != null) {
        loginBtn.classList.add('hidden');
        logoutBtn.classList.remove('hidden');
    } else {
        loginBtn.classList.remove('hidden');
        logoutBtn.classList.add('hidden');
    }
}

logoutBtn.addEventListener('click', () => {
    fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {
            'X-Authorization': `${localStorage.token}`
        }
    })
        .then(response => {
            localStorage.clear();
            location.reload()
        })
        .catch(err => console.log(err));
})


let loadBtnElement = document.querySelector('.load');
loadBtnElement.addEventListener('click', loadBtnHandler)



let addBtnElement = document.querySelector('#addBtn');
addBtnElement.disabled = localStorage.getItem('token') === null;
addBtnElement.addEventListener('click', addBtnHandler)

function loadHtmlElements(data) {

    let anglerLable = ce('label', undefined, 'Angler');
    let anglerInput = ce('input', { type: 'text', class: 'angler' }, data.angler);

    let hr1 = ce('hr');

    let weightLabel = ce('label', undefined, 'Weight');
    let weightInput = ce('input', { type: 'number', class: 'weight' }, data.weight);

    let hr2 = ce('hr');

    let speciesLable = ce('label', undefined, 'Species');
    let speciesInput = ce('input', { type: 'text', class: 'species' }, data.species);

    let hr3 = ce('hr');

    let locationLable = ce('label', undefined, 'Location');
    let locationInput = ce('input', { type: 'text', class: 'location' }, data.location);

    let hr4 = ce('hr');

    let baitLable = ce('label', undefined, 'Bait');
    let baitInput = ce('input', { type: 'text', class: 'bait' }, data.bait);

    let hr5 = ce('hr');

    let captureTimeLabel = ce('label', undefined, 'Capture Time');
    let captureTimeInput = ce('input', { type: 'number', class: 'captureTime' }, data.captureTime);

    let hr6 = ce('hr');

    let updateBtn = ce('button', { class: 'update' }, 'Update');
    updateBtn.disabled = localStorage.getItem('userId') !== data._ownerId;
    updateBtn.addEventListener('click', updateBtnHandler);

    let deleteBtn = ce('button', { class: 'delete' }, 'Delete');
    deleteBtn.disabled = localStorage.getItem('userId') !== data._ownerId;
    deleteBtn.addEventListener('click', deleteBtnHandler);

    let catchDiv = ce('div', { class: 'catch' },
        anglerLable, anglerInput,
        hr1, weightLabel, weightInput,
        hr2, speciesLable, speciesInput,
        hr3, locationLable, locationInput,
        hr4, baitLable, baitInput,
        hr5, captureTimeLabel, captureTimeInput,
        hr6, updateBtn, deleteBtn,
    );
    catchDiv.dataset.id = data._id;
    catchDiv.dataset.ownerId = data._ownerId;

    catchesDivElement.appendChild(catchDiv);

}

function deleteBtnHandler(e) {
    let curCatch = e.target.closest('.catch');

    fetch(`${catchesBaseUrl}/${curCatch.dataset.id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': localStorage.getItem('token')
        }
    })
        .then(response => response.json())
        .then(result => curCatch.remove())
        .catch(err => console.log(err));
}

function updateBtnHandler(e) {

    let curCatch = e.target.closest('.catch');

    let angler = curCatch.querySelector('.angler').value;
    let weight = Number(curCatch.querySelector('.weight').value);
    let species = curCatch.querySelector('.species').value;
    let location = curCatch.querySelector('.location').value;
    let bait = curCatch.querySelector('.bait').value;
    let captureTime = Number(curCatch.querySelector('.captureTime').value);

    let newCatch = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    };


    fetch(`${catchesBaseUrl}/${curCatch.dataset.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify(newCatch)
    })
        .then(response => response.json())
        .then(data => loadBtnHandler())
        .catch(err => console.log(err));
}

function addBtnHandler() {
    let addFormElement = document.querySelector('#addForm');

    let angler = addFormElement.querySelector('.angler').value;
    let weight = Number(addFormElement.querySelector('.weight').value);
    let species = addFormElement.querySelector('.species').value;
    let location = addFormElement.querySelector('.location').value;
    let bait = addFormElement.querySelector('.bait').value;
    let captureTime = Number(addFormElement.querySelector('.captureTime').value);

    let newCatch = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime,
    };

    fetch(catchesBaseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify(newCatch)
    })
        .then(response => response.json())
        .then(data => loadHtmlElements(data))
        .catch(err => console.log(err));

    addFormElement.querySelector('.angler').value = '';
    addFormElement.querySelector('.weight').value = '';
    addFormElement.querySelector('.species').value = '';
    addFormElement.querySelector('.location').value = '';
    addFormElement.querySelector('.bait').value = '';
    addFormElement.querySelector('.captureTime').value = '';
}

function loadBtnHandler() {
    clearCatches();

    fetch(catchesBaseUrl)
        .then(response => response.json())
        .then(anglers => {

            Object.values(anglers).forEach(data => {
                loadHtmlElements(data)
            });

        })
        .catch(err => console.log(err));
}

function clearCatches() {
    catchesDivElement.querySelectorAll('.catch').forEach(div => div.remove());
}

function ce(tag, attributes, ...params) {
    let element = document.createElement(tag);
    let firstValue = params[0];
    if (params.length === 1 && typeof (firstValue) !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key]);
        })
    }

    return element;
}
const baseUrl = 'http://localhost:3030/jsonstore/collections/students';
let formElement = document.getElementById('form');
let resultsTableElement = document.querySelector('#results tbody');


formElement.addEventListener('submit', (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let grade = Number(formData.get('grade'));

    let isAnyValueEmptyString = firstName != '' &&
        lastName != '' &&
        facultyNumber != '' &&
        grade != '';

    if (!isAnyValueEmptyString) {
        return;
    }

    let studentObj = {
        firstName,
        lastName,
        facultyNumber,
        grade,
    }

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(studentObj)
    })
        .catch(error => console.log(error));

    reloadList();
    formElement.reset();
})


function reloadList() {

    while (resultsTableElement.lastChild) {
        resultsTableElement.lastChild.remove();
    }

    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            Object.values(data).forEach(student => {
                let tr = document.createElement('tr');

                let firstNameTh = document.createElement('td');
                firstNameTh.textContent = student.firstName;

                let lastNameTh = document.createElement('td');
                lastNameTh.textContent = student.lastName;

                let facultyNumberTh = document.createElement('td');
                facultyNumberTh.textContent = student.facultyNumber;

                let gradeTh = document.createElement('td');
                gradeTh.textContent = student.grade.toFixed(2);

                tr.appendChild(firstNameTh);
                tr.appendChild(lastNameTh);
                tr.appendChild(facultyNumberTh);
                tr.appendChild(gradeTh);

                resultsTableElement.appendChild(tr);
            })
        })
}

reloadList();
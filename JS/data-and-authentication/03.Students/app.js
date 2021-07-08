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

                let firstNameTd = document.createElement('td');
                firstNameTd.textContent = student.firstName;

                let lastNameTd = document.createElement('td');
                lastNameTd.textContent = student.lastName;

                let facultyNumberTd = document.createElement('td');
                facultyNumberTd.textContent = student.facultyNumber;

                let gradeTd = document.createElement('td');
                gradeTd.textContent = student.grade.toFixed(2);

                tr.appendChild(firstNameTd);
                tr.appendChild(lastNameTd);
                tr.appendChild(facultyNumberTd);
                tr.appendChild(gradeTd);

                resultsTableElement.appendChild(tr);
            })
        })
}

reloadList();
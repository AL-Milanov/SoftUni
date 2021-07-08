function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';

    let loadBtnElement = document.getElementById('btnLoad');
    let createBtnElement = document.getElementById('btnCreate');

    loadBtnElement.addEventListener('click', () => {
        let phonebookUlElement = document.getElementById('phonebook');

        while (phonebookUlElement.lastChild) {
            phonebookUlElement.lastChild.remove()
        }

        fetch(baseUrl)
            .then(response => response.json())
            .then(data => {
                Object.values(data).forEach(el => {
                    let liElement = document.createElement('li');
                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';
                    
                    liElement.textContent = `${el.person}: ${el.phone}`;
                    liElement.id = el.person;
                    liElement.appendChild(deleteBtn);

                    deleteBtn.addEventListener('click', () => {
                        let personId = el._id;
                        fetch(`${baseUrl}/${personId}`, {
                            method: 'DELETE',
                            headers: {
                                'Content-type': 'application/json'
                            },
                        })
                        .catch(error => console.error(error));
                        
                        document.getElementById(el.person).remove();
                    })
                    

                    phonebookUlElement.appendChild(liElement);
                })
            });


    });

    createBtnElement.addEventListener('click', () => {

        let personInputElement = document.getElementById('person');
        let phoneInputElement = document.getElementById('phone');

        let phoneNumberObject = {
            'person': personInputElement.value,
            'phone': phoneInputElement.value,
        };

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(phoneNumberObject)
        })
            .catch(error => console.error(error));

        personInputElement.value = '';
        phoneInputElement.value = '';
    })
}

attachEvents();
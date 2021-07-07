function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/messenger';

    let sendBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    sendBtn.addEventListener('click', () => {
        let authorElements = document.getElementsByName('author');
        let contentElements = document.getElementsByName('content');

        let authorName = authorElements[0].value;
        let msgText = contentElements[0].value;

        let messangerObj = {
            author: authorName,
            content: msgText,
        };

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(messangerObj)
        })
            .catch(error => console.error(error));

        authorElements[0].value = '';
        contentElements[0].value = '';
    })

    refreshBtn.addEventListener('click', () => {

        let msgBox = document.getElementById('messages');

        fetch(baseUrl)
            .then(response => response.json())
            .then(data => {
                Object.values(data).forEach(el => msgBox.textContent += `${el.author}: ${el.content}\n`);
            })
            .catch(error => console.error(error))
    })
}

attachEvents();
function solve() {
    let taskElement = document.getElementById('task');
    let descriptionElement = document.getElementById('description');
    let dateElement = document.getElementById('date');
    let addBtn = document.getElementById('add');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        let taskValue = taskElement.value;
        let descriptionValue = descriptionElement.value;
        let dateValue = dateElement.value;

        if (taskValue === '' || descriptionValue === '' || dateValue === '') {
            return;
        }

        let openSection = document.querySelector('section:nth-child(2) div:nth-child(2)');

        let article = document.createElement('article');
        let h3 = document.createElement('h3');
        h3.textContent = taskValue;

        let p1 = document.createElement('p');
        p1.textContent = 'Description: ' + descriptionValue;

        let p2 = document.createElement('p');
        p2.textContent = 'Due Date: ' + dateValue;

        let div = document.createElement('div');
        div.classList.add('flex');

        let startBtn = document.createElement('button');
        startBtn.textContent = 'Start';
        startBtn.classList.add('green');
        startBtn.addEventListener('click', (e) => {
            let movePart = e.target.parentElement.parentElement;
            e.target.remove();

            let inProgressSection = document.getElementById('in-progress');
            let finishBtn = document.createElement('button');
            finishBtn.textContent = 'Finish';
            finishBtn.classList.add('orange');
            finishBtn.addEventListener('click', (e) => {
                e.target.parentElement.remove();
                
                let completedSection = document.querySelector('section:nth-child(4) div:nth-child(2)');
                completedSection.appendChild(article);
            })

            div.appendChild(finishBtn);
            inProgressSection.appendChild(movePart);
        });

        let deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.classList.add('red');
        deleteBtn.addEventListener('click', (e) => {
            e.target.parentElement.parentElement.remove();
        });

        div.appendChild(startBtn);
        div.appendChild(deleteBtn);

        article.appendChild(h3);
        article.appendChild(p1);
        article.appendChild(p2);
        article.appendChild(div);

        openSection.appendChild(article);

        taskElement.textContent = '';
        descriptionElement.textContent = '';
        dateElement.textContent = '';
    });
}
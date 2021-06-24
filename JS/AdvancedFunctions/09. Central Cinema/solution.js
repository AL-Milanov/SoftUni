function solve() {
    
    document.querySelector('#container button').addEventListener('click', e => {
        e.preventDefault();

        let containerElement = Array.from(document.querySelectorAll('#container input'));

        if (!(containerElement.some(e => e.value === '')) && !isNaN(containerElement[2].value)) {
            let moviesUlElement = document.querySelector('#movies ul');

            let movieLi = document.createElement('li');

            let span = document.createElement('span');
            span.textContent = containerElement[0].value;
            movieLi.appendChild(span);

            let hallStrong = document.createElement('strong');
            hallStrong.textContent = `Hall: ${containerElement[1].value}`;
            movieLi.appendChild(hallStrong);

            let div = document.createElement('div');

            let priceStrong = document.createElement('strong');
            priceStrong.textContent = Number(containerElement[2].value).toFixed(2);
            div.appendChild(priceStrong);

            let ticketsSoldInput = document.createElement('input');
            ticketsSoldInput.placeholder = 'Tickets Sold';
            div.appendChild(ticketsSoldInput);

            let archiveBtn = document.createElement('button');
            archiveBtn.textContent = 'Archive';
            div.appendChild(archiveBtn);

            movieLi.appendChild(div);
            moviesUlElement.appendChild(movieLi);

            archiveBtn.addEventListener('click', () => {
                
                if (Number(ticketsSoldInput.value)) {
                    let ticketsSold = Number(ticketsSoldInput.value);

                    let archiveElement = document.querySelector('#archive ul');
                    let archiveLi = document.createElement('li');

                    let archiveSpan = document.createElement('span');
                    archiveSpan.textContent = span.textContent;

                    let archiveStrong = document.createElement('strong');
                    archiveStrong.textContent = `Total amount: ${(priceStrong.textContent * ticketsSold).toFixed(2)}`;

                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';

                    archiveLi.appendChild(archiveSpan);
                    archiveLi.appendChild(archiveStrong);
                    archiveLi.appendChild(deleteBtn);

                    archiveElement.appendChild(archiveLi);

                    deleteBtn.addEventListener('click', () => {
                        archiveLi.remove();
                    });

                    movieLi.remove();
                };
                ticketsSoldInput.value = '';
            })
        }

        containerElement.forEach(e => e.value = '');
    });

    document.querySelector('#archive button').addEventListener('click', () => {
        let liElements = Array.from(document.querySelectorAll('#archive li'));
        if (liElements.length > 0) {
            
            liElements.forEach(el => el.remove());
        }
    });
}
function solution() {
    let addBtn = document.querySelector('.card div button');

    addBtn.addEventListener('click', () => {
        let giftName = document.querySelector('.card input[type="text"]');

        let listOfGiftsElements = document.querySelectorAll('.card ul');

        let li = document.createElement('li');
        li.classList.add('gift');
        li.textContent = giftName.value;

        let sendBtn = document.createElement('button');
        sendBtn.id = 'sendButton';
        sendBtn.textContent = 'Send';
        
        sendBtn.addEventListener('click', (e) => {
            e.target.remove();
            discardBtn.remove();
            listOfGiftsElements[1].appendChild(li);
        });
        
        let discardBtn = document.createElement('button');
        discardBtn.id = 'discardButton';
        discardBtn.textContent = 'Discard';

        discardBtn.addEventListener('click', (e) => {
            e.target.remove();
            sendBtn.remove();
            listOfGiftsElements[2].appendChild(li);
        });
        
        li.appendChild(sendBtn);
        li.appendChild(discardBtn);
        listOfGiftsElements[0].appendChild(li);


        let liCollection = Array.from(listOfGiftsElements[0].querySelectorAll('li'));
        let sortedLiCollection = liCollection.sort((a, b) => a.innerText.localeCompare(b.innerText));

        while (listOfGiftsElements[0].firstChild) {
            listOfGiftsElements[0].firstChild.remove();
        }
 
        for (const element of sortedLiCollection) {
            listOfGiftsElements[0].appendChild(element);
        }

        giftName.value = '';
    });

}
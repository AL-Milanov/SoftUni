function addItem() {
    let menuElement = document.getElementById('menu');
    let newTextElement = document.getElementById('newItemText');
    let newValueElement = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.textContent = newTextElement.value;
    option.value = newValueElement.value;
    console.log(newTextElement.textContent);
    menuElement.appendChild(option);

    newTextElement.value = '';
    newValueElement.value = '';
}
function solve() {
  let buttonsElements = Array.from(document.querySelectorAll('#exercise button'));
  let textareaElement = document.querySelectorAll('#exercise textarea');

  buttonsElements[0].addEventListener('click', () => {
    let item = JSON.parse(textareaElement[0].value);

    item.forEach(e => {

      let tableBodyElement = document.querySelector('.table tbody');

      let trElement = document.createElement('tr');

      let tdImage = document.createElement('td');
      let img = document.createElement('img');
      img.src = e.img;
      tdImage.appendChild(img);
      trElement.appendChild(tdImage);

      let tdName = document.createElement('td');
      let pName = document.createElement('p');
      pName.textContent = e.name;
      tdName.appendChild(pName);
      trElement.appendChild(tdName);

      let tdPrice = document.createElement('td');
      let pPrice = document.createElement('p');
      pPrice.textContent = e.price;
      tdPrice.appendChild(pPrice);
      trElement.appendChild(tdPrice);

      let tdDecFactor = document.createElement('td');
      let pDecFactor = document.createElement('p');
      pDecFactor.textContent = e.decFactor;
      tdDecFactor.appendChild(pDecFactor);
      trElement.appendChild(tdDecFactor);

      let tdMark = document.createElement('td');
      let inputCheckbox = document.createElement('input');
      inputCheckbox.type = 'checkbox';
      tdMark.appendChild(inputCheckbox);
      trElement.appendChild(tdMark);

      tableBodyElement.appendChild(trElement);
    })
  });

  buttonsElements[1].addEventListener('click', () => {
    let tableElements = Array.from(document.querySelectorAll('.table tr')).slice(1);
    let names = [];
    let prices = [];
    let decFactor = [];

    console.log(tableElements);
    tableElements.forEach(e => {
      if (e.children[4].children[0].checked) {
        names.push(e.children[1].children[0].textContent);
        prices.push(e.children[2].children[0].textContent);
        decFactor.push(e.children[3].children[0].textContent);
      }
    });

    prices = prices.map(e => Number(e));
    let totalPrice = prices.reduce((acc, e) => {
      acc += e;
      return acc;
    }, 0);

    decFactor = decFactor.map(e => e = Number(e));
    let averageDecFactor = decFactor.reduce((acc, e) => {
      acc += e;
      return acc;
    }, 0) / decFactor.length;

    textareaElement[1].textContent = `Bought furniture: ${names.join(', ')}
Total price: ${totalPrice.toFixed(2)}
Average decoration factor: ${averageDecFactor}`
  });

}

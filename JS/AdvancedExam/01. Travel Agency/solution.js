window.addEventListener('load', solution);

function solution() {

  let fullNameElement = document.getElementById('fname');
  let emailElement = document.getElementById('email');
  let phoneElement = document.getElementById('phone');
  let addressElement = document.getElementById('address');
  let postalCodeElement = document.getElementById('code');
  let sumbitBtn = document.getElementById('submitBTN');

  let infoPreviewUl = document.getElementById('infoPreview');
  let editBtn = document.getElementById('editBTN');
  let continueBtn = document.getElementById('continueBTN');

  sumbitBtn.addEventListener('click', () => {


    let fullNameValue = fullNameElement.value;
    let emailValue = emailElement.value;
    let phoneValue = phoneElement.value;
    let addressValue = addressElement.value;
    let postalCodeValue = postalCodeElement.value;

    if (!(fullNameValue && emailValue)) {
      return;
    }

    let fullNameLi = document.createElement('li');
    fullNameLi.textContent = 'Full Name: ' + fullNameValue;

    let emailLi = document.createElement('li');
    emailLi.textContent = 'Email: ' + emailValue;

    let phoneLi = document.createElement('li');
    phoneLi.textContent = 'Phone Number: ' + phoneValue;

    let addressLi = document.createElement('li');
    addressLi.textContent = 'Address: ' + addressValue;

    let postalLi = document.createElement('li');
    postalLi.textContent = 'Postal Code: ' + postalCodeValue;

    infoPreviewUl.appendChild(fullNameLi);
    infoPreviewUl.appendChild(emailLi);
    infoPreviewUl.appendChild(phoneLi);
    infoPreviewUl.appendChild(addressLi);
    infoPreviewUl.appendChild(postalLi);

    sumbitBtn.disabled = true;
    editBtn.disabled = false;
    continueBtn.disabled = false;


    editBtn.addEventListener('click', () => {
      let ul = document.getElementById('infoPreview');

      fullNameElement.value = fullNameValue;
      emailElement.value = emailValue;
      phoneElement.value = phoneValue;
      addressElement.value = addressValue;
      postalCodeElement.value = postalCodeValue;

      while (ul.firstChild) {
        ul.removeChild(ul.lastChild);
      }

      sumbitBtn.disabled = false;
      editBtn.disabled = true;
      continueBtn.disabled = true;
    })

    fullNameElement.value = '';
    emailElement.value = '';
    phoneElement.value = '';
    addressElement.value = '';
    postalCodeElement.value = '';
  });

  continueBtn.addEventListener('click', (e) => {
    let blockElement = document.getElementById('block');

    while (blockElement.firstChild) {
      blockElement.removeChild(blockElement.lastChild);
    }

    let h3 = document.createElement('h3');
    h3.textContent = 'Thank you for your reservation!';
    blockElement.appendChild(h3)
  })
}

function validate() {
    let sumbitButton = document.getElementById('submit');
    let validDivElement = document.getElementById('valid')
    sumbitButton.addEventListener('click', eventButtonHandler);

    let companyCheckbox = document.getElementById('company');
    let companyInfoFieldElement = document.getElementById('companyInfo');
    let isValidCompany = true;

    companyCheckbox.addEventListener('click', () => {
        companyInfoFieldElement.style.display = companyCheckbox.checked ? 'block' : 'none';
    })

    function eventButtonHandler(e) {
        e.preventDefault();

        let usernameInputElement = document.getElementById('username');
        let emailInputElement = document.getElementById('email');
        let passwordInputElement = document.getElementById('password');
        let confirmPasswordInputElement = document.getElementById('confirm-password');

        let usernameRegex = /^[a-zA-z0-9]{3,20}$/;
        let passwordRegex = /^\w{5,15}$/;
        let emailRegex = /^.+\@.+\..+$/;

        let isUsernameCorrect = usernameRegex.test(usernameInputElement.value);
        let isEmailCorrect = emailRegex.test(emailInputElement.value);
        let isPasswordsSame = passwordInputElement.value === confirmPasswordInputElement.value;
        let isPasswordCorrect = false;
        if (passwordRegex.test(passwordInputElement.value)) {
            if (isPasswordsSame) {
                isPasswordCorrect = true;
            }
        }

        if (companyCheckbox.checked) {
            let companyNumberInput = document.getElementById('companyNumber');
            let number = Number(companyNumberInput.value);
            if (number < 1000 || number > 9999) {
                isValidCompany = false;
                elementBorder(companyNumberInput, isValidCompany);
            }
        }

        elementBorder(usernameInputElement, isUsernameCorrect);
        elementBorder(emailInputElement, isEmailCorrect);
        elementBorder(passwordInputElement, passwordRegex.test(passwordInputElement.value));
        elementBorder(confirmPasswordInputElement, passwordRegex.test(confirmPasswordInputElement.value));

        let everyThingIsRight = isUsernameCorrect && isEmailCorrect && isPasswordCorrect && isValidCompany;
        validDivElement.style.display = everyThingIsRight ? 'block' : 'none';
    }

    function elementBorder(element, isCorrect) {
        element.style.borderColor = isCorrect ? 'none' : 'red';
    }
}

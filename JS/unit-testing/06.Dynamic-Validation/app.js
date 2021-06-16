function validate() {
    let regex = /[a-z]*\@[a-z]*\.[a-z]*/;
    let emailInput = document.getElementById('email');

    emailInput.addEventListener('change', (e) => {
        
        let emailValue = emailInput.value;
        if (regex.test(emailValue)){
            emailInput.classList.remove('error');
        } else {
            emailInput.classList.add('error');
        }
    })
}
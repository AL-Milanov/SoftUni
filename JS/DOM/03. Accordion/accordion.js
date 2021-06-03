function toggle() {
    let button = document.getElementsByClassName('button');
    let text = document.querySelector('#extra');

    text.style.display = button[0].textContent === 'More' ? 'block' : 'none';

    return button[0].textContent = button[0].textContent === 'More' ? 'Less': 'More';
}
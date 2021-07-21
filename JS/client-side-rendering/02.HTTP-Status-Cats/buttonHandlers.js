export let statusBtnHandler = (e) => {
    e.preventDefault();

    let statusDiv = e.target.closest('div').querySelector('.status');

    statusDiv.style.display = statusDiv.style.display == 'none' ? 'block' : 'none';
    e.target.textContent = statusDiv.style.display == 'none' ? 'Show status code' : 'Hide status code';
};
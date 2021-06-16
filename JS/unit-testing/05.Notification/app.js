function notify(message) {
  let divNotificationElement = document.getElementById('notification');

  divNotificationElement.textContent = message;
  divNotificationElement.style.display = 'block';

  divNotificationElement.addEventListener('click', () => {
    divNotificationElement.style.display = 'none';
  })
}
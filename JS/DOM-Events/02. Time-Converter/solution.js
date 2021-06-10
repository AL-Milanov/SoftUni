function attachEventsListeners() {
    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    let daysBtn = document.getElementById('daysBtn');
    let hoursBtn = document.getElementById('hoursBtn');
    let minutesBtn = document.getElementById('minutesBtn');
    let secondsBtn = document.getElementById('secondsBtn');

    daysBtn.addEventListener('click', () => {
        let days = daysInput.value;
        let hours = days * 24;
        let minutes = days * 1440; 
        let seconds = days * 86400;

        hoursInput.value = hours;
        minutesInput.value = minutes;
        secondsInput.value = seconds;
    });

    hoursBtn.addEventListener('click', () => {
        let hours = hoursInput.value;
        let days = hours / 24;
        let minutes = hours * 60;
        let seconds = hours * 60 * 60;

        daysInput.value = days;
        minutesInput.value = minutes;
        secondsInput.value = seconds;
    });

    minutesBtn.addEventListener('click', () => {
        let minutes = minutesInput.value;
        let days = minutes / 60 / 24;
        let hours = minutes / 60;
        let seconds = minutes * 60;
        
        daysInput.value = days;
        hoursInput.value = hours;
        secondsInput.value = seconds;
    });

    secondsBtn.addEventListener('click', () => {
        let seconds = secondsInput.value;
        let days = seconds / 86400;
        let hours = seconds / 3600;
        let minutes = seconds / 60;

        daysInput.value = days;
        hoursInput.value = hours;
        minutesInput.value = minutes;
    }); 
}
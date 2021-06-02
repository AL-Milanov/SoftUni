function subtract() {
    let firstNumber = document.getElementById('firstNumber').value;
    let secondNumber = document.getElementById('secondNumber').value;

    let sum = Number(firstNumber) - Number(secondNumber);
    document.getElementById('result').textContent = sum;
}
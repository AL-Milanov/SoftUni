function calculator() {
    let firstNum;
    let secondNum;
    let resultToAdd;

    return {
        init: (selector1, selector2, result) => {
            firstNum = document.querySelector(selector1);
            secondNum = document.querySelector(selector2);
            resultToAdd = document.querySelector(result);
        },
        add: () => {
            resultToAdd.value = Number(firstNum.value) + Number(secondNum.value);
        },
        subtract: () => {
            resultToAdd.value = Number(firstNum.value) - Number(secondNum.value);
        }
    }
}

const calculate = calculator();
const [symBtn,subtractBtn] = document.querySelectorAll('button');

calculate.init('#num1', '#num2', '#result');
symBtn.addEventListener('click', calculate.add);
subtractBtn.addEventListener('click', calculate.add);
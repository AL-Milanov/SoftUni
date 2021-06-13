const isOddOrEven = require('../P02.isOddOrEven');
const assert = require('chai').assert;

describe('Test even or odd functionality', () => {

    it('Should return undefined if parameter isnt string', () => {
        let numbers = 1234;
        let array = [1, 2, 3, 4];

        let numbersUndefined = isOddOrEven(numbers);
        let arrayUndefined = isOddOrEven(array);

        assert.equal(numbersUndefined, undefined);
        assert.equal(arrayUndefined, undefined);
    });

    it('Should return even if passed string with even length', () => {
        let evenString = 'Alex';
        let expected = 'even';
        let actual = isOddOrEven(evenString);

        assert.equal(actual, expected);
    });

    it('Should return odd if passed string with odd length', () => {
        let oddString = 'Vik';
        let expected = 'odd';

        let actual = isOddOrEven(oddString);
        assert.equal(actual, expected);
    });

});
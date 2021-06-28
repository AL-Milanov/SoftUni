let { assert } = require('chai');

const testNumbers = {
    sumNumbers: function (num1, num2) {
        let sum = 0;

        if (typeof (num1) !== 'number' || typeof (num2) !== 'number') {
            return undefined;
        } else {
            sum = (num1 + num2).toFixed(2);
            return sum
        }
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input % 2 === 0) {
            return 'The number is even!';
        } else {
            return 'The number is odd!';
        }

    },
    averageSumArray: function (arr) {

        let arraySum = 0;

        for (let i = 0; i < arr.length; i++) {
            arraySum += arr[i]
        }

        return arraySum / arr.length
    }
};


describe('Testing testNumber functionality', () => {

    describe('testing sumNumbers', () => {

        it('sumNumbers with params that are not numbers', () => {
            assert.strictEqual(testNumbers.sumNumbers(true, 2), undefined);
            assert.strictEqual(testNumbers.sumNumbers(true, false), undefined);
            assert.strictEqual(testNumbers.sumNumbers(undefined, 2), undefined);
            assert.strictEqual(testNumbers.sumNumbers(2, false), undefined);
            assert.strictEqual(testNumbers.sumNumbers(2, '123'), undefined);
        })
        it('sumNumbers with params that are numbers', () => {
            assert.strictEqual(testNumbers.sumNumbers(2, 2), (4).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(2.223, 2), (2.223 + 2).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(-2, 2), (0).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(0, 0), (0).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(-2.1, 123), (123 - 2.1).toFixed(2));


            let x = testNumbers.sumNumbers(2, 2);
            assert.equal(typeof (x), 'string');
        })
    });

    describe('testing numberChecker', () => {

        it('tests with NaN value', () => {

            assert.throws(() => { testNumbers.numberChecker('123abs'); },);
            assert.throws(() => { testNumbers.numberChecker(undefined); },);
            assert.throws(() => { testNumbers.numberChecker([1, 2]); });
        })
        it('tests with even number value', () => {
            let even = 'The number is even!';

            assert.strictEqual(testNumbers.numberChecker(2), even);
            assert.strictEqual(testNumbers.numberChecker(-22), even);
        })
        it('tests with odd number value', () => {
            let odd = 'The number is odd!';

            assert.strictEqual(testNumbers.numberChecker(2.2), odd);
            assert.strictEqual(testNumbers.numberChecker(-33), odd);
        })
        it('test with string value', () => {
            let odd = 'The number is odd!';
            let even = 'The number is even!';

            assert.strictEqual(testNumbers.numberChecker('3'), odd);
            assert.strictEqual(testNumbers.numberChecker('-2'), even);

        })
    });

    it('averageSumArray', () => {
        assert.strictEqual(testNumbers.averageSumArray([1, 2, 3]), 2);
        assert.strictEqual(testNumbers.averageSumArray([2, 2]), 2);
        assert.strictEqual(testNumbers.averageSumArray([1]), 1);
        assert.strictEqual(testNumbers.averageSumArray([1, 2, -3]), 0);
        assert.strictEqual(testNumbers.averageSumArray([1.5, 2.5, 3]), (7 / 3));

        let x = testNumbers.averageSumArray([2, 2]);
        assert.equal(typeof (x), 'number');
    })
})

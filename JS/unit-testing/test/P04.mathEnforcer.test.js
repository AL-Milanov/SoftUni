const assert = require('chai').assert;
const mathEnforcer = require('../P04.mathEnforcer');

describe('mathEnforcer', () => {

    describe('addFive', () => {

        let number = 5;
        let negativeNumber = -10;
        let floatingPointNumber = 5.5;

        it('Should return undefined if its passed parameter different from number', () => {
            assert.equal(mathEnforcer.addFive('23'), undefined);
            assert.equal(mathEnforcer.addFive([1, 2, 3]), undefined);
        });
        it('Should return number + 5 if everything is correct', () => {
            assert.equal(mathEnforcer.addFive(number), (number + 5));
            assert.equal(mathEnforcer.addFive(negativeNumber), (negativeNumber + 5));
            assert.closeTo(mathEnforcer.addFive(floatingPointNumber), (floatingPointNumber + 5), 0.01);
        });
    });

    describe('subtractTen', () => {
        
        let number = 5;
        let negativeNumber = -10;
        let floatingPointNumber = 5.5;

        it('Should return undefined if its passed parameter different from number', () => {
            assert.equal(mathEnforcer.addFive('23'), undefined);
            assert.equal(mathEnforcer.addFive([1, 2, 3]), undefined);
        });
        it('Should return number - 10 if everything is correct', () => {
            assert.equal(mathEnforcer.subtractTen(number), (number - 10));
            assert.equal(mathEnforcer.subtractTen(negativeNumber), (negativeNumber - 10));
            assert.closeTo(mathEnforcer.subtractTen(floatingPointNumber), (floatingPointNumber - 10.01), 0.01);
        });
    });

    describe('sum', () => {
        it('Should return undefined if one of the parameters isnt number', () => {
            assert.equal(mathEnforcer.sum('23', 2), undefined);
            assert.equal(mathEnforcer.sum(true, 2), undefined);
            assert.equal(mathEnforcer.sum(2, '2'), undefined);
            assert.equal(mathEnforcer.sum(2, false), undefined);
        });
        it('Should return sum of both numbers if data inputs are correct', () => {
            assert.equal(mathEnforcer.sum(5, 5), 10);
            assert.equal(mathEnforcer.sum(-5, 5), 0);
            assert.closeTo(mathEnforcer.sum(5.53, 5.23), 10.76, 0.01);
        })
    })
});
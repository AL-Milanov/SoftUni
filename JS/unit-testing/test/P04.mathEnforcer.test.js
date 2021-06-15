const assert = require('chai').assert;
const mathEnforcer = require('../P04.mathEnforcer');

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('Should return undefined if its passed parameter different from number', () => {
            assert.equal(mathEnforcer.addFive('23'), undefined);
            assert.equal(mathEnforcer.addFive(true), undefined);
        });
        it('Should return number + 5 if everything is correct', () => {
            let number = 5;
            let negativeNumber = -10;
            let floatingPointNumber = 5.5;

            assert.closeTo(mathEnforcer.addFive(number), (number + 5), 0.01);
            assert.closeTo(mathEnforcer.addFive(negativeNumber), -5, 0.01);
            assert.closeTo(mathEnforcer.addFive(floatingPointNumber), 10.5, 0.01);
        });
    });
    describe('subtractTen', () => {
        it('Should return undefined if its passed parameter different from number', () => {
            assert.equal(mathEnforcer.addFive('23'), undefined);
            assert.equal(mathEnforcer.addFive(true), undefined);
        });
        it('Should return number - 10 if everything is correct', () => {
            let number = 5;
            let negativeNumber = -20;
            let floatingPointNumber = 5.5;

            assert.closeTo(mathEnforcer.addFive(number), (number + 5), 0.01);
            assert.closeTo(mathEnforcer.addFive(negativeNumber), (negativeNumber + 5), 0.01);
            assert.closeTo(mathEnforcer.addFive(floatingPointNumber), (floatingPointNumber + 5), 0.01);
        });
    });
    describe('sum', () => {
        it('Should return undefined if first of the parameters isnt number', () => {
            assert.equal(mathEnforcer.sum('23', 2), undefined);
            assert.equal(mathEnforcer.sum(true, 2), undefined);
        });
        it('Should return undefined if second of the parameters isnt number', () => {
            assert.equal(mathEnforcer.sum(23, '2'), undefined);
            assert.equal(mathEnforcer.sum(2, true), undefined);
        });
        it('Should return sum of both numbers if data inputs are correct', () => {
            assert.closeTo(mathEnforcer.sum(5, 5), 10, 0.01);
            assert.closeTo(mathEnforcer.sum(-5, 5), 0, 0.01);
            assert.closeTo(mathEnforcer.sum(5.53, 5.23), 10.76, 0.01);
            assert.closeTo(mathEnforcer.sum(-5.53, -5.23), -10.76, 0.01);
        })
    })
});
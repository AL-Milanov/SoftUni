const mathEnforcer = require('../P04.mathEnforcer');
const assert = require('chai').assert;

describe('mathEnforcer', () => {

    describe('addFive', () => {

        it('Should return undefined if its passed parameter different from number', () => {
            let expected = undefined;
            assert.equal(mathEnforcer.addFive(true), expected);
            assert.equal(mathEnforcer.addFive('string'), expected);
        });
        it('Should return number + 5 if everything is correct', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
            assert.equal(mathEnforcer.addFive(-5), 0);
            assert.closeTo(mathEnforcer.addFive(5.5), 10.5, 0.01);
        });
    });

    describe('subtractTen', () => {

        it('Should return undefined if its passed parameter different from number', () => {
            let expected = undefined;
            assert.equal(mathEnforcer.subtractTen(true), expected);
            assert.equal(mathEnforcer.subtractTen('string'), expected);
        });
        it('Should return number - 10 if everything is correct', () => {
            assert.equal(mathEnforcer.subtractTen(5), -5);
            assert.equal(mathEnforcer.subtractTen(-5), -15);
            assert.closeTo(mathEnforcer.subtractTen(0.5), -9.5, 0.01);
        });
    });

    describe('sum', () => {
        it('Should return undefined if first parameter isnt number', () => {
            let expected = undefined;
            assert.equal(mathEnforcer.sum(true, 23), expected);
            assert.equal(mathEnforcer.sum(' ', 23), expected);
        });
        it('Should return undefined if second parameter isnt number', () => {
            let expected = undefined;
            assert.equal(mathEnforcer.sum(23, false), expected);
            assert.equal(mathEnforcer.sum(3, null), expected);
        });
        it('Should return sum of both numbers if data inputs are correct', () => {
            assert.equal(mathEnforcer.sum(-5, 10), 5);
            assert.equal(mathEnforcer.sum(5, 10), 15);
            assert.equal(mathEnforcer.sum(-5.5, 10.5), 5);
        })
    })
});
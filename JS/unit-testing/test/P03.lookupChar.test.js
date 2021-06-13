const lookupChar = require('../P03.lookupChar');
const assert = require('chai').assert;

describe('Test lookupChar functionality', () =>{
    it('Should return undefined if 1st param isnt string or 2nd param isnt number', () =>{
        let invalidFirstParam = [1, 2];
        let otherInvalidFirstParam = false; 

        let invalidSecondParam = '23';
        let otherInvalidSecondParam = {number : 2};

        assert.equal(lookupChar(invalidFirstParam, 2), undefined);
        assert.equal(lookupChar(otherInvalidFirstParam, 2), undefined);
        assert.equal(lookupChar('valid', invalidSecondParam), undefined);
        assert.equal(lookupChar('valid', otherInvalidSecondParam), undefined);
        assert.equal(lookupChar('valid', 2.2), undefined);
    });
    
    it('Pass negative or bigger number', () => {
        let validString = 'Hello';
        let endIndex = validString.length - 1;
        let expected = 'Incorrect index';

        assert.equal(lookupChar(validString, -1), expected);
        assert.equal(lookupChar(validString, (endIndex + 1)), expected);
    });

    it('Should return char on index if passed correct data', () => {
        let validString = 'Hello';
        let endIndex = validString.length - 1;

        assert.equal(lookupChar(validString, 0), 'H');
        assert.equal(lookupChar(validString, endIndex), 'o');
    });
});
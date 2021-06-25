let { assert } = require('chai');

class PaymentPackage {

    constructor(name, value) {
        this.name = name;
        this.value = value;
        this.VAT = 20;      // Default value    
        this.active = true; // Default value
    }

    get name() {
        return this._name;
    }

    set name(newValue) {
        if (typeof newValue !== 'string') {
            throw new Error('Name must be a non-empty string');
        }
        if (newValue.length === 0) {
            throw new Error('Name must be a non-empty string');
        }
        this._name = newValue;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('Value must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('Value must be a non-negative number');
        }
        this._value = newValue;
    }

    get VAT() {
        return this._VAT;
    }

    set VAT(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('VAT must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('VAT must be a non-negative number');
        }
        this._VAT = newValue;
    }

    get active() {
        return this._active;
    }

    set active(newValue) {
        if (typeof newValue !== 'boolean') {
            throw new Error('Active status must be a boolean');
        }
        this._active = newValue;
    }

    toString() {
        const output = [
            `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${this.value}`,
            `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
        ];
        return output.join('\n');
    }
}



describe('Tests for Package class', () => {
    it('Test two objects', () => {
        let pesho = new PaymentPackage('Pesho', 0);
        let stamat = new PaymentPackage('Stamat', 1);
        assert.equal(pesho.value, 0);
        assert.equal(stamat.value, 1);
    });
    it('Constructor tests check if everything is set with correct data', () => {
        let paymentPackage = new PaymentPackage('some', 50);

        assert.equal(paymentPackage.name, 'some');
        assert.equal(paymentPackage.value, 50);
        assert.equal(paymentPackage.VAT, 20);
        assert.equal(paymentPackage.active, true);
    });
    it('Test name setter with incorrect data', () => {
        let paymentPackage = new PaymentPackage('some', 50);

        assert.throws(() => {paymentPackage.name = 123});
        assert.throws(() => {paymentPackage.name = ''});
        assert.throws(() => {paymentPackage.name = false});
    });
    it('Test name setter with correct data', () => {
        let paymentPackage = new PaymentPackage('some', 50);
        paymentPackage.name = 'Alex';
        let expected = 'Alex';
        let actual = paymentPackage.name;

        assert.equal(actual, expected);
    });
    it('Test value setter with incorrect data', () => {
        let paymentPackage = new PaymentPackage('some', 50);

        assert.throws(() => {paymentPackage.value = -123});
        assert.throws(() => {paymentPackage.value = ''});
        assert.throws(() => {paymentPackage.value = undefined});
        paymentPackage.value = NaN;
        assert.isNaN(paymentPackage.value);
    });
    it('Test value setter with correct data', () => {
        let paymentPackage = new PaymentPackage('some', 50);
        paymentPackage.value = 12.50;
        let expected = 12.50;
        let actual = paymentPackage.value;

        assert.equal(actual, expected);
    });
    it('Test VAT setter with incorrect data', () => {
        let paymentPackage = new PaymentPackage('some', 50);

        assert.throws(() => {paymentPackage.VAT = -123});
        assert.throws(() => {paymentPackage.VAT = ''});
        assert.throws(() => {paymentPackage.VAT = undefined});
        paymentPackage.VAT = NaN;
        assert.isNaN(paymentPackage.VAT);
    });
    it('Test VAT setter with correct data', () => {
        let paymentPackage = new PaymentPackage('some', 50);
        paymentPackage.VAT = 12.50;
        let expected = 12.50;
        let actual = paymentPackage.VAT;

        assert.equal(actual, expected);
    });
    it('Test active setter with incorrect data', () => {
        let paymentPackage = new PaymentPackage('some', 50);
       
        assert.throws(() => {paymentPackage.active = -123});
        assert.throws(() => {paymentPackage.active = ''});
        assert.throws(() => {paymentPackage.active = null});
    });
    it('Test active setter with correct data', () => {
        let paymentPackage = new PaymentPackage('some', 50);
        paymentPackage.active = false;
        let expected = false;
        let actual = paymentPackage.active;

        assert.equal(actual, expected);
    });
    it('Test toString functionality', () => {
        let paymentPackage1 = new PaymentPackage('some', 50);
        let paymentPackage2 = new PaymentPackage('some', 50);
        paymentPackage2.active = false;
        paymentPackage2.name = 'Alex';
        paymentPackage2.VAT = 10.5;

        let expected1 = [
            `Package: ${paymentPackage1.name}` + (paymentPackage1.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${paymentPackage1.value}`,
            `- Value (VAT ${paymentPackage1.VAT}%): ${paymentPackage1.value * (1 + paymentPackage1.VAT / 100)}`
        ].join('\n');

        let expected2 = [
            `Package: Alex` + (paymentPackage2.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${paymentPackage2.value}`,
            `- Value (VAT ${paymentPackage2.VAT}%): ${paymentPackage2.value * (1 + paymentPackage2.VAT / 100)}`
        ].join('\n');

        assert.equal(paymentPackage1.toString(), expected1);
        assert.equal(paymentPackage2.toString(), expected2);
    });
});

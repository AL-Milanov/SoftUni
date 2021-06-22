class Hex {
    constructor(value) {
        this._value = value;
    }

    valueOf() {
        return this._value;
    }

    toString() {
        let valueToHex = '0x';
        let number = this._value;
        let result = [];

        while (number > 0) {

            let hex = number % 16;

            if (hex > 9) {
                if (hex == 10) {
                    result.unshift('A');
                }
                if (hex == 11) {
                    result.unshift('B');
                }
                if (hex == 12) {
                    result.unshift('C');
                }
                if (hex == 13) {
                    result.unshift('D');
                }
                if (hex == 14) {
                    result.unshift('E');
                }
                if (hex == 15) {
                    result.unshift('F');
                }
            }

            if (hex <= 9) {
                result.unshift(`${hex}`);
            }

            number = Math.floor(number / 16);
        }
        result.forEach(el => valueToHex += el);
        return valueToHex;
    }

    plus(number) {
        if (typeof number === 'number') {
            this._value += number;
        } else {
            let newObj = new Hex(this._value + number._value);
            return newObj;
        }
    }

    minus(number) {
        if (typeof number === 'number') {
            this._value -= number;
        } else {
            let newObj = new Hex(this._value - number._value);
            return newObj;
        }
    }

    static parse(hexNumber) {
        let numberInDecimal = 0;
        let pow = hexNumber.length - 1;

        for (let i = 0; i < hexNumber.length; i++) {
            let current = hexNumber[i];

            let hexSymbols = {
                '0': 0,
                '1': 1,
                '2': 2,
                '3': 3,
                '4': 4,
                '5': 5,
                '6': 6,
                '7': 7,
                '8': 8,
                '9': 9,
                'A': 10,
                'B': 11,
                'C': 12,
                'D': 13,
                'E': 14,
                'F': 15,
            }
            let x = Math.pow(16, pow);
            numberInDecimal += (hexSymbols[current] * x);
            pow--;
        }

        return numberInDecimal;
    }
}

let a = new Hex(10);
let b = new Hex(5);
console.log(a.minus(b).toString());
console.log(Hex.parse('AAA'));


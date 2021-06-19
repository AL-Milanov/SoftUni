let myStr = 'my string';

(function solve() {
    String.prototype.ensureStart = function (str) {
        let result = '';
        if (this.startsWith(str, 0)) {
            result = this.valueOf();
        } else {
            result = this.slice(0, 0) + str + this.slice(0);
        }
        return result;
    };

    String.prototype.ensureEnd = function (str) {
        let result = '';
        if (this.endsWith(str)) {
            result = this.valueOf();
        } else {
            result = this.slice(0, this.length) + str + this.slice(this.length);
        }
        return result;
    };

    String.prototype.isEmpty = function () {
        if (this.length === 0) {
            return true;
        } else {
            return false;
        }
    };

    String.prototype.truncate = function (n) {
        let result = '';
        if (this.length < n) {
            result = this.valueOf();
        } else if (n < 4) {
            for (let i = 0; i < n; i++) {
                result += '.';
            }
        } else {
            let splitted = this.valueOf().split(' ');
            if (splitted.length === 1) {
                result = splitted[0].slice(0, (n - 3)) + '...';
            } else {
                for (let i = 0; i < splitted.length - 1; i++) {
                    if (i < splitted.length - 2) {
                        splitted[i] += ' ';
                    }
                }
                splitted[splitted.length - 1] = '...';
                while (splitted.length !== 0) {
                    result += splitted.shift();
                }
                while (result.length > n) {
                    result = result.slice(0, -1);
                }
                if (!result.endsWith('...')) {
                    result = result.slice(0, 3) + '...';
                }
            }
        }

        return result;
    }

    String.format = function (string, ...params) {
        let y = params;
        let result = string;
        while (params.length !== 0) {
            result = result.replace(/\{\d+\}/, function (el) {
                return el = y.shift() || el;
            });
        }
        return result;
    }
})();

let x = myStr.ensureStart('hello ');

x = x.truncate(16);
console.log(x);

x = x.truncate(14);
console.log(x);

x = x.truncate(8);
console.log(x);

x = x.truncate(4);
console.log(x);

x = x.truncate(2);
console.log(x);

x = String.format('jumps {0} {1}',
    'dog'
);
console.log(x);
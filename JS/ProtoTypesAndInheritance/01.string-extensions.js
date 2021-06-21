let myStr = 'my string';

(function solve() {
    String.prototype.ensureStart = function (str) {
        let result = '';
        if (this.startsWith(str)) {
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
        if (this.length <= n) {
            return this.toString();
        }

        if (this.includes(' ')) {
           let words = this.split(' ');
           while(words.join(' ').length + 3 > n){
               words.pop();
           }
           let sentence = `${words.join(' ')}...`;
           return sentence;
        }

        if (n > 3) {
            let string = `${this.slice(0, n -3)}...`
            return string;
        }

        return '.'.repeat(n);
    }

    String.format = function (string, ...params) {
        let result = string;
        while (params.length !== 0) {
            result = result.replace(/\{\d+\}/g, function (el) {
                return el = params.shift() || el;
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
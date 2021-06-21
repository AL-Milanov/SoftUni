class List {
    constructor(numbers = []) {
        this.numbers = numbers.sort((a, b) =>  a - b);
        this.size = this.numbers.length;
    }

    add(element) {
        this.numbers.push(element);
        this.numbers.sort((a, b) => a - b);
        this.size++;
        return
    }
    remove(index) {
        if (index >= 0 && index < this.numbers.length) {
            this.numbers.splice(index, 1);
            this.size--;
            return;
        } else {
            throw new Error(`Index doesn't exist`);
        }
    }
    get(index) {
        if (index >= 0 && index < this.numbers.length) {
            return this.numbers[index];
        } else {
            throw new Error(`Index doesn't exist`);
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
console.log(list.get(2));

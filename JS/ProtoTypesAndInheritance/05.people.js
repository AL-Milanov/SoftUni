function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let currentTask = this.tasks.shift();
            console.log(`${this.name} ` + currentTask);
            this.tasks.push(currentTask);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }
    

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push('is working on a simple task.');
        }
    }


    return {
        Employee,
        Junior,
        //Senior,
        //Manager,
    }
}

let classes = solve();
const junior = new classes.Junior('Ivan', 25);

console.log(junior.work());


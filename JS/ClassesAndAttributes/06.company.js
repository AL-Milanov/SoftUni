class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        let employee = {
            username,
            salary,
            position,
            department,
        }

        if (employee.salary < 0) { // probably <= 0
            throw new Error("Invalid input!");
        }

        let values = Object.values(employee);
        values.forEach(el => {
            if (!el && el !== 0) { // 0 is falsey 
                throw new Error("Invalid input!");
            }
        });

        if (!this.departments[employee.department]) {
            this.departments[employee.department] = [];
        }

        this.departments[employee.department].push(employee);

        return `New employee is hired. Name: ${employee.username}. Position: ${employee.position}`;
    }

    bestDepartment() {
        let bestDepartment = "";
        let highestDepartmentSalary = 0;
        Object.entries(this.departments).forEach(([key, value]) => {
            let salary = 0;
            value.forEach(el => salary += el.salary);

            salary /= value.length;

            if (salary > highestDepartmentSalary) {
                highestDepartmentSalary = salary;
                bestDepartment = key;
            }
        });

        let result = `Best Department is: ${bestDepartment}\nAverage salary: ${Math.round(highestDepartmentSalary).toFixed(2)}\n`;
        Object.values(this.departments[bestDepartment])
            .sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username)).forEach(e => {
                let employee = `${e.username} ${e.salary} ${e.position}\n`;
                result += employee;
        });

        return result.trim();
    }
}

let c = new Company();

c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");

let act = c.bestDepartment();
console.log(act);
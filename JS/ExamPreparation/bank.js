class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let findCustomer = this.allCustomers.find(e => e.firstName == customer.firstName
            && e.lastName == customer.lastName);

        if (findCustomer) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        let customerToAdd = Object.assign({}, customer);

        this.allCustomers.push(customerToAdd);
        customerToAdd.totalMoney = 0;
        customerToAdd.transaction = [];
        customerToAdd.transactionNumber = 1;

        return customer;
    }

    depositMoney(personalId, amount) {
        let findCustomer = this.allCustomers.find(e => e.personalId == personalId);

        if (!findCustomer) {
            throw new Error(`We have no customer with this ID!`);
        }

        findCustomer.totalMoney += amount;
        findCustomer.transaction.unshift(`${findCustomer.transactionNumber++}. ${findCustomer.firstName} ${findCustomer.lastName} made deposit of ${amount}$!`);

        return `${findCustomer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let findCustomer = this.allCustomers.find(e => e.personalId == personalId);

        if (!findCustomer) {
            throw new Error(`We have no customer with this ID!`);
        }

        if (findCustomer.totalMoney < amount) {
            throw new Error(`${findCustomer.firstName} ${findCustomer.lastName} does not have enough money to withdraw that amount!`)
        }

        findCustomer.totalMoney -= amount;
        findCustomer.transaction.unshift(`${findCustomer.transactionNumber++}. ${findCustomer.firstName} ${findCustomer.lastName} withdrew ${amount}$!`);

        return `${findCustomer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let findCustomer = this.allCustomers.find(e => e.personalId == personalId);

        if (!findCustomer) {
            throw new Error(`We have no customer with this ID!`);
        }
      
        let result = '';
        result += `Bank name: ${this._bankName}
Customer name: ${findCustomer.firstName} ${findCustomer.lastName}
Customer ID: ${findCustomer.personalId}
Total Money: ${findCustomer.totalMoney}$
Transactions:\n`;
        result += findCustomer.transaction ? findCustomer.transaction.join('\n') : '';

        return result.trim();
    }
}


let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

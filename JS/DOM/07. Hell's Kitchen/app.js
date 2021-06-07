function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let textInput = JSON.parse(document.querySelector('#inputs textarea').value);
      
      let restaurantResults = textInput.reduce((a , e) => {
         let [resaurant, ...workers] = e.split(/(?: - )|(?:, )/g);
         workers = workers.map(w => {
            let [worker, salary] = w.split(' ');
            return {
               worker: worker,
               salary: Number(salary)
            };
         });

         let restaurantExists = a.find(r => r.name === resaurant);

         if (restaurantExists) {
            restaurantExists.workers = restaurantExists.workers.concat(workers);
         } else {
            a.push({
               name: resaurant,
               workers: workers
            });
         }

         return a;
      }, [])

      restaurantResults.forEach(el => {

         el.averageSalary = el.workers.reduce((a, el) => a + el.salary, 0) / el.workers.length;
         el.maxSalary = Math.max(...el.workers.map(w => w.salary));
      });


      let bestRestaurant = restaurantResults.sort((a, b) => b.averageSalary - a.averageSalary)[0];
      bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      let outputRestaurantName =  
      `Name: ${bestRestaurant.name} 
      Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} 
      Best Salary: ${bestRestaurant.maxSalary.toFixed(2)}`;

      let outputWorkers = bestRestaurant.workers.map(w => `Name: ${w.worker} With Salary: ${w.salary}`).join(' ');

      document.querySelector('#bestRestaurant>p').textContent = outputRestaurantName;
      document.querySelector('#workers>p').textContent = outputWorkers;
   }
}
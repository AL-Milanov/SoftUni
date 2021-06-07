function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      
      let searchField = document.querySelector('#searchField');
      let tableData = document.querySelectorAll('tbody tr');

      for (const row of tableData) {
         row.classList.remove('select');
      }

      let textInput = searchField.value; 

      for (const row of tableData) {

         if (row.textContent.includes(textInput)) {
            row.classList.add('select');
         }
      }

      searchField.value = '';
   }
}
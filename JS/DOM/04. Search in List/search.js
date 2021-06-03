function search() {
   let towns = document.querySelectorAll('#towns li');
   let searchedText = document.querySelector('#searchText').value;
   let matches = 0;

   for (const town of towns) {
      if (town.textContent.includes(searchedText)) {
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         matches++;
      } else{
         town.style.textDecoration = 'none';
         town.style.fontWeight = 'normal';
      }
   }

   let result = document.querySelector('#result');

   return result.textContent = `${matches} matches found`;
}

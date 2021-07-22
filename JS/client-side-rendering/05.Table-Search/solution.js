import { render } from "../node_modules/lit-html/lit-html.js";
import { loadStudent } from "./templates/studentsDataTemplate.js";

document.querySelector('#searchBtn').addEventListener('click', onClick);
let containerBody = document.querySelector('.container tbody');

fetch('http://localhost:3030/jsonstore/advanced/table')
   .then(response => response.json())
   .then(data => {
      let result = Object.values(data).map(s => loadStudent(s));
      render(result, containerBody);
   })
   .catch(err => console.log(err));

function onClick() {
   let searchFieldElement = document.querySelector('#searchField');
   let searchValue = searchFieldElement.value.toUpperCase();

   let allStudents = containerBody.querySelectorAll('tr');

   allStudents.forEach(tr => tr.classList.remove('select'));
   allStudents.forEach(tr => {
      if (tr.textContent.toUpperCase().includes(searchValue)) {
         tr.classList.add('select');
      }
   });

   searchFieldElement.value = '';
}
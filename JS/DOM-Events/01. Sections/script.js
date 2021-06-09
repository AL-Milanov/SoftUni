function create(words) {
   let idElement = document.getElementById('content');

   let length = words.length;

   for (let i = 0; i < length; i++) {

      let p = document.createElement('p');
      let div = document.createElement('div');

      p.style.display = 'none';

      p.textContent = words.shift();
      div.appendChild(p);
      idElement.appendChild(div);

      div.addEventListener('click', (e) => {
         p.style.display = 'block';
      });

   }
}
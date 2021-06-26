function solve() {
   let authorElement = document.getElementById('creator');
   let titleElement = document.getElementById('title');
   let categoryElement = document.getElementById('category');
   let contentElement = document.getElementById('content');
   let createBtn = document.querySelector('aside section button');

   createBtn.addEventListener('click', (e) => {
      e.preventDefault();

      let titleValue = titleElement.value;
      let sectionElement = document.querySelector('main section');
      let article = document.createElement('article');

      let h1 = document.createElement('h1');
      h1.textContent = titleElement.value;
      article.appendChild(h1);

      let pCaterogy = document.createElement('p');
      pCaterogy.textContent = 'Category:';
      let strongCategory = document.createElement('strong');
      strongCategory.textContent = categoryElement.value;
      pCaterogy.appendChild(strongCategory);
      article.appendChild(pCaterogy);

      let pCreator = document.createElement('p');
      pCreator.textContent = 'Creator:';
      let strongCreator = document.createElement('strong');
      strongCreator.textContent = authorElement.value;
      pCreator.appendChild(strongCreator);
      article.appendChild(pCreator);

      let pContent = document.createElement('p');
      pContent.textContent = contentElement.value;
      article.appendChild(pContent);

      let div = document.createElement('div');
      div.classList.add('buttons');

      let deleteBtn = document.createElement('button');
      deleteBtn.classList.add('btn', 'delete');
      deleteBtn.textContent = 'Delete'
      deleteBtn.addEventListener('click', (e) => {
         e.target.parentElement.parentElement.remove();
      });
      div.appendChild(deleteBtn);

      let archiveBtn = document.createElement('button');
      archiveBtn.classList.add('btn', 'archive');
      archiveBtn.textContent = 'Archive';
      archiveBtn.addEventListener('click', (e) => {
         let sectionOlElement = document.querySelector('.archive-section ol');

         let li = document.createElement('li');
         li.textContent = titleValue;
         sectionOlElement.appendChild(li);

         let liCollection = Array.from(sectionOlElement.querySelectorAll('li'));
         let sortedLiCollection = liCollection.sort((a, b) => a.innerText.localeCompare(b.innerText));

         while (sectionOlElement.firstChild) {
            sectionOlElement.firstChild.remove();
         }

         for (const element of sortedLiCollection) {
            sectionOlElement.appendChild(element);
         }

         e.target.parentElement.parentElement.remove();

      });
      div.appendChild(archiveBtn);

      article.appendChild(div);
      sectionElement.appendChild(article);


      authorElement.value = '';
      titleElement.value = '';
      categoryElement.value = '';
      contentElement.value = '';
   })
}


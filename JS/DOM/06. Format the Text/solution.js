function solve() {
  let inputData = document.querySelector('#input');
  let output = document.querySelector('#output');

  let textFromInput = inputData.value;
  let splitted = textFromInput.split('.').filter(e => e);
  
  let p = document.createElement('p');
  let box = ''; 

  for (let index = 1; index <= splitted.length; index++) {

    if (index % 3 === 0) {
      p.textContent += box + splitted[index - 1] + '.\n';
      output.appendChild(p);
      p = document.createElement('p');
      box = '';
    } else{
      box += splitted[index - 1] + '.';
    }
  }
  console.log(box);
  if (box !== '') {
    p = document.createElement('p');
    p.textContent = box;
    output.appendChild(p);
  }
}
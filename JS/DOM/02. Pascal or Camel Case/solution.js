function solve() {
  const text = document.getElementById('text').value;
  const convention = document.getElementById('naming-convention').value;

  let result = '';
  
  result = convertText(text, convention);

  function convertText(text, convention) {
    let output = '';
    let splitted = text.split(' ');

    if (convention === 'Camel Case') {
      output += splitted.shift().toLowerCase();
      
      for (const current of splitted) {
        for (let i = 0; i < current.length; i++) {
          if (i === 0) {
            output += current[i].toUpperCase();
          }else{
            output += current[i].toLowerCase();
          }
        }
      }
    } else if (convention === 'Pascal Case') {
      
      for (const current of splitted) {
        for (let i = 0; i < current.length; i++) {
          if (i === 0) {
            output += current[i].toUpperCase();
          }else{
            output += current[i].toLowerCase();
          }
        }
      }
    } else{
      output = 'Error!';
    }

    return output;
  }

  return  document.getElementById('result').textContent = result;
}
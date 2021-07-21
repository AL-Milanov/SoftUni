
export let searchBtnHandler = () => {
    let townsDivElement = document.getElementById('towns');
    let searchTextElement = document.getElementById('searchText');
    let resultDivElement = document.getElementById('result');

    let searchText = searchTextElement.value;

    let towns = townsDivElement.querySelectorAll('li');
    towns.forEach(t => t.classList.remove('underLine'));

    let matchedTowns = [];

    towns.forEach(town => {
        if (town.textContent.toLowerCase().includes(searchText.toLowerCase())) {
            matchedTowns.push(town);
        }
    });

    resultDivElement.textContent = `${matchedTowns.length} matches found`;

    matchedTowns.forEach(t => t.classList.add('underLine'));

    searchTextElement.value = '';
};
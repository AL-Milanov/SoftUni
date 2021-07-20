import { render } from '../node_modules/lit-html/lit-html.js';
import { allTownsUl } from './citiesTemplates.js';

let rootDivElement = document.querySelector('#root');

export let formEventHandler = (e) => {
    e.preventDefault();

    let formData = new FormData(e.target);

    let townsData = formData.get('towns').split(', ');

    render(allTownsUl(townsData), rootDivElement);

    e.target.reset();
};
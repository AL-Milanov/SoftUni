import { html } from '../node_modules/lit-html/lit-html.js';

export let townLi = (town) => html`
    <li>${town}</li>
`;

export let allTownsUl = (towns) => html`
    <ul>${towns.map(t => townLi(t))}</ul>
`;
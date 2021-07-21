import { html } from "../../node_modules/lit-html/lit-html.js";

export let loadTown = (town) => html`
    <li>${town}</li>
`

export let loadAllTowns = (towns) => html`
    <ul>${towns.map(t => loadTown(t))}</ul>
`;
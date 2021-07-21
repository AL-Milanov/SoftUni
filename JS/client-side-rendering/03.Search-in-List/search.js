import { render } from "../node_modules/lit-html/lit-html.js";
import { searchBtnHandler } from "./buttonHandler.js";
import { loadAllTowns } from "./templates/townsTemplate.js";
import { towns } from "./towns.js";

let townsDivElement = document.getElementById('towns');
let searchBtnElement = document.getElementById('search-btn');

render(loadAllTowns(towns), townsDivElement);

searchBtnElement.addEventListener('click', searchBtnHandler);

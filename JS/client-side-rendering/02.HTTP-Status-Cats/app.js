import { render } from "./../node_modules/lit-html/lit-html.js";
import { loadAllCats } from './templates/catsTemplate.js';
import { cats } from './catSeeder.js';
import { statusBtnHandler } from "./buttonHandlers.js";

let allCatsElement = document.getElementById('allCats');

render(loadAllCats(cats, statusBtnHandler), allCatsElement);

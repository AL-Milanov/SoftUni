
import { formEventHandler } from './formEventHandler.js';

let contentFormElement = document.querySelector('.content');

contentFormElement.addEventListener('submit', formEventHandler);
import { formEventHandler } from "./helpers/eventHandlers.js";
import { getRequest } from "./helpers/requests.js";

getRequest();

let formElement = document.getElementById('form');

formElement.addEventListener('click', formEventHandler);

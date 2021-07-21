import { render } from "lit-html";
import { loadOption } from "../templates/dropDownTemplate.js";

const baseUrl = `http://localhost:3030/jsonstore/advanced/dropdown`;

let menuDivElement = document.getElementById('menu');

export function getRequest() {
    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            let result = [];
            Object.values(data).forEach(el => result.push(loadOption(el)));
            result.join('\n');
            render(result, menuDivElement);
        })
        .catch(err => console.error(err));
};

export function postRequest(data){
    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .catch(err => console.error(err));

    getRequest();
}
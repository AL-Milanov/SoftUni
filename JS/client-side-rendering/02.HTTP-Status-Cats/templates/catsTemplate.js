import { html } from "./../../node_modules/lit-html/lit-html.js";

export let loadCat = (cat, statusBtnHandler) => html`
    <li id="${cat.id}">
        <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn" @click=${statusBtnHandler}>Show status code</button>
            <div class="status" style="display: none" id="100">
                <h4>Status Code: ${cat.statusCode}</h4>
                <p>${cat.statusMessage}</p>
            </div>
        </div>
    </li>
`;

export let loadAllCats = (cats, statusBtnHandler) => html`
    <ul>${cats.map(c => loadCat(c, statusBtnHandler))}</ul>
`;

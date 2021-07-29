import { html } from "../../node_modules/lit-html/lit-html.js";

export let myFurnituresTemplate = (myFurnitures) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>My Furniture</h1>
        <p>This is a list of your publications.</p>
    </div>
</div>
<div class="row space-top">
    ${myFurnitures.map(f => myFurnitureTemplate(f))}
</div>
`;

let myFurnitureTemplate = (t) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src="${t.img}" />
            <p>${t.description}</p>
            <footer>
                <p>Price: <span>${t.price} $</span></p>
            </footer>
            <div>
                <a href="/details/${t._id}" class="btn btn-info">Details</a>
            </div>
        </div>
    </div>
</div>
`;
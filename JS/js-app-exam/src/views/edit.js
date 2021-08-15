import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { edit, getOne } from "../../requests/requests.js";

let _router, _render;
let bookId = undefined;


const editPageTemplate = (book, editSubmitHandler) => html`
        <!-- Edit Page ( Only for the creator )-->
        <section id="edit-page" class="edit">
            <form id="edit-form" action="#" method="" @submit=${editSubmitHandler}>
                <fieldset>
                    <legend>Edit my Book</legend>
                    <p class="field">
                        <label for="title">Title</label>
                        <span class="input">
                            <input type="text" name="title" id="title" value=${book.title}>
                        </span>
                    </p>
                    <p class="field">
                        <label for="description">Description</label>
                        <span class="input">
                            <textarea name="description" id="description">${book.description}</textarea>
                        </span>
                    </p>
                    <p class="field">
                        <label for="image">Image</label>
                        <span class="input">
                            <input type="text" name="imageUrl" id="image" value=${book.imageUrl}>
                        </span>
                    </p>
                    <p class="field">
                        <label for="type">Type</label>
                        <span class="input">
                            <select id="type" name="type" value=${book.type}>
                                <option value="Fiction">Fiction</option>
                                <option value="Romance">Romance</option>
                                <option value="Mistery">Mistery</option>
                                <option value="Classic">Clasic</option>
                                <option value="Other">Other</option>
                            </select>
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Save">
                </fieldset>
            </form>
        </section>
`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage(context, next) {
    bookId = context.params.id;

    getOne(bookId).then(book => _render(editPageTemplate(book, editSubmitHandler))).catch(err => alert(err));
}

const editSubmitHandler = (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');
    let type = formData.get('type');

    if (!(title.trim() && description.trim() && imageUrl.trim())) {
        alert('All fields must be filled');
        return;
    }

    let editedBook = {
        title,
        description,
        imageUrl,
        type
    }

    edit(bookId, editedBook).then(book => _router.redirect(`/dashboard/${book._id}`)).catch(err => alert(err));
}

export default {
    init,
    getPage,
}
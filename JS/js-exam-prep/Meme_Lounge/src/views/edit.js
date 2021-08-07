import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { editMeme, getMeme } from "../../requests/requests.js";

let _router, _render;
let memeId = undefined;


const editPageTemplate = (meme, editSubmitHandler) => html`<!-- Edit Meme Page ( Only for logged user and creator to this meme )-->
<section id="edit-meme">
    <form id="edit-form" @submit=${editSubmitHandler}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" value=${meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}></textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>
`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage(context, next) {
    memeId = context.params.id;
    
    getMeme(memeId).then(meme => _render(editPageTemplate(meme, editSubmitHandler))).catch(err => alert(err));
}

const editSubmitHandler = (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);
    
    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');

    if (!(title.trim() && description.trim() && imageUrl.trim())) {
        alert('All fields must be filled');
        return;
    }

    let editedMeme = {
        title,
        description,
        imageUrl
    }

    editMeme(memeId, editedMeme).then(meme => _router.redirect(`/all-memes/${meme._id}`)).catch(err => alert(err));
}

export default {
    init,
    getPage,
}
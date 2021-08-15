import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { del, getLikesOfBook, getOne, getUserLikes, likesForBook } from "../../requests/requests.js";

let _router, _render;
let bookId = undefined;
let isNotLiked = true;

const detailsPageTemplate = (book, userId, deleteHandler, likeBtnHandler, likes, userLikedBook) => html`
        <!-- Details Page ( for Guests and Users ) -->
        <section id="details-page" class="details">
            <div class="book-information">
                <h3>${book.title}</h3>
                <p class="type">Type: ${book.type}</p>
                <p class="img"><img src=${book.imageUrl}></p>
                <div class="actions">
                    ${book._ownerId === userId
                    ? html`
                    <!-- Edit/Delete buttons ( Only for creator of this book )  -->
                    <a class="button" href="/edit/${book._id}">Edit</a>
                    <a class="button" href="" @click=${deleteHandler}>Delete</a>`
                    : nothing}
                    <!-- Bonus -->
                    <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
                    ${book._ownerId !== userId && userId !== undefined && !userLikedBook
                    ? html`<a class="button" href="" @click=${likeBtnHandler}>Like</a>`
                    : nothing}
                    <!-- ( for Guests and Users )  -->
                    <div class="likes">
                        <img class="hearts" src="/images/heart.png">
                        <span id="total-likes">Likes: ${likes}</span>
                    </div>
                    <!-- Bonus -->
                </div>
            </div>
            <div class="book-description">
                <h3>Description:</h3>
                <p>${book.description}</p>
            </div>
        </section>
`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage(context, next) {
    bookId = context.params.id;
    let user = JSON.parse(localStorage.getItem('user'));

    let userId = user !== null ? user._id : undefined;

    let likes = 0;

    getLikesOfBook(bookId).then(data => likes = data);
    getUserLikes(bookId).then(like => isNotLiked = like > 0 ? true : false).catch(err => alert(err));

    getOne(bookId).then(item => _render(detailsPageTemplate(item, userId, deleteHandler, likeBtnHandler, likes, isNotLiked)))
        .catch(err => alert(err));
}

const likeBtnHandler = () => {

    let book = {
        bookId
    }

    likesForBook(book).catch(err => alert(err));
}

const deleteHandler = () => {
    if (confirm('Are you sure you want to delete it ?')) {
        del(bookId);
        _router.redirect('/dashboard');
    }
}

export default {
    init,
    getPage,
}
import { logoutUser } from "../../requests/requests.js";

let _router;

function init(router) {
    _router = router;
}

function getPage() {

    logoutUser()
        .then(res => {
            return res;
        })
        .finally(() => {
            localStorage.clear();

            _router.redirect('/');

        });
}

export default {
    init,
    getPage,
}
import { postRequest } from "./requests.js";

export function formEventHandler(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    if (!formData.get('item')) {
        return;
    }

    let newText = {
        text: formData.get('item')
    }

    postRequest(newText);
    e.currentTarget.reset();
};
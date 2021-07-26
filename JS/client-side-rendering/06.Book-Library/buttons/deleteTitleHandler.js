import { deleteRequest } from "../requests/requests.js";
import { loadTitles } from "./loadTitlesHandler.js";

export const deleteTitle = (e) => {
    let titleId = e.target.closest('tr').id;
    
    deleteRequest(titleId);

    loadTitles();
};
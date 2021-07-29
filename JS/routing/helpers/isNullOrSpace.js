
export let isEmptyOrSpaces = (str) => {
    return str === null || str.match(/^ *$/) !== null;
}
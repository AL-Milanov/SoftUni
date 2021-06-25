function encodeAndDecodeMessages() {
    let textFieldsElements = Array.from(document.querySelectorAll('#main textarea'));
    let buttonsElements = Array.from(document.querySelectorAll('#main button'));

    buttonsElements[0].addEventListener('click', () => {
        let textToEncode = textFieldsElements[0].value;
        let encoded = '';

        for (let i = 0; i < textToEncode.length; i++) {
            let nextCharInAscii = textToEncode.charCodeAt(i) + 1;
            encoded += String.fromCharCode(nextCharInAscii);
        }

        textFieldsElements[1].textContent = encoded;
        textFieldsElements[0].value = '';
    });

    buttonsElements[1].addEventListener('click', () => {
        let texToDecode = textFieldsElements[1].textContent;
        let decoded = '';

        for (let i = 0; i < texToDecode.length; i++) {
            let nextCharInAscii = texToDecode.charCodeAt(i) - 1;
            decoded += String.fromCharCode(nextCharInAscii);
        }

        textFieldsElements[1].textContent = decoded;
    })
}
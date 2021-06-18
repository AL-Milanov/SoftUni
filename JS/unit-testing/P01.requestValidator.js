function solve(httpObj) {
    methodValidation(httpObj);
    uriValidation(httpObj);
    versionValidator(httpObj);
    messageValidator(httpObj);

    function methodValidation(httpObj) {
        let methodNames = ['GET', 'POST', 'DELETE', 'CONNECT'];
        let propertyName = 'method';

        if (httpObj[propertyName] === undefined || !methodNames.includes(httpObj[propertyName])) {
            throw new Error("Invalid request header: Invalid Method");
        }
    }

    function uriValidation(httpObj) {
        let uriRegex = /^\*$|^[a-zA-z0-9.]+$/;
        let propertyName = 'uri';

        if (httpObj[propertyName] === undefined || !uriRegex.test(httpObj[propertyName])) {
            throw new Error("Invalid request header: Invalid URI");
        }
    }

    function versionValidator(httpObj) {
        let versionNames = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
        let propertyName = 'version';

        if (httpObj[propertyName] === undefined || !versionNames.includes(httpObj[propertyName])) {
            throw new Error("Invalid request header: Invalid Version");
        }
    }

    function messageValidator(httpObj) {
        let messageRegex = /^[^<>\\&'"]*$/;
        let propertyName = 'message';

        if (httpObj[propertyName] === undefined || !messageRegex.test(httpObj[propertyName])) {
            throw new Error("Invalid request header: Invalid Message");
        }
    }

    return httpObj;
}

try {
    console.log(solve({
        method: 'CONNECT',
        uri: 'define apps',
        version: 'HTTP/2.0'
    }
    ));
} catch (e) {
    console.log(e.message);
}
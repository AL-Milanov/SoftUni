function extensibleObject() {
    let obj = {
        extend: function (template) {
            for (var key in template) {
                if (typeof (template[key]) === "function") {
                    Object.getPrototypeOf(obj)[key] = template[key];
                } else {
                    obj[key] = template[key];
                }
            }
        }
    }
    return obj;
}

const myObj = extensibleObject();

let template = {
    extensionMethod: function () {
        console.log("From extension method")
    }
};

let testObject = extensibleObject();
testObject.extend(template);
console.log(testObject);
console.log(testObject.extensionMethod());

function extensibleObject() {
    return {
        extend: function (template) {
            for (var key in template) {
                this[key] = template[key];
            }
            return this;
        }
    };
}

const myObj = extensibleObject();

var template = {
    extensionMethod: function () {
        console.log("From extension method")
    }
};

var testObject = extensibleObject();
testObject.extend(template);
console.log(testObject);
console.log(testObject.extensionMethod());

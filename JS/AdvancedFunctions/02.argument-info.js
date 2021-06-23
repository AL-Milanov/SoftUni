function solution(...args) {
    let result = [];

    function getTypes(element) {
        let elementType = typeof element;

        return `${elementType}: ${element}`;
    }

    args.forEach(e => result.push(getTypes.call(result, e)));

    let firstArgument = [];
    result.forEach(el => firstArgument.push(el = el.split(' ')[0].slice(0, -1)));

    let typeCounts = {};
    for (let i = 0; i < firstArgument.length; i++) {

        if (firstArgument[i] in typeCounts) {
            typeCounts[firstArgument[i]] += 1;
        } else {
            typeCounts[firstArgument[i]] = 1;
        }
    }

    let sortedTypesCount = [];

    for (const type in typeCounts) {
        sortedTypesCount.push([type, typeCounts[type]]);
    }

    sortedTypesCount.sort(function (a, b) {
        return b[1] - a[1];
    });
    sortedTypesCount.forEach(el => result.push(el.join(' = ')));

    return result;
}

console.log(solution('cat', 42, function () { console.log('Hello world!'); }));
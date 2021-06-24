function getArticleGenerator(articles) {

    return function showNext() {
        if (articles.length > 0) {
            let divElement = document.getElementById('content');
            let article = document.createElement('article');
            article.textContent = articles.shift();
            divElement.appendChild(article);
        }
    }
}

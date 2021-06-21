function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let result = `Post: ${this.title}\r\n`;
            result += `Content: ${this.content}`;
            return result;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this._likes = likes;
            this._dislikes = dislikes;
            this._comments = [];
        }

        addComment(comment) {
            this._comments.push(comment);
        }

        toString() {
            let result = super.toString();
            result += '\r\n';
            result += `Rating: ${this._likes} - ${this._dislikes}\r\n`;
            if (this._comments.length !== 0) {
                result += 'Comments:\n'
                this._comments.forEach(el => result += ` * ${el}\r\n`);
            }
            return result;
        }
    }

    class BlogPost extends Post{
        constructor(title, content){
            super(title, content);

            this._views = 0;
        }

        view(){
            this._views += 1;

            return this;
        }

        toString(){
            let result = super.toString();
            result += `\nViews: ${this.views}`;

            return result;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost,
    }
}

const classes = solve();
let post = new classes.BlogPost('Greetings', 'hello');
post.view();
post.view();
let x = post.view();
//post.addComment('supper');
//post.addComment('its');
//post.addComment('supp');
console.log(post.toString());
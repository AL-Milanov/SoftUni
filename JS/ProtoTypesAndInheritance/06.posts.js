function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let result = `Post: ${this.title}\n`;
            result += `Content: ${this.content}`;
            return result;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let baseToString = super.toString();
            let commentsString = this.comments.map(c => ` * ${c}`).join('\n');
            let fullCommentsString = this.comments.length > 0 
            ? `\nComments:\n${commentsString}`
            : '';
            return `${baseToString}
Rating: ${this.likes - this.dislikes}${fullCommentsString}`;
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);

            this.views = views;
        }

        view(){
            this.views += 1;
            return this;
        }

        toString(){
            let result = super.toString() + '\n';
            result += `Views: ${this.views}`;

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
let post = new classes.SocialMediaPost('Greetings', 'hello', 3, 3);
//post.view().view().view();
//post.addComment('supper');
post.addComment('its');
post.addComment('supp');
console.log(post.toString());
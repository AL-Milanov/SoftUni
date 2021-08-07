import { pageRender } from '../middleware/pageRender.js';
import page from '../node_modules/page/page.mjs';
import allMemes from './views/allMemes.js';
import create from './views/create.js';
import details from './views/details.js';
import edit from './views/edit.js';
import home from './views/home.js';
import login from './views/login.js';
import logout from './views/logout.js';
import myProfile from './views/myProfile.js';
import navigation from './views/navigation.js';
import register from './views/register.js';

let navigationElement = document.getElementById('navigation');
let mainElement = document.getElementById('main');

let navRender = pageRender(navigationElement);
let mainRender = pageRender(mainElement);

navigation.init(page, navRender);
home.init(page, mainRender);
login.init(page, mainRender);
register.init(page, mainRender);
logout.init(page);
allMemes.init(page, mainRender);
create.init(page, mainRender);
details.init(page, mainRender);
edit.init(page, mainRender);
myProfile.init(page, mainRender);

page(navigation.getPage);

page('/index.html', '/home');
page('/', '/home');

page('/home', home.getPage);
page('/login', login.getPage);
page('/register', register.getPage);
page('/logout', logout.getPage);
page('/all-memes', allMemes.getPage);
page('/create', create.getPage);
page('/all-memes/:id', details.getPage);
page('/edit/:id', edit.getPage);
page('/my-profile', myProfile.getPage);


page.start();
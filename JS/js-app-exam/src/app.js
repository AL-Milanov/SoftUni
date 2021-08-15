import { pageRender } from '../middleware/pageRender.js';
import page from '../node_modules/page/page.mjs';
import allCollections from './views/allCollections.js';
import create from './views/create.js';
import details from './views/details.js';
import edit from './views/edit.js';
import login from './views/login.js';
import logout from './views/logout.js';
import myProfile from './views/myProfile.js';
import navigation from './views/navigation.js';
import register from './views/register.js';


let navigationElement = document.getElementById('site-header');
let mainElement = document.getElementById('site-content');

let navRender = pageRender(navigationElement);
let mainRender = pageRender(mainElement);

navigation.init(page, navRender);
login.init(page, mainRender);
register.init(page, mainRender);
logout.init(page);
allCollections.init(page, mainRender);
create.init(page, mainRender);
details.init(page, mainRender);
edit.init(page, mainRender);
myProfile.init(page, mainRender);

page(navigation.getPage);

page('/index.html', '/dashboard');
page('/', '/dashboard');

page('/dashboard/:id', details.getPage);
page('/dashboard', allCollections.getPage);
page('/login', login.getPage);
page('/register', register.getPage);
page('/logout', logout.getPage);
page('/create', create.getPage);
page('/edit/:id', edit.getPage);
page('/my-profile', myProfile.getPage);


page.start();
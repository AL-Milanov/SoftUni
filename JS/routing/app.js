import page from "./node_modules/page/page.mjs";
import { myRenderer } from "./renderer/myRenderer.js";
import createFurniture from "./templates/createFurniture/createFurniture.js";
import dashboard from "./templates/dashboard/dashboard.js";
import details from "./templates/details/details.js";
import edit from "./templates/edit/edit.js";
import login from "./templates/login/login.js";
import logoutPage from "./templates/logout/logoutPage.js";
import myFurniture from "./templates/myFurnitures/myFurniture.js";
import navBar from "./templates/navBar.js";
import register from "./templates/register/register.js";

let navigation = document.querySelector('#navigation');
let viewContainer = document.querySelector('#viewContainer');

let navRenderer = myRenderer(navigation);
let viewContainerRenderer = myRenderer(viewContainer);

navBar.initialize(page, navRenderer);
dashboard.initialize(page, viewContainerRenderer);
login.initialize(page, viewContainerRenderer);
register.initialize(page, viewContainerRenderer);
logoutPage.initialize(page, viewContainerRenderer);
createFurniture.initialize(page, viewContainerRenderer);
details.initialize(page, viewContainerRenderer);
edit.initialize(page, viewContainerRenderer);
myFurniture.initialize(page, viewContainerRenderer);

page('*', navBar.loadPage);

page('/details/:id', details.loadPage);
page('/dashboard', dashboard.loadPage);
page('/login', navBar.loadPage, login.loadPage);
page('/register', navBar.loadPage, register.loadPage);
page('/logout', logoutPage.loadPage);
page('/create', createFurniture.loadPage);
page('/edit/:id', edit.loadPage);
page('/my-furniture', myFurniture.loadPage);

page('/', '/dashboard');
page('/index.html', '/dashboard');


page.start();
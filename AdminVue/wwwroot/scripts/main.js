var Vue = require('vue');
//var VueRouter = require('vue-router');
var axios = require('axios');


var App = require('./app.vue');
var Routes = require('./routes.js');

Vue.prototype.axios = axios;
//Vue.use(VueRouter);

//var router = new VueRouter({
//    routes: Routes,
//    mode: 'history'

//});

new Vue({
    el: '#app',
    //router: router,
    render: h => h(App)

});
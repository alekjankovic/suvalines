var Vue = require('vue');
var axios = require('axios');
var App = require('./app.vue');

Vue.prototype.axios = axios;


new Vue({
    el: '#app',
    render: h => h(App)
});
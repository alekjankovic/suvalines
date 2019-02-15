
module.exports = [
    {
        path: '/',
        component: require('./components/MainContainer.vue')
    },
    {
        path: '/category/:id',
        component: require('./components/Category.vue')
    },
    {
        path: '/article/:id',
        component: require('./components/Article.vue')
    },
    {
        path: '/search',
        component: require('./components/Search.vue')
    },
    {
        path: '/addnews',
        component: require('./components/AddNews.vue')
    }

];
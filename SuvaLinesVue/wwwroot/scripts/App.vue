﻿<template>

    <div>
        <siteheader></siteheader>

        <div id="main-app">
            <div class="page-main">
                <div class="main-container">
                    <div class="main-wrap">
                        <div class="main-section">
                            <main>
                                <router-view></router-view>
                            </main>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <sitefooter></sitefooter>
    </div>

</template>

<script>

    import SiteHeader from './components/SiteHeader.vue'
    import SiteFooter from './components/SiteFooter.vue'

    import MainContainer from './components/MainContainer.vue'
    import Category from './components/Category.vue'
    import Article from './components/Article.vue'
    import Search from './components/Search.vue'
    import AddNews from './components/AddNews.vue'


    export default {
        name: 'App',
        components: {
            'siteheader': SiteHeader,
            'sitefooter': SiteFooter,
            'maincontainer': MainContainer,
            'category': Category,
            'app-article': Article,
            'app-search': Search,
            'addnews':AddNews
        }
    }
</script>


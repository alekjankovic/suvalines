<template>

    <div class="page-header">
        <div class="header-container">

            <header class="header-top disp-flex">
                <router-link to="/" class="header-logo">
                    <img alt="News Lines" src="/img/logo_1.png" />
                    <h1>News Lines</h1>
                </router-link>
                <div class="header-top-tools">
                    <div name="header-search-form" class="header-search-form clearfix">
                        <input class="header-input-search" id="input-main-search" v-on:keyup.enter="getSearch" v-model="qSearch" >
                        <a class="header-search-button" v-on:click.prevent="getSearch">
                            <i class="fa fa-search"></i>
                        </a>
                    </div>
                </div>
            </header>

            <div class="header-bottom">
                <nav class="main-navigation">
                    <ul class="main-navigation-list clearfix">
                        <li><router-link to="/" exact><strong>Home</strong></router-link></li>
                        <li><router-link to="/category/10007" exact><strong>World</strong></router-link></li>
                        <li><router-link to="/category/10005" exact><strong>Politics</strong></router-link></li>
                        <li><router-link to="/category/10006" exact><strong>Business</strong></router-link></li>
                        <li><router-link to="/category/10008" exact><strong>Sports</strong></router-link></li>
                        <li><router-link to="/category/10009" exact><strong>Tech</strong></router-link></li>
                        <li><router-link to="/category/10010" exact><strong>Health</strong></router-link></li>
                    </ul>
                </nav>
            </div>

        </div>
    </div>


</template>

<script>
    export default {
        data: function () {
            return {
                qSearch:""
            }
        },
        methods: {
            getSearch() {
                var qstr = this.qSearch;
                if (qstr != "") {
                    debugger;
                    this.$router.push({
                        path: '/search',
                        query: {
                            qstr: qstr
                        }
                    });
                }

            }

        }



    }
</script>
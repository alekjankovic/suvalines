<template>

    <div class="page-header">
        <div class="header-container">

            <header class="header-top disp-flex">
                <a href="/" class="header-logo">
                    <img alt="News Lines" src="/img/logo_1.png" />
                    <h1>News Lines</h1>
                </a>
                <div class="header-top-tools">
                    <div name="header-search-form" class="header-search-form clearfix">
                        <input class="header-input-search" id="input-main-search">
                        <a class="header-search-button" href="javascript:void(0)">
                            <i class="fa fa-search"></i>
                        </a>
                    </div>
                </div>
            </header>

            <div class="header-bottom">
                <nav class="main-navigation">
                    <ul class="main-navigation-list clearfix">
                        <li><a href="/"><strong>Home</strong></a></li>
                        <li><a href="Category?id=10007"><strong>World</strong></a></li>
                        <li><a href="Category?id=10005"><strong>Politics</strong></a></li>
                        <li><a href="Category?id=10006"><strong>Business</strong></a></li>
                        <li><a href="Category?id=10008"><strong>Sports</strong></a></li>
                        <li><a href="Category?id=10009"><strong>Tech</strong></a></li>
                        <li><a href="Category?id=10010"><strong>Health</strong></a></li>
                    </ul>
                </nav>
            </div>

        </div>
    </div>


</template>

<script>
    export default {
    }
</script>
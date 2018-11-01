<template>
    <section class="news-list">
        <ul>
            <li v-for="item in newsList" v-bind:id="'news_li_' + item.articleId">
                <h2>
                    <a v-bind:href="'Article?id=' + item.articleId"><strong>{{item.longTitle}}...</strong></a>
                    <img class="" alt="news_1" v-bind:src="item.imgUrl" />
                </h2>
            </li>
        </ul>
    </section>
</template>


<script>
    export default {
        data: function () {
            return {
                newsList: "",
            }
        },
        mounted() {
            this.getMainNewsList();
        },
        methods: {
            getMainNewsList() {
                this.axios
                    .get('api/mainnewslist')
                    .then(response => {
                        this.newsList = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
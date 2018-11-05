<template>

    <div class="news-article">

        <h1>{{article.title}}</h1>
        <p>
           {{article.articleText}}
        </p>

    </div>

</template>


<script>

    export default {
        data() {
            return {
                id: this.$route.params.id,
                article: {}
            }
        },
        mounted() {
            this.getArticle(this.id);
        },
        methods: {
            getArticle(artId) {
                this.axios
                    .get('/api/article?id=' + artId)
                    .then(response => {
                        this.article = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
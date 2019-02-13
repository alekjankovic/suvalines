<template>
    <section class="breaking-news-line">
        <div class="breaking-news-icon">NEW</div>
        <div class="breaking-news-titles">
            <router-link  v-for="item in breakingNews" v-bind:to="'/article/' + item.articleId" v-bind:title="item.LongTitle" exact>{{item.longTitle}}</router-link>           
        </div>
    </section>
</template>

<script>
    export default {
        data: function () {
            return {
                breakingNews: "",
            }
        },
        mounted() {
            this.getBreakingNews();
        },
        methods: {
            getBreakingNews() {
                this.axios
                    .get('api/breakingnews')
                    .then(response => {
                        this.breakingNews = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
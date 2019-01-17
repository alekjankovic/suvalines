<template>

    <div class="news-article" v-bind:data-id="article.articleId">

        <h1>{{article.title}}</h1>
        <p>
           {{article.articleText}}
        </p>

        <div class="comments-area">
            <div class="comments-header">Post a comment</div>

            <form v-on:submit.prevent="postComment($event)" class="comments-form">
                <input v-model="postData.Username" class="comment-user" type="text" name="user" />
                <textarea v-model="postData.CommentText" class="comment-text" name="comment"></textarea>
                <button class="comment-submit" type="submit">Post</button>
            </form>

            <div class="comments-header">Comments</div>

            <div class="comment-list-cont">
                <div class="comment-cont" v-for="item in article.comments">
                    <div>{{ item.username}}</div>
                    <p> {{item.commentText}}  </p>
                </div>
            </div>
        </div>
               
    </div>

</template>


<script>

    export default {
        data() {
            return {
                id: this.$route.params.id,
                article: {},
                postData: {
                    Username: "",
                    CommentText: ""
                }
            }
        },
        mounted() {
            this.getArticle();
        },
        methods: {
            getArticle() {
                debugger;
                this.axios
                    .get('/api/article?id=' + this.id)
                    .then(response => {
                        console.log(response);
                        this.article = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            },
            postComment(e) {
                this.postData.ArticleId = this.article.articleId;

                this.axios({
                    url: '/api/postarticle',
                    method: 'post',
                    params: this.postData
                }).then((response) => {
                    debugger;
                    this.getArticle();
                    this.postData = {};
                    console.log(response);
                    }
                ).catch(function (response) {
                    console.log(response);
                });  
            }
        }
    }
</script>
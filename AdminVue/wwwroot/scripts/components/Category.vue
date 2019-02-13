<template>

    <div class="category-container">

        <ul>
            <li v-for="item in catnews" style="display:block;">
                <h2>
                    <router-link v-bind:to="'/article/' + item.articleId" exact>
                        <img v-bind:src="item.imgUrl" v-bind:alt="item.Title" />
                        <span>{{item.longTitle}}</span>
                    </router-link>
                </h2>
            </li>
        </ul>
    </div>

</template>


<script>

    export default {
        data() {
            return {
                id: this.$route.params.id,
                catnews: {}
            }
        },
        mounted() {
            this.getNewsByCategory(this.id);
        },
        methods: {
            getNewsByCategory(artId) {
                this.axios
                    .get('/api/category?id=' + artId)
                    .then(response => {
                        this.catnews = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
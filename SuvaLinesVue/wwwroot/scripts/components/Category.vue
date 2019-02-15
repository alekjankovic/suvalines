<template>

    <div class="category-container">
        <h1>{{id}}</h1>

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
        watch: {
            '$route'(to, from) {
                debugger;
                this.id = to.params.id;
                this.getNewsByCategory();
            }
        },
        mounted() {
            this.getNewsByCategory();
        },
        methods: {
            getNewsByCategory() {
                console.log("Reload");
                this.axios
                    .get('/api/category?id=' + this.id)
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
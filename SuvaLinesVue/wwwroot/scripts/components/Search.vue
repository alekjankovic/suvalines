<template>

    <div class="category-container">
        <h1>Search results for: "{{qSearch}}"</h1>

        <ul>
            <li v-for="item in searchList" style="display:block;">
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
                qSearch: this.$route.query.qstr,
                searchList: {}
            }
        },
        mounted() {
            this.getSearch();
        },
        methods: {
            getSearch() {
                this.axios
                    .get('/api/search?qsearch=' + this.qSearch)
                    .then(response => {
                        this.searchList = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
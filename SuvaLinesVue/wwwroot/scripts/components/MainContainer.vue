<template>

    <div id="main-app">
        <div class="page-main">
            <div class="main-container">
                <div class="main-wrap">

                    <div class="main-section">
                        <main>

                            <newslist></newslist>
                           


                        </main>
                    </div>

                </div>
            </div>

        </div>

    </div>

</template>


<script>

    import NewsList from './NewsList.vue'

    export default {
        components: {
            'newslist': NewsList
        },
        methods: {



        }

    }
</script>
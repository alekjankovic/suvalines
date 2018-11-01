<template>

    <div id="main-app">
        <div class="page-main">
            <div class="main-container">
                <div class="main-wrap">

                    <div class="main-section">
                        <main>
                            <newslist></newslist>                           
                            <breakingnews></breakingnews>
                            <secondlines></secondlines>
                        </main>
                    </div>

                </div>
            </div>

        </div>

    </div>

</template>


<script>

    import NewsList from './NewsList.vue'
    import BreakingNews from './BreakingNews.vue'
    import SecondLines from './SecondLines.vue'

    export default {
        components: {
            newslist: NewsList,
            breakingnews: BreakingNews,
            secondlines: SecondLines
        },
        methods: {



        }

    }
</script>
<template>

    <div>
        <newslist></newslist>
        <breakingnews></breakingnews>
        <secondlines></secondlines>
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
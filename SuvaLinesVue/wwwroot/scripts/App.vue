<template>

    <div>
        <siteheader></siteheader>
        <maincontainer></maincontainer>
        <sitefooter></sitefooter>




    </div>

</template>

<script>

    import SiteHeader from './components/SiteHeader.vue'
    import MainContainer from './components/MainContainer.vue'
    import SiteFooter from './components/SiteFooter.vue'

    export default {
        name: 'App',
        components: {
            'siteheader': SiteHeader,
            'maincontainer': MainContainer,
            'sitefooter': SiteFooter
        }
    }
</script>


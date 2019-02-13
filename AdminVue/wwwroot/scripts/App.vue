<template>
    <div>
        <sidebar></sidebar>
        <siteheader></siteheader>
    </div>
</template>

<script>
    import Sidebar from './components/Sidebar.vue'
    import SiteHeader from './components/SiteHeader.vue'

    export default {
        name: 'App',
        components: {
            'sidebar': Sidebar, 
            'siteheader': SiteHeader
        }
    }
</script>


﻿<template>
    <section class="second-line clearfix">
        <div class="sec-block" v-for="(value, propertyName) in secLines">
            <div class="sec-block-area">
                <span>{{value[0].group.name}}</span>
            </div>
            <div class="sec-content">
                <div class="sec-line">
                    <h4 v-for="item in value">
                        <router-link v-bind:to="'/article/' + item.AaticleId" exact>
                            <img v-bind:src="item.imgUrl" />
                            <span>{{item.title}}</span>
                        </router-link>
                    </h4>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
    export default {
        data: function () {
            return {
                secLines: "",
            }
        },
        mounted() {
            this.getSecLines();
        },
        methods: {
            getSecLines() {
                this.axios
                    .get('api/seclines')
                    .then(response => {
                        this.secLines = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
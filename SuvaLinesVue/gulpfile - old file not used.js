/// <binding BeforeBuild='sass:prod, sass:dev, js:prod, js:dev, vue:dev' ProjectOpened='watch' />
'use strict';
const gulp = require('gulp');

const sass = require('gulp-sass-glob');
const cssnano = require('gulp-cssnano');

const vueloader = require("vue-loader");
const vueify = require('gulp-vueify2');
const babel = require('gulp-babel');

const webpack = require('webpack-stream');
const VueLoaderPlugin = require('vue-loader/lib/plugin');


var wbm = {
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            // this will apply to both plain `.js` files
            // AND `<script>` blocks in `.vue` files
            {
                test: /\.js$/,
                loader: 'babel-loader'
            },
            // this will apply to both plain `.css` files
            // AND `<style>` blocks in `.vue` files
            //{
            //    test: /\.css$/,
            //    use: [
            //        'vue-style-loader',
            //        'css-loader'
            //    ]
            //}
        ]
    },
    plugins: [
        // make sure to include the plugin for the magic
        new VueLoaderPlugin()
    ],
    //resolve: {
    //    alias: {
    //        'vue$': 'vue/dist/vue.esm.js'
    //    },
    //    extensions: ['*', '.js', '.vue', '.json']
    //}
};

const rename = require('gulp-rename');

const plumber = require('gulp-plumber');
const notify = require('gulp-notify');


const stylesPath = 'wwwroot/styles/*.scss';
const scriptsPath = 'wwwroot/scripts/*.js';
//const componentsPath = 'wwwroot/scripts/*.vue';


/**
 * CSS Processing
 * */
// Production Only
gulp.task('sass:prod', () => {
    return gulp.src(stylesPath)
        .pipe(sass())
        .pipe(cssnano())
        .pipe(rename('site.min.css'))
        .pipe(gulp.dest('wwwroot/css'));
});

//Development Only
gulp.task('sass:dev', () => {
    return gulp.src(stylesPath)
        .pipe(plumber({
            errorHandler(err) {
                notify.onError({
                    title: `Gulp error in ${err.plugin}`,
                    message: err.toString()
                })(err);
            }
        }))
        .pipe(sass())
        .pipe(rename('site.css'))
        .pipe(gulp.dest('wwwroot/css'));
});

/**
 * JS Processing
 * */
// Production Only
gulp.task('js:prod', () => {
    gulp.src(scriptsPath)
        .pipe(webpack({
            mode: 'production'
        }))
        .pipe(babel({
            presets: ['@babel/env']
        }))
        .pipe(rename('site.min.js'))
        .pipe(gulp.dest('wwwroot/js'));
});
// Development only
gulp.task('js:dev', () => {
    gulp.src(scriptsPath)
        .pipe(plumber({
            errorHandler(err) {
                notify.onError({
                    title: `Gulp error in ${err.plugin}`,
                    message: err.toString()
                })(err);
            }
        }))
        .pipe(webpack(wbm))
        //.pipe(babel({
        //    presets: ['@babel/env']
        //}))
        .pipe(rename('site.js'))
        .pipe(gulp.dest('wwwroot/js'));
});



gulp.task('watch', () => {
    gulp.watch(stylesPath, ['sass:dev']);
    gulp.watch(scriptsPath, ['js:dev']);
});

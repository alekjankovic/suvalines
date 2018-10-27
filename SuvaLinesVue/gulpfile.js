/// <binding BeforeBuild='sass:prod, sass:dev, js:prod, js:dev, vue:dev' ProjectOpened='watch' />
'use strict';
const gulp = require('gulp');

const sass = require('gulp-sass-glob');
const cssnano = require('gulp-cssnano');

const vue-loader = require("vue-loader");
const vueify = require('gulp-vueify2');
const babel = require('gulp-babel');
const webpack = require('webpack-stream');

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
        .pipe(webpack({
            mode: 'development',
            loader: 'vue-loader'
        }))
        .pipe(babel({
            presets: ['@babel/env']
        }))
        .pipe(rename('site.js'))
        .pipe(gulp.dest('wwwroot/js'));
});



gulp.task('watch', () => {
    gulp.watch(stylesPath, ['sass:dev']);
    gulp.watch(scriptsPath, ['js:dev']);
});


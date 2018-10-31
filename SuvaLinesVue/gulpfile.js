/// <binding BeforeBuild='sass:prod, sass:dev, js:prod, js:dev, vue:dev' ProjectOpened='watch' />
'use strict';
const gulp = require('gulp');

const sass = require('gulp-sass-glob');
const cssnano = require('gulp-cssnano');

const fs = require("fs");
const vueify = require("vueify");
const browserify = require("browserify");

const rename = require('gulp-rename');

const plumber = require('gulp-plumber');
const notify = require('gulp-notify');


const stylesPath = 'wwwroot/styles/*.scss';
const scriptsPath = 'wwwroot/scripts';


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
gulp.task("vueify", function () {
    return browserify('wwwroot/scripts/main.js')
        .transform(vueify)
        .bundle()
        .pipe(fs.createWriteStream("wwwroot/js/site.js"));
});


gulp.task('watch', () => {
    gulp.watch(stylesPath, ['sass:dev']);
    gulp.watch('wwwroot/scripts/main.js' , ['vueify']);
    gulp.watch('wwwroot/scripts/*.vue', ['vueify']);
    gulp.watch('wwwroot/scripts/components/*.vue', ['vueify']);
});

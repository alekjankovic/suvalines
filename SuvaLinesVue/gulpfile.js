/// <binding BeforeBuild='css:prod, js:prod' ProjectOpened='watch' />
'use strict';
const gulp = require('gulp');
const babel = require('gulp-babel');
const plumber = require('gulp-plumber');
const notify = require('gulp-notify');
const concat = require('gulp-concat');
const uglify = require('gulp-uglify');
const rename = require('gulp-rename');
const webpack = require('webpack-stream');


const scriptsPath = 'wwwroot/scripts/*.js';
const stylesPath = 'wwwroot/css/*.css';

/**
 * CSS Processing
 * */
// Production Only
gulp.task('css:prod', () => {
    return gulp.src(stylesPath)
        .pipe(concat('site-all.css'))
        .pipe(gulp.dest('wwwroot/css/dist'));
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
        .pipe(uglify())
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
            mode: 'development'
        }))
        .pipe(rename('site.js'))
        .pipe(gulp.dest('wwwroot/js'));
});


gulp.task('watch', () => {
    gulp.watch(stylesPath, ['css:dev']);
    gulp.watch(scriptsPath, ['js:dev']);
});


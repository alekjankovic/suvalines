/// <binding BeforeBuild='sass:prod, sass:dev, js:prod, js:dev' ProjectOpened='watch' />
'use strict';
const gulp = require('gulp');
const sass = require('gulp-sass-glob');
const postcss = require('gulp-postcss');
const autoprefixer = require('autoprefixer');
const cssnano = require('cssnano');
const rename = require('gulp-rename');
const babel = require('gulp-babel');
const uglify = require('gulp-uglify');
const webpack = require('webpack-stream');
const plumber = require('gulp-plumber');
const notify = require('gulp-notify');


const scriptsPath = 'wwwroot/scripts/*.js';
const stylesPath = 'wwwroot/styles/*.scss';

/**
 * CSS Processing
 * */
// Production Only
gulp.task('sass:prod', () => {
    const plugins = [
        autoprefixer({ browsers: ['>0.25%'] }),
        cssnano
    ];
    return gulp.src(stylesPath)
        .pipe(sass())
        .pipe(postcss(plugins))
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
    gulp.watch(stylesPath, ['sass:dev']);
    gulp.watch(scriptsPath, ['js:dev']);
});


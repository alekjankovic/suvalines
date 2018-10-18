var gulp = require('gulp');
var concat = require('gulp-concat');

//Logs Message

gulp.task('Ini', function () {
    return console.log('Gulp is running...');
});


gulp.task('conc-js', function () {
    return gulp.src('wwwroot/js/*.js')
        .pipe(concat('all.js'))
        .pipe(gulp.dest('wwwroot/js/dist/'));

});


gulp.task('start', function () {
    gulp.start(['Ini', 'conc-js']);
});
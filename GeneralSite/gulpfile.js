/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

gulp.task('default', function () {
    // place code for your default task here
    return gulp.src('wwwroot/css/main.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});
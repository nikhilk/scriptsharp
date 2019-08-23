const buildify = require("buildify");
const fs = require('fs');

const concatFilesDir = "./src/System";

function getFiles(dir, files) {
    files = files || [];
    var foundFiles = fs.readdirSync(dir);
    for (var i in foundFiles) {
        var name = dir + '/' + foundFiles[i];
        if (fs.statSync(name).isDirectory()) {
            getFiles(name, files);
        } else {
            files.push(name);
        }
    }
    return files;
}

getFiles(concatFilesDir).forEach(file => {
    console.log(file);
});

buildify()
    .concat(
        getFiles(concatFilesDir, [
            './src/TypeSystem.js'
        ]), '\r\n')
    .wrap('src/Loader.js', {
        version: process.env['version']
    })
    .perform(function (content) {
        return content.replace(/[\ufeff]/g, '');
    })
    .save('dist/ss.js')
    .uglify()
    .save('dist/ss.min.js');

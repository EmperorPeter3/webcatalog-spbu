module.exports = function (grunt) {

    grunt.initConfig({
       

        uglify: {
            "StudyCatalogAngular": {
                files: {
                    "./Content/Scripts/app.js": [
                        "./Scripts/app.js",
                        "./Scripts/Controllers/studyCatalogController.js",
                        "./Scripts/Services/studyCatalogServices.js"
                        ]
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.registerTask("default", ["uglify"]);

};
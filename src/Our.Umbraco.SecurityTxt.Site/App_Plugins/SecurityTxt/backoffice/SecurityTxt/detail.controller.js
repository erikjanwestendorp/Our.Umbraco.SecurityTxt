(function () {
    "use strict";

    function robotsTxtDetailController($scope) {

        function init() {
            console.log("init");
        }

        init();
    }

    angular.module("umbraco").controller("Security.SecurityTxt.DetailController", robotsTxtDetailController);
})();
(function () {
    "use strict";

    function securityTxtDetailController($scope, $http) {

        var vm = this;

        vm.model = "";
        vm.loading = false;

        function init() {
            vm.loading = true;
            $http.get("backoffice/SecurityTxt/SecurityTxt/Get").then(function (response) {
                vm.model = response.data;
                vm.loading = false;
            });
        }

        init();
    }

    angular.module("umbraco").controller("Security.SecurityTxt.DetailController", securityTxtDetailController);
})();
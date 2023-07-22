(function () {
    "use strict";

    function securityTxtDetailController($scope, $http, notificationsService, formHelper) {

        var vm = this;

        vm.model = "";
        vm.loading = false;
        vm.save = save;

        function save() {
            console.log(vm.model);
            $http.post("backoffice/SecurityTxt/SecurityTxt/Save",
                {
                    content: vm.model
                }).then(function (response) {
                    notificationsService.success("Security.txt saved!");
                    vm.model = response.data;
                    formHelper.resetForm({ scope: $scope });
                }, function () {
                    notificationsService.error("Something went wrong while saving Security.txt");
                });
        }

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
(function () {
    'use strict';

    function homeController($scope, identity) {
        var vm = this;

        $scope.identity = identity;
        vm.is = identity.isAuthenticated();
    }

    angular.module('myApp.controllers')
        .controller('HomeController', ['$scope', 'identity', homeController]);
}());
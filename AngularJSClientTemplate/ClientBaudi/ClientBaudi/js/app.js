(function () {
    'use strict';

    var VIEW_MODEL_NAME = 'vm';

    var routeResolvers = {
        authenticationRequired: {
            authenticate: ['$q', 'identity', function ($q, identity) {
                if (identity.isAuthenticated()) {
                    return true;
                }

                return $q.reject('not authorized');
            }]
        }
    };

    function config($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeController',
                controllerAs: VIEW_MODEL_NAME
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'RegisterController',
                controllerAs: VIEW_MODEL_NAME
            })
            .otherwise({ redirectTo: '/partial1' });
    }

    var run = function run($rootScope, $location) {

        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                $location.path('/unauthorized');
            }
        });
    };

    angular.module('myApp.services', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'myApp.controllers'])
        .config(['$routeProvider', config])
        .run(['$rootScope', '$location', run])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://localhost:56571');
}());
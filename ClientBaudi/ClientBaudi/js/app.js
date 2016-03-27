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
            .when('/cars', {
                templateUrl: 'views/partials/cars.html',
                controller: 'CarsController',
                controllerAs: VIEW_MODEL_NAME
            })
            .when('/cars/create', {
                templateUrl: 'views/partials/addCar.html',
                controller: 'CarsController',
                controllerAs: VIEW_MODEL_NAME,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/notfound', {
                template: '<img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNMaKqus470hQutcg6fwSSCW-UC8EE2mNsJEeg0Jyx17m4H8ppbw" alt="Page was not found!" class="img-responsive center-block" />'
            })
            .when('/unauthorized', {
                template: '<img src="http://images.mysafetysign.com/img/lg/S/no-unauthorized-entry-warning-sign-s-0061.png" alt="You are not authorized!" class="img-responsive center-block" />'
            })
            .otherwise({ redirectTo: '/notfound' });
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
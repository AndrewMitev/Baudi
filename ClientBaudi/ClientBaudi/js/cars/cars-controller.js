(function () {
    'use strict';

    function carsController(notifier, identity, cars) {
        var vm = this;

        vm.identity = identity;

        vm.request = {
            page: 1
        };

        vm.prevPage = function () {
            if (vm.request.page == 1) {
                return;
            }

            vm.request.page--;
            vm.filterCars();
        }

        vm.nextPage = function () {

            vm.request.page++;
            vm.filterCars();
        }

        vm.filterCars = function () {
            cars.filterCars(vm.request)
             .then(function (filteredCars) {
                 var previousCars = vm.filteredCars;
                 vm.filteredCars = filteredCars;

                 if (!vm.filteredCars || vm.filteredCars.length == 0)
                 {
                     vm.filteredCars = previousCars;
                     vm.request.page--;
                 }
             });
        }

        cars.getAll()
            .then(function (allCars) {
                vm.filteredCars = allCars;
            });

        vm.createCar = function (car) {
            cars.addCar(car)
                .then(function () {
                    notifier.success('Car added successfully!');
                },
                function (error) {
                });
        };
    }

    angular.module('myApp.controllers')
        .controller('CarsController', ['notifier', 'identity', 'cars', carsController]);
}());
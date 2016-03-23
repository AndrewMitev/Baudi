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
            if (!vm.filteredCars || vm.filteredCars.length == 0) {
                return;
            }

            vm.request.page++;
            vm.filterCars();
        }

        vm.filterCars = function () {
            cars.filterCars(vm.request)
             .then(function (filteredCars) {
                 vm.filteredCars = filteredCars;
             });
        }

        cars.getAll()
            .then(function (allCars) {
                vm.filteredCars = allCars;
                console.log(allCars);
            });

        vm.createCar = function (car) {
            console.log(car);
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
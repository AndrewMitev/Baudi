(function () {
    'use strict';

    function cars(data) {

        function getAll() {
            return data.get('api/cars?pageSize=5');
        }

        function addCar(car) {
            return data.post('api/cars', car);
        }

        function filterCars(request) {
            //TODO: Change logic here!
            var brandQuery = '&brand=' + request.brand;

            if (request.orderBy == 'price' && request.orderType == 'asc') {
                return data.get('api/cars/filteredByPriceLow?page=' + request.page + '&pageSize=5' + brandQuery);
            }

            if (request.orderBy == 'price' && request.orderType == 'desc') {
                return data.get('api/cars/filteredByPriceHigh?page=' + request.page + '&pageSize=5' + brandQuery);
            }

            if (request.orderBy == 'year' && request.orderType == 'asc') {
                return data.get('api/cars/filteredByYearOldest?page=' + request.page + '&pageSize=5' + brandQuery);
            }

            if (request.orderBy == 'year' && request.orderType == 'desc') {
                return data.get('api/cars/filteredByYearNewest?page=' + request.page + '&pageSize=5' + brandQuery);
            }
        }

        return {
            filterCars: filterCars,
            getAll: getAll,
            addCar: addCar
        };
    }

    angular.module('myApp.services')
        .factory('cars', ['data', cars]);
}());
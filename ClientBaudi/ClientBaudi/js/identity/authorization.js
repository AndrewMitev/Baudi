(function () {
    'use strict';

    function authorization(identity) {
        return {
            getAuthorizationHeader: function () {
                if (identity.isAuthenticated()) {
                    return {
                        'Authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                    }
                }
                else {
                    return undefined;
                }
            }
        }
    }

    angular.module('myApp.services')
        .factory('authorization', ['identity', authorization]);
}());
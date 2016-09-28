'use strict';
app.controller('productCadController', ['$scope', 'productsService', '$location', function ($scope, productsService, $location) {
    $scope.product = {};

    $scope.close = function () {        
        $location.path('/products');
    }
}]);
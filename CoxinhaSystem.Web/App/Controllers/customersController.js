'use strict';
app.controller('customersController', ['$scope', 'customersService', '$location', 'commonLibService',
    function ($scope, customersService, $location, commonLibService) {

        //Variavel para filtrar busca de Clientes
        $scope.filterCustomer = '';        

        //Adquirindo clientes
        $scope.loadCustomers = function () {
            customersService.getCustomers()
            .success(function (result) {
                //commonLibService.sortJsonArrayByProperty(result, 'name');
                $scope.customers = result;
            });
        }
        

        //Abre tela de novo Cliente
        $scope.openNewCustomer = function () {
            $location.path('/customerCad');
        };
    }]);
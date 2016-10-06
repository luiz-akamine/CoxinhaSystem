'use strict';
app.controller('customerCadController', ['$scope', 'customersService', '$location', '$routeParams', 'showAndHideService', '$timeout', 'commonLibService', '$http',
function ($scope, customersService, $location, $routeParams, showAndHideService, $timeout, commonLibService, $http) {

    //objeto do cliente
    $scope.customer = {};
    $scope.customer.addresses = [];
    $scope.customer.phones = [];

    //Controle do carregamento do cep
    var autoLoadCep = true;

    //Verificando se é edição
    if ($routeParams.customerId) {
        customersService.getCustomer($routeParams.customerId)
        .success(function (result) {
            autoLoadCep = false;            
            $scope.customer = result;
            //Tratando cep do banco
            if ($scope.customer.addresses.length > 0) {
                $scope.customer.addresses[0].cep = commonLibService.getCepFormated(result.addresses[0].cep);
            }            
            autoLoadCep = true;
        });
    }
    else {
        //foco no primeiro input
        commonLibService.setFocusInFirstInput();
    };

    //msg de erro
    $scope.error = '';

    //Salva cliente
    $scope.saveCustomer = function () {
        
        try {
            //Tratando cep para envio para o banco
            if ($scope.customer.addresses.length > 0) {
                if ($scope.customer.addresses[0].cep) {
                    $scope.customer.addresses[0].cep = commonLibService.getCepToDB($scope.customer.addresses[0].cep);
                }
            }            

            //checando se é novo cliente ou alteração
            if ($routeParams.customerId) {                
                customersService.updateCustomer($scope.customer)
                .success(function () {
                    //Exibir msg de OK e voltar para tela de Clientes
                    $location.path('/customers');
                })
                .error(function (err) {
                    $scope.error = err;
                });
            }
            else {
                customersService.saveNewCustomer($scope.customer)
                .success(function () {
                    //Exibir msg de OK e voltar para tela de Clientes
                    $location.path('/customers');
                })
                .error(function (err) {
                    $scope.error = err;
                });
            }
        }
        catch (e) {
            console.log(e);
            $scope.error = e.message;
        }
    };

    //Exibe alerta de erro e desaparece depois de 3 segundos
    $scope.$watch('error', function () {
        if ($scope.error) {
            $scope.msgErr = showAndHideService(3000);

            $timeout(function () {
                $scope.error = '';
            }, 3000);
        }
    });

    //Carrega cep
    $scope.loadCep = function (cep) {
        if ((cep) && (cep.length >= 8) && (autoLoadCep)) {            
            commonLibService.getAddressFromCep(cep)
            .success(function (result) {                
                $scope.customer.addresses[0] = commonLibService.parseToCepDB(result, $scope.customer.addresses[0]);
                if ($scope.customer.addresses[0].cep) {
                    jq('#addressnumber').focus();
                }
            });
        }
    };

    //Botão voltar
    $scope.close = function () {
        $location.path('/customers');
    };
}]);
'use strict';
app.controller('productCadController', ['$scope', 'productsService', '$location', 'ngProductTypes', 'ngUnit', '$routeParams', 'showAndHideService', '$timeout', 'commonLibService',
function ($scope, productsService, $location, ngProductTypes, ngUnit, $routeParams, showAndHideService, $timeout, commonLibService) {

    //objeto do produto
    $scope.product = {};

    //Verificando se é edição
    if ($routeParams.productId) {
        productsService.getProduct($routeParams.productId)
        .success(function (result) {
            $scope.product = result;
        });
    }
    else {
        //foco no primeiro input
        commonLibService.setFocusInFirstInput();
    };

    //msg de erro
    $scope.error = '';

    //tipos de produto
    $scope.productTypes = [
        { number: ngProductTypes.Cake, description: 'Bolo' },
        { number: ngProductTypes.Frie, description: 'Fritura' },
        { number: ngProductTypes.Roast, description: 'Assado' },
        { number: ngProductTypes.Sweet, description: 'Doce' }
    ];

    //unidades
    $scope.units = [
        { number: ngUnit.UN, description: 'UN' },
        { number: ngUnit.KG, description: 'KG' }
    ];


    //Salva produto
    $scope.saveProduct = function () {
        try {
            //checando se é novo produto ou alteração
            if ($routeParams.productId) {
                productsService.updateProduct($scope.product)
                .success(function () {
                    //Exibir msg de OK e voltar para tela de Produtos
                    $location.path('/products');
                })
                .error(function (err) {
                    $scope.error = err;
                });
            }
            else {               
                productsService.saveNewProduct($scope.product)
                .success(function () {
                    //Exibir msg de OK e voltar para tela de Produtos
                    $location.path('/products');
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

    //Botão voltar
    $scope.close = function () {        
        $location.path('/products');
    }
}]);
'use strict';
app.controller('productsController', ['$scope', 'productsService', '$location', 'commonLibService',
    function ($scope, productsService, $location, commonLibService) {
    
    //Variavel para filtrar busca de produtos
    $scope.filterProduct = '';

    //Variavel para controle de click de registro no grid
    $scope.productCheck = false;

    //Adquirindo produtos
    $scope.loadProducts = function () {        
        productsService.getProducts()
        .success(function (result) {
            //commonLibService.sortJsonArrayByProperty(result, 'name');
            $scope.products = result;
        });
    }

    //Retorna unidade do produto
    $scope.getUnit = function (unitNumber) {
        return productsService.getUnit(unitNumber);
    }

    //Retorna tipo do produto
    $scope.getProductType = function (prodTypeNumber) {        
        return productsService.getProductType(prodTypeNumber);
    }

    //Verifica se há produto selecionado
    $scope.anyProductIsSelected = function () {
        if ($scope.products != null){
            return $scope.products.some(function (product) {
                return product.selected;
            });
        }
    };

    //Seleciona um único registro de produto no grid
    $scope.selectProduct = function (position, products) {
        //deselecionando outros registros
        angular.forEach(products, function (product, index) {
            if (position != index)
                product.selected = false;
        });
    };

    //Abre tela de novo Produto    
    $scope.openNewProduct = function () {
        $location.path('/productCad');
    };
}]);
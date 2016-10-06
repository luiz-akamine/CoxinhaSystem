//Serviço com métodos relacionados a entidade de Pedidos
'use strict';
app.factory('productsService', ['$http', 'ngCoxinhaSettings', 'ngUnit', 'ngProductTypes', function ($http, ngCoxinhaSettings, ngUnit, ngProductTypes) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngCoxinhaSettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var productsServiceFactory = {};

    //Método que retorna lista completa de Produtos
    var _getProducts = function () {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/product')
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir produtos. Status: ' + status);
                alert('erro ao adquirir produtos');
            });
    };

    //Método que retorna um Produto específico
    var _getProduct = function (productId) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/product?id=' + productId)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir produto. Status: ' + status);
                alert('erro ao adquirir produto');
            });
    };

    //Método que retorna lista completa de Produtos por Tipo
    var _getProductsByType = function (productType) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/product/GetByType?productType=' + productType)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir produtos por tipo. Status: ' + status);
                alert('erro ao adquirir produtos por tipo');
            });
    };

    //Método que retorna descrição da unidade do produto
    var _getUnit = function (unitNumber) {
        
        if (unitNumber == ngUnit.UN) {
            return 'UN';
        }
        else if (unitNumber == ngUnit.KG) {
            return 'KG';
        }
    };

    //Método que retorna descrição do tipo de produto
    var _getProductType = function (prodTypeNumber) {

        if (prodTypeNumber == ngProductTypes.Cake) {
            return 'Bolo';
        }
        else if (prodTypeNumber == ngProductTypes.Frie) {
            return 'Frito';
        }
        else if (prodTypeNumber == ngProductTypes.Roast) {
            return 'Assado';
        }
        else if (prodTypeNumber == ngProductTypes.Sweet) {
            return 'Doce';
        }
    };

    //Método que salva produto
    var _saveNewProduct = function (product) {

        //Chamando WEB API no server que cadastra novo Produto
        return $http.post(
            serviceBase + 'api/product',
            JSON.stringify(product),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao cadastrar novo Produto. Status: ' + status);
            });
    };

    //Método que altera produto
    var _updateProduct = function (product) {

        //Chamando WEB API no server que altera Produto
        return $http.put(
            serviceBase + 'api/product',
            JSON.stringify(product),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao alterar Produto. Status: ' + status);
            });
    };
    

    //Definindo métodos desta factory a serem chamadas por outros js
    productsServiceFactory.getProducts = _getProducts;
    productsServiceFactory.getProduct = _getProduct;
    productsServiceFactory.getProductsByType = _getProductsByType;
    productsServiceFactory.getUnit = _getUnit;
    productsServiceFactory.getProductType = _getProductType;
    productsServiceFactory.saveNewProduct = _saveNewProduct;
    productsServiceFactory.updateProduct = _updateProduct;
    

    return productsServiceFactory;
}]);
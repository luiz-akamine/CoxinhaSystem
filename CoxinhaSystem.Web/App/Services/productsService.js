//Serviço com métodos relacionados a entidade de Pedidos
'use strict';
app.factory('productsService', ['$http', 'ngCoxinhaSettings', function ($http, ngCoxinhaSettings) {

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

    //Método que retorna lista completa de Produtos por Tipo
    var _getProductsByType = function (productType) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/product/GetByType?productType='+ productType)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir produtos por tipo. Status: ' + status);
                alert('erro ao adquirir produtos por tipo');
            });
    };
    

    //Definindo métodos desta factory a serem chamadas por outros js
    productsServiceFactory.getProducts = _getProducts;
    productsServiceFactory.getProductsByType = _getProductsByType;
    

    return productsServiceFactory;
}]);
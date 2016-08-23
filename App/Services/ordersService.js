//Serviço com métodos relacionados a entidade de Pedidos
'use strict';
app.factory('ordersService', ['$http', 'ngCoxinhaSettings', function ($http, ngCoxinhaSettings) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngCoxinhaSettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var ordersServiceFactory = {};

    //Método que retorna lista completa de Pedidos
    var _getOrders = function () {

        //Chamando WEB API no server que retorna a lista de Pedidos        
        return $http.get(serviceBase + 'api/order/GetComplete')
            .success(function (result) {                
                return result;                
            })
            .error(function (response, status) {
                console.log('erro ao adquirir pedidos. Status: ' + status);
                alert('erro ao adquirir pedidos');
            });
    };

    //Método que retorna lista de Ordens por Data de Entrega
    var _getOrdersByDtDelivery = function (dtBegin, dtEnd) {        

        //Chamando WEB API no server que retorna a lista de Pedidos por Data de Entrega
        return $http.get(serviceBase + 'api/order/GetByDtDelivery?dtBegin='+ dtBegin +'&dtEnd='+ dtEnd)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir pedidos por data de entrega. Status: ' + status);
                alert('erro ao adquirir pedidos');
            });
    }

    //Definindo métodos desta factory a serem chamadas por outros js
    ordersServiceFactory.getOrders = _getOrders;
    ordersServiceFactory.getOrdersByDtDelivery = _getOrdersByDtDelivery;

    return ordersServiceFactory;
}]);
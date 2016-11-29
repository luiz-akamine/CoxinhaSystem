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
        return $http.get(serviceBase + 'api/order/GetByDtDelivery?dtBegin=' + dtBegin + '&dtEnd=' + dtEnd)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir pedidos por data de entrega. Status: ' + status);
                alert('erro ao adquirir pedidos');
            });
    };

    //Método que retorna qtd sumarizada do valor doss pedidos
    var _getSumTotalByPeriod = function (dtBegin, dtEnd) {

        //Chamando WEB API no server que retorna o valor sumarizado dos pedidos
        return $http.get(serviceBase + 'api/order/GetTotalByPeriod?dtBegin=' + dtBegin + '&dtEnd=' + dtEnd)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir total dos pedidos. Status: ' + status);
                alert('erro ao adquirir total dos pedidos');
            });
    };

    
    //Método que retorna produtos mais pedidos num determinado periodo
    var _getMostRequestedProducts = function (dtBegin, dtEnd, productType) {

        //Chamando WEB API no server que retorna lista dos mais pedidos no periodo desejado
        return $http.get(serviceBase + 'api/order/GetMostRequestedProducts?dtBegin=' + dtBegin + '&dtEnd=' + dtEnd + '&productType='+ productType)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir mais pedidos. Status: ' + status);
                alert('erro ao adquirir mais pedidos');
            });
    };

    //Método que cadastra Novo Pedido
    var _saveNewOrder = function (orderComplete) {

        //Chamando WEB API no server que cadastra novo pedido
        return $http.post(
            serviceBase + 'api/order',
            JSON.stringify(orderComplete),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao cadastrar novo Pedido. Status: ' + status);
            });
    };

    //Método que edita Pedido
    var _editOrder = function (orderComplete) {

        //Chamando WEB API no server que cadastra novo pedido
        return $http.post(
            serviceBase + 'api/order/PutComplete',
            JSON.stringify(orderComplete),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao cadastrar novo Pedido. Status: ' + status);
            });
    };

    //Método que apaga Pedido completo
    var _deleteOrderComplete = function (order) {

        //Chamando WEB API no server que apaga pedido
        return $http.post(
            serviceBase + 'api/order/DeleteComplete',
            JSON.stringify(order),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao exluir Pedido. Status: ' + status);
            });
    };

    //Definindo métodos desta factory a serem chamadas por outros js
    ordersServiceFactory.getOrders = _getOrders;
    ordersServiceFactory.getOrdersByDtDelivery = _getOrdersByDtDelivery;
    ordersServiceFactory.saveNewOrder = _saveNewOrder;
    ordersServiceFactory.editOrder = _editOrder;
    ordersServiceFactory.getSumTotalByPeriod = _getSumTotalByPeriod;
    ordersServiceFactory.getMostRequestedProducts = _getMostRequestedProducts;
    ordersServiceFactory.deleteOrderComplete = _deleteOrderComplete;

    return ordersServiceFactory;
}]);
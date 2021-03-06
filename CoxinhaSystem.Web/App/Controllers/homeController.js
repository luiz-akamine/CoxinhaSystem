﻿'use strict';
app.controller('homeController', ['$scope', 'ordersService', 'productsService', 'commonLibService', 'tempObjectService', '$modal', 'modalService',
    function ($scope, ordersService, productsService, commonLibService, tempObjectService, $modal, modalService) {

    //Data do pedido
    $scope.dtOrder = new Date();

    //Variável de controle do checkbox
    $scope.showItens = false;

    //Controle para exibição msg de nao pedidos
    $scope.showAlert = true;
    
    //Adquirindo pedidos do dia
    $scope.refreshOrders = function (dtOrder) {
        //desabilitando visualização de msg q nao há pedidos indevidamente
        $scope.showAlert = false;

        $scope.orders = [];

        //Formato data JSON
        //2016-08-23T00:33:45.047Z

        //Adquirindo intervalo de datas
        var dtBegin = commonLibService.getDateBr($scope.dtOrder).toJSON().substring(0, 11);
        dtBegin = dtBegin + '00:00:00';

        var dtEnd = commonLibService.getDateBr($scope.dtOrder).toJSON().substring(0, 11);
        dtEnd = dtEnd + '23:59:59';

        //console.log(dtBegin);
        //console.log(dtEnd);

        ordersService.getOrdersByDtDelivery(dtBegin, dtEnd)        
            .success(function (result) {
                $scope.orders = result;
                $scope.showAlert = true;
            });
    }
}]);
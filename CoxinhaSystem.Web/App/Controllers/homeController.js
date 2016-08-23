'use strict';
app.controller('homeController', ['$scope', 'ordersService', function ($scope, ordersService) {    

    //Formato data JSON
    //2016-08-23T00:33:45.047Z

    //Adquirindo intervalo de datas
    var dtBegin = new Date().toJSON().substring(0, 11);
    dtBegin = dtBegin + '00:00:00.000Z';

    var dtEnd = new Date().toJSON().substring(0, 11);
    dtEnd = dtEnd + '23:59:59.999Z';

    //Adquirindo pedidos do dia
    $scope.orders = [];   
    ordersService.getOrdersByDtDelivery(dtBegin, dtEnd)
        .success(function (result) {
            $scope.orders = result;
        });
}]);
'use strict';
app.controller('reportsController', ['$scope', 'ordersService', '$filter', 'ngProductTypes', function ($scope, ordersService, $filter, ngProductTypes) {

    //Inicialização periodo
    $scope.dtIni = new Date(new Date().getFullYear(), 0, 1);
    $scope.dtEnd = new Date();    

    //Mensagem resultado
    $scope.result = 'Clique no Botão de Pesquisa para obter o Resultado';

    //Visualização do resultado
    $scope.showResult = 1;

    //radiobuttons
    var _lastWeek = 1;
    var _currentWeek = 2;
    var _nextWeek = 3;
    var _lastMonth = 4;
    var _currentMonth = 5;
    var _nextMonth = 6;
    var _byPeriod = 7;

    //Inicializará na semana corrente
    $scope.period = _currentWeek;

    //arrays para armazenar dados do relatorio 2
    $scope.cakes = [];
    $scope.sweets = [];
    $scope.fries = [];
    $scope.roasts = [];

    //Rotina filtra resultado
    $scope.filterResult = function () {

        //variaveis para filtro
        var dtSearchIni;
        var dtSearchEnd;

        //Checando filtro selecionado
        switch (parseInt($scope.period)) {
            case _lastWeek:
                dtSearchIni = moment().day(-7 + 1)._d;
                dtSearchEnd = moment().startOf('week').add(1, 'days')._d;
                break;
            case _currentWeek:
                dtSearchIni = moment().startOf('week').add(1, 'days')._d;
                dtSearchEnd = moment().day(+7 + 1)._d;
                break;
            case _nextWeek:
                dtSearchIni = moment().day(+7 + 1)._d;
                dtSearchEnd = moment().day(+7 + 1 + 7)._d;
                break;
            case _lastMonth:
                dtSearchIni = moment().subtract(1, 'months').startOf('month')._d;
                dtSearchEnd = moment().startOf('month')._d;
                break;
            case _currentMonth:
                dtSearchIni = moment().startOf('month')._d;
                dtSearchEnd = moment().add(1, 'months').startOf('month')._d;
                break;
            case _nextMonth:
                dtSearchIni = moment().add(1, 'months').startOf('month')._d;
                dtSearchEnd = moment().add(2, 'months').startOf('month')._d;
                break;
            case _byPeriod:
                dtSearchIni = $scope.dtIni;
                dtSearchEnd = $scope.dtEnd;
                break;
        }

        if ($scope.showResult = 1) {       
            //Adquirindo rendimento
            ordersService.getSumTotalByPeriod(dtSearchIni.toJSON(), dtSearchEnd.toJSON())
                .then(function (result) {                
                    $scope.result = 'Total vendido: ' + $filter('currency')(result.data, 'R$');
                });        
        }
        else {
            //Adquirindo Mais Pedidos no Período de cada tipo
            ordersService.getMostRequestedProducts(dtSearchIni.toJSON(), dtSearchEnd.toJSON(), ngProductTypes.Cake)
                .then(function (result) {
                    $scope.cakes = result;
                });
            ordersService.getMostRequestedProducts(dtSearchIni.toJSON(), dtSearchEnd.toJSON(), ngProductTypes.Sweet)
                .then(function (result) {
                    $scope.sweets = result;
                });
            ordersService.getMostRequestedProducts(dtSearchIni.toJSON(), dtSearchEnd.toJSON(), ngProductTypes.Frie)
                .then(function (result) {
                    $scope.fries = result;
                });
            ordersService.getMostRequestedProducts(dtSearchIni.toJSON(), dtSearchEnd.toJSON(), ngProductTypes.Roast)
                .then(function (result) {
                    $scope.roasts = result;
                });
        }
    };
}]);
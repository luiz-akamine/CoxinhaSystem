//Serviço com métodos comuns
'use strict';
app.factory('commonLibService', [function () {

    //Variável para acessarmos este serviço
    var commonLibServiceFactory = {};

    //Método retorna booleano mesmo se variavel nunca foi definida
    var _getBoolValue = function (value) {

        if (typeof value == 'undefined') {
            return false;
        }

        return value;
    };

    //Método retorna data/hora tratada para envio para apicontroller
    var _getDateBr = function (dt) {

        return new Date
            (
                dt.getFullYear(),
                dt.getMonth(),
                dt.getDate(),
                dt.getHours() - (new Date().getTimezoneOffset() / 60),
                dt.getMinutes(), 0, 0
            );
    };

    //Definindo métodos desta factory a serem chamadas por outros js
    commonLibServiceFactory.getBoolValue = _getBoolValue;
    commonLibServiceFactory.getDateBr = _getDateBr;

    return commonLibServiceFactory;
}]);
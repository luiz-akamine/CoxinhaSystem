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

    //Definindo métodos desta factory a serem chamadas por outros js
    commonLibServiceFactory.getBoolValue = _getBoolValue;

    return commonLibServiceFactory;
}]);
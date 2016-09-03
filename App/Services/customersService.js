//Serviço com métodos relacionados a entidade de Pedidos
'use strict';
app.factory('customersService', ['$http', 'ngCoxinhaSettings', function ($http, ngCoxinhaSettings) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngCoxinhaSettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var customersServiceFactory = {};

    //Método que cliente a partir de seu telefone
    var _getByPhoneComplete = function (phoneNumber) {

        //Chamando WEB API no server que retorna a lista de Pedidos        
        return $http.get(serviceBase + 'api/customer/GetByPhoneComplete?phoneNumber='+ phoneNumber)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir cliente. Status: ' + status);
                alert('erro ao adquirir cliente');
            });
    };

    //Definindo métodos desta factory a serem chamadas por outros js
    customersServiceFactory.getByPhoneComplete = _getByPhoneComplete;

    return customersServiceFactory;
}]);
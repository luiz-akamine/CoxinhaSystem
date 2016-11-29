//Serviço com métodos relacionados a entidade de Pedidos
'use strict';
app.factory('customersService', ['$http', 'ngCoxinhaSettings', function ($http, ngCoxinhaSettings) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngCoxinhaSettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var customersServiceFactory = {};

    //Método que retorna lista completa de Clientes
    var _getCustomers = function () {

        //Chamando WEB API no server que retorna a lista de clientes        
        return $http.get(serviceBase + 'api/customer/getComplete')
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir clientes. Status: ' + status);
                alert('erro ao adquirir clientes');
            });
    };

    //Método que retorna um Cliente específico
    var _getCustomer = function (customerId) {

        //Chamando WEB API no server que retorna a lista de clientes
        return $http.get(serviceBase + 'api/customer/getCompleteById?id=' + customerId)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir cliente. Status: ' + status);
                alert('erro ao adquirir cliente');
            });
    };

    //Método que cliente a partir de seu telefone
    var _getByPhoneComplete = function (phoneNumber) {

        //Chamando WEB API no server que retorna a lista de Pedidos        
        return $http.get(serviceBase + 'api/customer/GetByPhoneComplete?phoneNumber=' + phoneNumber)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir cliente. Status: ' + status);
                alert('erro ao adquirir cliente');
            });
    };

    //Método que cadastra ou atualiza cliente
    var _saveOrUpdateCustomerByPhone = function (customer) {

        //Chamando WEB API no server que cadastra ou atualiza cliente (a busca é pelo telefone)
        return $http.post(
            serviceBase + 'api/customer/SaveOrUpdateCustomerByPhone',
            JSON.stringify(customer),
            {
                headers: {'Content-Type': 'application/json'}
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao cadastrar/atualizar cliente. Status: ' + status);                
            });
    };

    //Método que salva cliente
    var _saveNewCustomer = function (customer) {
        debugger;
        //Chamando WEB API no server que cadastra novo Cliente
        return $http.post(
            serviceBase + 'api/customer',
            JSON.stringify(customer),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao cadastrar novo Cliente. Status: ' + status);
            });
    };

    //Método que altera cliente
    var _updateCustomer = function (customer) {
        //Chamando WEB API no server que altera Cliente
        return $http.post(
            serviceBase + 'api/customer/UpdateComplete',
            JSON.stringify(customer),
            {
                headers: { 'Content-Type': 'application/json' }
            }
            ).success(function (result) {
                return result;
            }).error(function (response, status) {
                console.log('erro ao alterar Cliente. Status: ' + status);
            });
    };

    //Definindo métodos desta factory a serem chamadas por outros js
    customersServiceFactory.getCustomer = _getCustomer;
    customersServiceFactory.getCustomers = _getCustomers;
    customersServiceFactory.getByPhoneComplete = _getByPhoneComplete;
    customersServiceFactory.saveOrUpdateCustomerByPhone = _saveOrUpdateCustomerByPhone;
    customersServiceFactory.saveNewCustomer = _saveNewCustomer;
    customersServiceFactory.updateCustomer = _updateCustomer;

    return customersServiceFactory;
}]);
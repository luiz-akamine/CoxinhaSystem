//Serviço com métodos comuns
'use strict';
app.factory('commonLibService', ['$http', function ($http) {

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

    //Método retorna cep tratado do valor que vem banco
    var _getCepFormated = function (cepNumber) {

        if (cepNumber) {
            var formatCep = "00000000";
            var cepFormated = formatCep.substring(0, formatCep.length - cepNumber.toString().length) + cepNumber.toString();
            cepFormated = cepFormated.substring(0, 5) + "-" + cepFormated.substring(5, 8);

            return cepFormated;
        }
    };

    //Método trata cep para enviar ao banco
    var _getCepToDB = function (cepDesc) {

        var cepToSend = cepDesc.replace('-', '');
        cepToSend = parseInt(cepToSend);

        return cepToSend;
    };

    //Seta foco no primeiro input do form
    var _setFocusInFirstInput = function () {
        jq('form').find('*').filter(':input:visible:first').select();
    };

    //Retorna objeto contendo informações de um CEP
    var _getAddressFromCep = function (cep) {
        //api do CEP
        var urlCEP = 'https://viacep.com.br/ws/%CEP%/json';        
        urlCEP = urlCEP.replace('%CEP%', cep);

        return $http.get(urlCEP)
            .success(function (result) {
                if (result.erro) {
                    return {};
                }
                else {
                    var address = {};
                    address.logradouro = result.logradouro;
                    address.complemento = result.complemento;
                    address.bairro = result.bairro;
                    address.localidade = result.localidade;
                    address.uf = result.uf;

                    return address;
                }
            })
            .error(function (response, status) {
                return 'CEP inválido';                    
            });
    };

    //converte objeto do CEP de acordo com o banco de dados do sistema
    var _parseToCepDB = function (objCep, objAddress) {

        var cepDB = {};
        
        if (objCep) {
            if (objAddress.id) {
                cepDB.id = objAddress.id;
            }
            if (objAddress.customerId) {
                cepDB.customerId = objAddress.customerId;
            }
            cepDB.cep = objCep.cep;
            cepDB.addressName = objCep.logradouro;            
            cepDB.district = objCep.bairro; 
            cepDB.complement = objCep.complemento; 
            cepDB.city = objCep.localidade; 
            cepDB.state = objCep.uf;
        }

        return cepDB;
    };

    //ordenação objeto JSON
    function _sortJsonArrayByProperty(objArray, prop, direction) {
        if (arguments.length < 2) throw new Error("sortJsonArrayByProp requires 2 arguments");
        var direct = arguments.length > 2 ? arguments[2] : 1; //Default to ascending

        if (objArray && objArray.constructor === Array) {
            var propPath = (prop.constructor === Array) ? prop : prop.split(".");
            objArray.sort(function (a, b) {
                for (var p in propPath) {
                    if (a[propPath[p]] && b[propPath[p]]) {
                        a = a[propPath[p]];
                        b = b[propPath[p]];
                    }
                }
                // convert numeric strings to integers
                a = a.match(/^\d+$/) ? +a : a;
                b = b.match(/^\d+$/) ? +b : b;
                return ((a < b) ? -1 * direct : ((a > b) ? 1 * direct : 0));
            });
        }
    }

    //Definindo métodos desta factory a serem chamadas por outros js
    commonLibServiceFactory.getBoolValue = _getBoolValue;
    commonLibServiceFactory.getDateBr = _getDateBr;
    commonLibServiceFactory.getCepFormated = _getCepFormated;
    commonLibServiceFactory.getCepToDB = _getCepToDB;
    commonLibServiceFactory.setFocusInFirstInput = _setFocusInFirstInput;
    commonLibServiceFactory.getAddressFromCep = _getAddressFromCep;
    commonLibServiceFactory.parseToCepDB = _parseToCepDB;
    commonLibServiceFactory.sortJsonArrayByProperty = _sortJsonArrayByProperty;    

    return commonLibServiceFactory;
}]);
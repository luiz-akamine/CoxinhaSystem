'use strict';
app.controller('newOrderController', ['$scope', '$http', '$timeout', 'productsService', 'customersService', 'showAndHideService', 'ngProductTypes',
    function ($scope, $http, $timeout, productsService, customersService, showAndHideService, ngProductTypes) {

    //Lista de produtos a ser exibida para seleção
    $scope.listProducts = [];
    //Lista de produtos adicionadas no Pedido
    $scope.listOrderProducts = [];

    //Variável com o Valor Total do Pedido
    $scope.orderTotal = 0;
    //Variável com o Desconto do Pedido
    $scope.discount = 0;
    //Variável com o Valor Total do Pedido com Desconto
    $scope.orderTotalWithDiscount = 0;
    

    //Controle de visibilidade do form
    $scope.showDivConfirmation = false;

    //Carrega produtos do tipo "Bolo"
    $scope.loadCakes = function () {
        $scope.listProducts = [];

        productsService.getProductsByType(ngProductTypes.Cake)
            .success(function (result) {
                $scope.listProducts = result;                
            });
    };

    //Carrega produtos do tipo "Fritura"
    $scope.loadFries = function () {
        $scope.listProducts = [];

        productsService.getProductsByType(ngProductTypes.Frie)
            .success(function (result) {
                $scope.listProducts = result;
            });
    };

    //Carrega produtos do tipo "Assado"
    $scope.loadRoasts = function () {
        $scope.listProducts = [];

        productsService.getProductsByType(ngProductTypes.Roast)
            .success(function (result) {
                $scope.listProducts = result;
            });
    };

    //Carrega produtos do tipo "Doce"
    $scope.loadSweets = function () {
        $scope.listProducts = [];

        productsService.getProductsByType(ngProductTypes.Sweet)
            .success(function (result) {
                $scope.listProducts = result;
            });
    };

    //Incrementa qtd do registro selecionado
    $scope.incProdQty = function (product) {
        product.qty = (parseFloat(product.qty) || 0) + product.incQty;

        refreshListOrderProducts(product);
        //calcular preço no pedido
        calcProductPriceInOrder(product);

        //Atualizando totais
        $scope.refreshTotals();
    };

    //Decrementa qtd do registro selecionado
    $scope.decProdQty = function (product) {
        product.qty = (parseFloat(product.qty) || 0) - product.incQty;
        if (product.qty < 0) {
            product.qty = 0;
        }

        refreshListOrderProducts(product);
        //calcular preço no pedido
        calcProductPriceInOrder(product);

        //Atualizando totais
        $scope.refreshTotals();
    };

    //Carrega qtd do Produto já adicionada na lista do Novo pedido
    $scope.loadQty = function (product) {
        //Procurando produto na lista
        var index = $scope.listOrderProducts.findIndex(p => p.name === product.name);
        if (index >= 0) {
            //Encontrou produto na lista, carregando sua qtd
            product.qty = $scope.listOrderProducts[index].qty;
            //calcular preço no pedido
            calcProductPriceInOrder(product);
        }
        else
        {
            //não encontrou. Considerar zero
            product.qty = 0;
            product.priceInOrder = null;
        }
    };

    //Calcula preço de acordo com o produto e qtd escolhida no pedido
    var calcProductPriceInOrder = function(product) {
        if ((parseFloat(product.qty) || 0) > 0) {
            product.priceInOrder = product.price * product.qty;
        }
    };

    //Atualiza lista do pedido
    var refreshListOrderProducts = function (product) {

        //Procurando se produto está já na lista
        $scope.listOrderProducts.forEach(function (prodInList, index) {
            if (product.name == prodInList.name) {
                //Retirar produto da lista para adicionarmos com a qtd atualizada
                $scope.listOrderProducts.splice(index, 1);
            }
        });        

        //Adicionando produto na lista
        if (product.qty > 0){
            $scope.listOrderProducts.push(product);
        }        
    };

    //Atualiza totalizadores
    $scope.refreshTotals = function () {        
        $scope.orderTotal = 0;
        $scope.orderTotalWithDiscount = 0;

        var total = 0;        
        $scope.listOrderProducts.forEach(function (prod) {
            total += prod.priceInOrder;
        });

        $scope.orderTotal = total;
        $scope.orderTotalWithDiscount = total * (1 - ($scope.discount/100));
    };

    //Zera pedido
    $scope.resetOrder = function () {
        $scope.listOrderProducts = [];
        $scope.orderTotal = 0;
        $scope.discount = 0;
        $scope.orderTotalWithDiscount = 0;
        $scope.orderConfirmation = {};
        $scope.orderConfirmation.address = {};

        $scope.listProducts.forEach(function (prod) {
            $scope.loadQty(prod);
        });        
    };

    //Exibe sub-tela de confirmação do pedido caso haja itens
    $scope.showConfirmation = function () {
        if ($scope.listOrderProducts.length > 0) {
            $scope.showDivConfirmation = true;

            //Foco com delay no telefone
            $timeout(function () {
                jq('#phone').focus();
            }, 750);            
        }        
    };    

    //Chamando click inicial no primeiro botão de "Bolo"    
    $scope.loadCakes();


    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                              SUB-TELA DE CONFIRMAÇÃO DO PEDIDO                                       //
    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    //objeto confirmação do pedido
    $scope.orderConfirmation = {};
    $scope.orderConfirmation.address = {};

    //Controle de carregamento automatico do endereço pelo cep
    var _loadCEP = true;

    //Exibe mensagem de erro e desaparece
    $scope.$watch('error', function () {
        if ($scope.error) {
            $scope.msgErr = showAndHideService(3000);

            $timeout(function () {
                $scope.error = '';
            }, 3000);
        }        
    });

    //Carrega Endereço a partir do CEP
    $scope.loadCEP = function () {
        if (!_loadCEP) {
            return;
        };

        //api do CEP
        var urlCEP = 'https://viacep.com.br/ws/%CEP%/json';
        
        if (($scope.orderConfirmation.address.cep) && ($scope.orderConfirmation.address.cep.length >= 8)) {
            urlCEP = urlCEP.replace('%CEP%', $scope.orderConfirmation.address.cep);

            $http.get(urlCEP)
                .success(function (result) {
                    if (result.erro) {
                        $scope.error = 'CEP inválido';
                        $scope.orderConfirmation.address = {};
                        //$scope.msgErr = showAndHideService(3000);
                    }
                    else {
                        $scope.orderConfirmation.address.logradouro = result.logradouro;
                        $scope.orderConfirmation.address.complemento = result.complemento;
                        $scope.orderConfirmation.address.bairro = result.bairro;
                        $scope.orderConfirmation.address.localidade = result.localidade;
                        $scope.orderConfirmation.address.uf = result.uf;

                        jq('#addressnumber').focus();
                    }
                })
                .error(function (response, status) {                    
                    $scope.error = 'CEP inválido';
                    $scope.orderConfirmation.address = {};
                    //$scope.msgErr = showAndHideService(3000);
                });
        }
        else {
            $scope.orderConfirmation.address.logradouro = null;
            $scope.orderConfirmation.address.complemento = null;
            $scope.orderConfirmation.address.bairro = null;
            $scope.orderConfirmation.address.localidade = null;
            $scope.orderConfirmation.address.uf = null;
            $scope.orderConfirmation.address.numero = null;
        }
    };

    //Carrega cliente pelo telefone
    $scope.loadCustomerByPhone = function (phoneNumber) {        
        customersService.getByPhoneComplete(phoneNumber)
            .success(function(result){
                if (result != null){
                    $scope.orderConfirmation.address.cliente = result.name;

                    //endereço
                    if (result.addresses.length > 0) {
                        try {
                            _loadCEP = false;
                            //tratando cep (colocar num service)
                            var formatCep = "00000000";                        
                            var cepFormated = formatCep.substring(0, formatCep.length - result.addresses[0].cep.toString().length) + result.addresses[0].cep.toString();
                            console.log(cepFormated);
                            cepFormated = cepFormated.substring(0, 5) + "-" + cepFormated.substring(5, 8);
                            $scope.orderConfirmation.address.cep = cepFormated;
                        }
                        finally {
                            _loadCEP = true;
                        }
                        
                        $scope.orderConfirmation.address.logradouro = result.addresses[0].addressName;
                        $scope.orderConfirmation.address.numero = result.addresses[0].number;
                        $scope.orderConfirmation.address.bairro = result.addresses[0].district;
                        $scope.orderConfirmation.address.complemento = result.addresses[0].complement;
                        $scope.orderConfirmation.address.localidade = result.addresses[0].city;
                        $scope.orderConfirmation.address.uf = result.addresses[0].state;
                    };
                };
        });
    };

    //Foco no horário quando terminar de digitar data
    $scope.setFocusHour = function (value) {
        if (value) {
            jq("#horaEntrega").focus();
        }
    };

    //Foco no CEP quando terminar de digitar horário
    $scope.setFocusCEP = function (value) {
        if (value) {
            jq("#cep").focus();
        }
    };
}]);
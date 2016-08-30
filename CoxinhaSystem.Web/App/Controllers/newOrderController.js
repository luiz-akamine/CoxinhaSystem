'use strict';
app.controller('newOrderController', ['$scope', 'productsService', 'ngProductTypes', function ($scope, productsService, ngProductTypes) {

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

        $scope.listProducts.forEach(function (prod) {
            $scope.loadQty(prod);
        });        
    };

    //Exibe sub-tela de confirmação do pedido caso haja itens
    $scope.showConfirmation = function () {
        if ($scope.listOrderProducts.length > 0) {
            $scope.showDivConfirmation = true;
        }        
    };    


    //Chamando click inicial no primeiro botão de "Bolo"    
    $scope.loadCakes();    
}]);
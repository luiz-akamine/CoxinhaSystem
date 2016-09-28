//Arquivo raíz de configuração da aplicação
var app = angular.module('CoxinhaApp', ['myDirectives', 'ngAnimate', 'ngRoute', 'ui.mask', 'ngGrid']);

//Configurações das rotas da aplicação
app.config(function ($routeProvider, $httpProvider, $locationProvider) {

    $locationProvider.html5Mode(true);

    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
    $httpProvider.defaults.headers.delete = {};
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/json';

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/newOrder", {
        controller: "newOrderController",
        templateUrl: "/app/views/newOrder.html"
    });

    $routeProvider.when("/searchOrders", {
        controller: "searchOrdersController",
        templateUrl: "/app/views/searchOrders.html"
    });

    $routeProvider.when("/customers", {
        controller: "customersController",
        templateUrl: "/app/views/customers.html"
    });

    $routeProvider.when("/products", {
        controller: "productsController",
        templateUrl: "/app/views/products.html"
    });

    $routeProvider.when("/productCad", {
        controller: "productCadController",
        templateUrl: "/app/views/productCad.html"
    });

    $routeProvider.when("/reports", {
        controller: "reportsController",
        templateUrl: "/app/views/reports.html"
    });
    
    $routeProvider.otherwise({ redirectTo: "/home" });
});

//Constantes da aplicação
app.constant('ngCoxinhaSettings', {
    apiServiceBaseUri: 'http://localhost:3001/'
    //apiServiceBaseUri: 'http://localhost:50591/'
});
app.constant('ngProductTypes', {
    Cake: 1,
    Frie: 2,
    Roast: 3,
    Sweet: 4
});
app.constant('ngOrderStatus', {
    Created: 10,
    InProgress: 20,
    Finished: 30,
    Canceled: 40
});
app.constant('ngUnit', {
    UN: 1,
    KG: 2
});

/* TODO
//Setando serviço que realizará a interceptação das requisições http
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

//Chamando rotina inicial da aplicação
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
*/
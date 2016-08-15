//Arquivo raíz de configuração da aplicação
var app = angular.module('CoxinhaApp', ['ngRoute', 'angular-loading-bar']);

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
    
    $routeProvider.otherwise({ redirectTo: "/home" });
});

//Constantes da aplicação
app.constant('ngCoxinhaSettings', {
    apiServiceBaseUri: 'http://localhost:3001/'
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
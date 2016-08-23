//Componentes/diretivas customizados

angular.module('myDirectives', [])
.directive('orderCard', function () {
    return {
        restrict: "AE",
        scope: {
            caption: '@',
            orderjson: '='
        },
        //transclude: true,
        templateUrl: 'App/Components/orderCard.html'
        /*required: 'ngModel',
        link: function (scope, element, attrs, directive) {
            
            this.orderjson = directive.$viewValue;
        }*/
    };
});
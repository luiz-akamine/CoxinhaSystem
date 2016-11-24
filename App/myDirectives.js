//Componentes/diretivas customizados

angular.module('myDirectives', [])
.directive('orderCard', ['productsService', '$location', 'tempObjectService', '$window', function (productsService, $location, tempObjectService, $window) {
    return {
        restrict: "AE",
        scope: {
            caption: '@',
            orderjson: '=',
            showitens: '='            
        },
        //transclude: true,
        templateUrl: 'App/Components/orderCard.html',
        /*required: 'ngModel',
        link: function (scope, element, attrs, directive) {
            
            this.orderjson = directive.$viewValue;
        }*/                
        link: function (scope, element, attrs, directive) {            
            //Retorna unidade do produto
            scope.getUnit = function (unitNumber) {
                return productsService.getUnit(unitNumber);
            };

            //abre edição do pedido
            scope.editOrder = function (order) {
                tempObjectService.addOrder(order);
                $location.path('/newOrder/edit');
                //$window.location.href = '/#/newOrder/edit';
            };

            scope.toggleItens = function () {
                if (scope.showitens) {
                    element.find('#divItens').slideDown();
                }
                else {
                    element.find('#divItens').slideUp();
                }
            };

            element.find('#toggle').bind('click', function () {
                scope.showitens = !scope.showitens;                
                scope.$apply();
                             
                scope.toggleItens();
            });

            scope.toggleItens();
        }
    };
}])
.directive('uiDate', function () {
    return {
        restrict: "A",
        //scope: {},
        require: "ngModel",
        link: function (scope, element, attrs, ctrl) {
            var _formatDate = function (date) {
                //retirando carcteres diferentes de números
                if (date) {                
                    date = date.replace(/[^0-9]+/g, "");

                    //Inserindo máscara
                    if (date.length >= 2) {
                        date = date.substring(0, 2) + "/" + date.substring(2);
                    }
                    if (date.length >= 5) {
                        date = date.substring(0, 5) + "/" + date.substring(5, 9);
                    }
                }

                return date;
            };

            //atribuindo evento keyup para ao digitarmos, a mascara entrar em ação
            element.bind("keyup", function () {
                ctrl.$setViewValue(_formatDate(ctrl.$viewValue));
                ctrl.$render();
            });

            ctrl.$formatters.push(function (data) {
                //convert data from model format to view format
                if (data) {
                    return data.getDate() + '/' + data.getMonth() + '/' + data.getFullYear(); //converted
                }                
            });

            //Atribuindo ao ngModel apenas quando atingir o número de caracteres completo de data
            ctrl.$parsers.push(function (value) {
                if (value.length === 10) {

                    //validação da data
                    if (!moment(value, 'DD/MM/YYYY').isValid()) {
                        //Limpando variável
                        ctrl.$setViewValue('');
                        ctrl.$render();

                        //msg de erro
                        scope.error = 'Data Inválida';

                        return null;
                    }

                    var dateArray = value.split("/");

                    return new Date(dateArray[2], dateArray[1] - 1, dateArray[0]);
                }
            });
        }
    };
})
.directive('uiTime', function () {
    return {
        restrict: "A",
        //scope: {},
        require: "ngModel",
        link: function (scope, element, attrs, ctrl) {
            var _formatTime = function (time) {
                if (time != null) {
                    //retirando carcteres diferentes de números
                    time = time.replace(/[^0-9]+/g, "");

                    //Inserindo máscara
                    if (time.length >= 2) {
                        time = time.substring(0, 2) + ":" + time.substring(2, 4);
                    }

                    return time;
                }
            };

            //atribuindo evento keyup para ao digitarmos, a mascara entrar em ação
            element.bind("keyup", function () {
                ctrl.$setViewValue(_formatTime(ctrl.$viewValue));
                ctrl.$render();
            });

            ctrl.$formatters.push(function (data) {
                //convert data from model format to view format
                if (data) {
                    var datePush = ('0' + (data.getHours() + (new Date().getTimezoneOffset() / 60))).substr(-2) + ':' + ('0' + data.getMinutes()).substr(-2);
                    ctrl.$setViewValue(_formatTime(datePush));
                    ctrl.$render();
                    return datePush; //converted
                }                
            });

            //Atribuindo ao ngModel apenas quando atingir o número de caracteres completo de data
            ctrl.$parsers.push(function (value) {
                if (value.length === 5) {

                    //validação da hora
                    if (!moment(value, "HH:mm").isValid()) {
                        ctrl.$setViewValue('');
                        ctrl.$render();

                        //msg de erro
                        scope.error = 'Horário Inválido';

                        return null;
                    };

                    var timeArray = value.split(":");

                    return new Date(0, 0, 0, timeArray[0], timeArray[1]);
                }
            });
        }
    };
})
.directive('uiPhoneBr', function () {
    return {
        restrict: "A",
        scope: {},
        require: "ngModel",
        link: function (scope, element, attrs, ctrl) {
            var _formatPhone = function (phone) {
                if (phone != null) {                
                    //retirando carcteres diferentes de números
                    phone = phone.replace(/[^0-9]+/g, "");

                    //Inserindo máscara
                    if (phone.length >= 1) {
                        phone = "(" + phone.substring(0, 1) + phone.substring(1);
                    }
                    if (phone.length >= 3) {
                        phone = phone.substring(0, 3) + ") " + phone.substring(3);
                    }
                    if (phone.length >= 9) {
                        phone = phone.substring(0, 9) + "-" + phone.substring(9, 14);
                    }
                    if (phone.length >= 15) {
                        phone = phone.substring(0, 9) + phone[10] + "-" + phone.substring(11, 15);
                    }

                    return phone;
                }
            };

            //atribuindo evento keyup para ao digitarmos, a mascara entrar em ação
            element.bind("keyup", function () {
                ctrl.$setViewValue(_formatPhone(ctrl.$viewValue));
                ctrl.$render();
            });

            //Atribuindo ao ngModel apenas quando atingir o número de caracteres completo de data
            ctrl.$parsers.push(function (value) {
                if (value.length >= 14) {
                    return value
                }
            });
        }
    };
})
.directive('ngInputDecimal', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            function inputValue(val) {

                if (val) {
                    var digits = val.replace(/[^0-9.]/g, '');

                    if (digits.split('.').length > 2) {
                        digits = digits.substring(0, digits.length - 1);
                    }

                    if (digits !== val) {
                        ctrl.$setViewValue(digits);
                        ctrl.$render();
                    }
                    return parseFloat(digits);
                }
                return 0;
            }
            ctrl.$parsers.push(inputValue);
        }
    };
});
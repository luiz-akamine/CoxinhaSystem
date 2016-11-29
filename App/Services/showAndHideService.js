app.service('showAndHideService', ['$timeout', function ($timeout) {
    return function (delay) {
        var result = { hidden: true };
        $timeout(function () {
            result.hidden = false;
        }, delay);
        return result;
    };
}]);
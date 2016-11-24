app.service('tempObjectService', [function () {
    var order = null;

    var _addOrder = function(newObj) {
        order = newObj;
    };

    var _getOrder = function () {
        return order;
    };

    var _cleanOrder = function () {
        order = null;
    };

    return {
        addOrder: _addOrder,
        getOrder: _getOrder,
        cleanOrder: _cleanOrder
    };
}])
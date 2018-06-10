angular.module("sportsStore")
    .constant("dataUrl", "/Study/ProductJsonResult")
    .constant("orderUrl", "/Study/ProductOrders")
    .controller("sportsStoreCtrl", function ($scope, $http, $location,
        dataUrl, orderUrl, cart) {

        $scope.data = {};

        $http.post(dataUrl)
            .then(function (res) {
                console.log(res);
                console.log(res.data);
                if (res.data.result == "fail") {
                    $scope.data.error = res.data.message;
                }
                else if (res.data.result == "success") {

                    $scope.data.products = res.data.products;
                }
            });


        $scope.sendOrder = function (shippingDetails) {
            var order = angular.copy(shippingDetails);
            order.products = cart.getProducts();
            $http.post(orderUrl, order)
                .then(function (res) {
                    $location.path("/complete");
                });
        };
    });

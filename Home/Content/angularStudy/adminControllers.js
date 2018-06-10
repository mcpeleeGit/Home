angular.module("sportsStoreAdmin")
    .constant("authUrl", "/Study/ProductOrders")
    .constant("ordersUrl", "/Study/ProductOrders")
    .controller("authCtrl", function ($scope, $http, $location, authUrl) {

        $scope.authenticate = function (user, pass) {
            $location.path("#!/main");
        }
    })
    .controller("mainCtrl", function ($scope) {

        $scope.screens = ["Products", "Orders"];
        $scope.current = $scope.screens[0];

        $scope.setScreen = function (index) {
            $scope.current = $scope.screens[index];
        };

        $scope.getScreen = function () {
            return $scope.current == "Products"
                ? "/Content/angularStudy/adminProducts.html" : "/Content/angularStudy/adminOrders.html";
        };
    })
    .controller("ordersCtrl", function ($scope, $http, ordersUrl) {

        $http.get(ordersUrl, { withCredentials: true })
            .success(function (data) {
                $scope.orders = data;
            })
            .error(function (error) {
                $scope.error = error;
            });

        $scope.selectedOrder;

        $scope.selectOrder = function (order) {
            $scope.selectedOrder = order;
        };

        $scope.calcTotal = function (order) {
            var total = 0;
            for (var i = 0; i < order.products.length; i++) {
                total +=
                    order.products[i].count * order.products[i].price;
            }
            return total;
        }
    });
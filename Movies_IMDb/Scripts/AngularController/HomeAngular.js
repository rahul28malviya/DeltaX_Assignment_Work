var app = angular.module("HomeApp", []);
app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "Save";
    $scope.Movie = {};
    $scope.ActorArr = [];
    // Add record
    $http.get('/Home/GetProducers').then(function (d) {
        $scope.ProducerList = d.data;
    });
    $http.get('/Home/GetActors').then(function (d) {
        $scope.ActorList = d.data;
    });
    $scope.savedata = function () {
        console.log($scope.ActorList);
        for (var i = 0; i < $scope.ActorList.length; i++) {
            if ($scope.ActorList[i].checked) {
                $scope.ActorArr.push($scope.ActorList[i].ActorId);
            }
        }
        $scope.Movie.ActorId = $scope.ActorArr;
        console.log($scope.ActorArr);
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/AddMovie',
            data: $scope.Movie
        }).then(function (d) {
            $scope.btntext = "Save";
            $scope.Movie = null;
            alert(d.data);
        }, function (d) {
            alert(d.data);
        });
    };
    $scope.saveproducer = function () {
        $http({
            method: 'POST',
            url: '/Home/AddProducer',
            data: $scope.Producer
        }).then(function (d) {
            $scope.Producer = null;
            $http.get('Home/GetProducers').then(function (d) {
                $scope.ProducerList = d.data;
            });
            alert(d.data);
        });
    };

    $scope.saveactor = function () {
        $http({
            method: 'POST',
            url: '/Home/AddActor',
            data: $scope.Actor
        }).then(function (d) {
            $scope.Actor = null;
            $http.get('Home/GetActor').then(function (d) {
                $scope.ActorList = d.data;
            });
            alert(d.data);
        });
    };
    $scope.setFile = function (element) {
        if (element.files[0]) {
            var reader = new FileReader();
            reader.onloadend = function () {
                $scope.Movie.poster = reader.result;
            }
            reader.readAsDataURL(element.files[0]);
        }
    }
});
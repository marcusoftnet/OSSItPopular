var ossItPopularApp = angular.module('OssItPopular', []);

ossItPopularApp.controller('GitHubController', ['$scope', '$http',
    function ($scope, $http) {
        $scope.searchRepos = function () {
            $http({
                method: 'GET',
                url: 'http://localhost:2342/search/?name=' + $scope.searchString
            }).
            success(function (data) {
                console.log(data.Repositories);
                $scope.repositories = data.Repositories;
            }).
            error(function (data) {
                alert(data);
            });
        };
        
        $scope.getAllData = function(reponame) {
            alert(reponame);
        };
    }
]);


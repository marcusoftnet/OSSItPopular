var ossItPopularApp = angular.module('OssItPopular', []);

ossItPopularApp.controller('GitHubController', ['$scope', '$http',
    function ($scope, $http) {
        $scope.searchRepos = function () {
            $http({
                method: 'GET',
                url: '/GitHub/Search/?name=' + $scope.searchString
            }).
            success(function (data) {
                $scope.repositories = data.Repositories;
            });
        };
        
        $scope.getAllData = function(repo) {
            $http({
                method: 'GET',
                url: '/GitHub/Stats/?FullName=' + repo.Name
            }).
             success(function (data) {
                 console.log(data);
                 $scope.gitHubDetails = data;
             });
        };
    }
]);


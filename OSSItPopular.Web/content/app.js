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
                url: '/GitHub/Stats/' + repo.FullNames
            }).
             success(function (data) {
                 console.log(data);
             });
        };
    }
]);


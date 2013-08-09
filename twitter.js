angular.module('OssItPopular', ['ngResource']);

function TwitterCtrl($scope, $resource) {
    $scope.twitter = $resource('https://api.twitter.com/1.1/search/tweets.json',
        { q:'angularjs', callback:'JSON_CALLBACK'},
        {
        	get: { method:'JSONP'}
        });

    $scope.doSearch = function () {
        $scope.twitterResult = $scope.twitter.get({q:$scope.searchTerm});
    };
}
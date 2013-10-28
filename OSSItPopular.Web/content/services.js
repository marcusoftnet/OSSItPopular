var serviceModule = angular.module("OssItPopular.services", []);

serviceModule.factory("OssItPopularService", function ($http, $log) {

    var service = function (data) {
        angular.extend(this, data);
    };

    getUrl = function (url, callback) {
        $http.get(url)
            .success(callback)
            .error(function (data) {
                $log.log(data);
                alert("An error has ocurred. It's logged in the Javascript console");
            });
    };

    service.SearchRepositoriesByName = function (searchString, callback) {
        var url = '/GitHub/Search/?name=' + searchString;
        $log.log("Searching GitHub with URL: " + url);
        getUrl(url, callback);
    };

    service.GetRepositoryDetails = function(repoName, callback) {
        var url = '/GitHub/Stats/?FullName=' + repoName;
        $log.log("Getting repo details with URL: " + url);
        getUrl(url, callback);
    };

    service.GeNuGetPackage = function(packageName, callback) {
        var url = '/NuGet/package/' + packageName;
        $log.log("Getting NuGet package for from URL:" + url);
        getUrl(url, callback);
    };

    return service;
});


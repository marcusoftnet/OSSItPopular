function OssItPopularController($scope, $log, OssItPopularService) {

    $scope.searchRepos = function () {
        OssItPopularService.SearchRepositoriesByName($scope.searchString, SearchReposByNameSuccess);
    };
    
    $scope.getAllData = function (repo) {
        OssItPopularService.GetRepositoryDetails(repo.Name, GetRepositoryDetailsSuccess);
        OssItPopularService.GeNuGetPackage(repo.Name, GeNuGetPackageSuccess);
    };

    $scope.setCurrentNuGetPackage = function (nugetPackage) {
        $scope.NuGetResult.NugetPackage = nugetPackage;
        $scope.NuGetResult.MoreThanOneResult = false;
    };

    $scope.formatDate = function(jsonDate) {
        var d = new Date(parseInt(jsonDate.substr(6)));

        var curr_day = d.getDate();
        if (curr_day < 9)
            curr_day = "0" + curr_day;
        var curr_month = d.getMonth() + 1;
        if (curr_month < 9)
            curr_month = "0" + curr_month;
        var curr_year = d.getFullYear();

        var dateString = curr_year + "-" + curr_month + "-" + curr_day;

        return dateString;
    };
    
    function SearchReposByNameSuccess(data) {
        $scope.repositories = data.Repositories;
    };

    function GeNuGetPackageSuccess(data) {
        $scope.NuGetResult = {};
        $scope.NuGetResult.MoreThanOneResult = data.MoreThanOneResult;

        if (data.MoreThanOneResult)
            $scope.NuGetResult.NugetPackages = data.Packages;
        else 
            $scope.setCurrentNuGetPackage(data.Packages[0]);
    };
    

    function GetRepositoryDetailsSuccess(data) {
        $scope.gitHubDetails = data;
    };
};
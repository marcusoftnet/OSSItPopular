function GitHubController($scope, $log, OssItPopularService) {

    $scope.searchRepos = function () {
        OssItPopularService.SearchRepositoriesByName($scope.searchString, SearchReposByNameSuccess);
    };

    function SearchReposByNameSuccess(data) {
        $scope.repositories = data.Repositories;
    };

    $scope.getAllData = function (repo) {
        OssItPopularService.GetRepositoryDetails(repo.Name, GetRepositoryDetailsSuccess);
    };

    function GetRepositoryDetailsSuccess(data) {
        $scope.gitHubDetails = data;
    };
};
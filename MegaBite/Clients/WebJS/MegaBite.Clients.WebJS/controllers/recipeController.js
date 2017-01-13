/**
 * This controller will handle the bindings of the UI's related to recipes and their organizational data 
 * and will be responsible for getting or setting the data related to recipes.
 */

var recipeController = mainModule.controller("recipeController", ['$scope', 'recipeComponent', 'recipeService', function ($scope, recipeComponent, recipeService) {
    var self = this;

    // <Fields>

    var _self = {};

    $scope.ControllerName = "Recipe Controller";

    $scope.CurrentRecipe = {};

    // </Fields>

    // <Methods>

    self.GetRecipe = function (recipeId) {

        recipeService.GetRecipe(recipeId)
            .then(
		        function (response) {
		            // Success

		            // Always check if the response is not null or undefined before using it.
		            if (response) {
		                $scope.CurrentRecipe = recipeComponent.BuildRecipe(response);
		            }
		            return;
		        })
            .catch(
                function (error) {
                    // Error
                    console.error(error);
                });
    };

    self.Initialize = function () {

    };

    // </Methods>

    // <Constructor>

    (self.Constructor = function () {

        self.Initialize();

    })();

    // </Constructor>

    return self;
}]);
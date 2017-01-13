/**
 * 
 */
mainModule.service("recipeComponent", function () {
    var self = this;
    var _self = {};

    /*
    Builds a recipe model from a json response retrieved from the service.
    {jsonObj}: The json response from the service.
    */
    self.BuildRecipe = function (jsonObj) {
        var result = {};
        
        return result;
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
});

/**
 * 
 */
mainModule.factory("recipeService", function () {
    var self = this;

    // <Fields>

    var _self = {};

    // </Fields>


    // <Methods>

    /*
   Validates and executes a callback function to report back a response from the service
   {callback}: The callback function.
   {response}: The service response.
   */
    _self.Callback = function (callback, response) {
        if (callback)
            callback(response);
    };

    /*
    Gets the details for the current recipe
    {success}: The callback that returns the response on success.
    {error}: The callback that returns the error information.
    {notify}: The callback that notifies on progress for the request.
    */
    self.GetRecipe = function (RecipeId, success, error, notify) {

        return "recipe"
    };

    /*
    Initializes this instance of the service.
    */
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
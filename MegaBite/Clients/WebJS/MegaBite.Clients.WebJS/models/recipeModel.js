function RecipeModel(id, username, email) {

    var self = this;

    // <Fields>
    self.Id = id;
    self.UserName = username;
    self.Email = email;
    // </Fields>

    // Object interface
    return self;
};
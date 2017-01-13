var i = 0;
var fileCount = 0;

function createIngredientInput() {
    // new Input stored in element
    var element =
        $("<select>", {
            name: "ingredient" + i,
            id: "ingredient" + i,
            class: "form-control"
        }
    );

    // Add options based on the first Ingredient dropdown options.
    $("#Ingredients option").each(function () {
        element.append($('<option>', {
            value: $(this).val(),
            text: $(this).text()
        }))
    });

    //appending your New input
    $("#ingredientsSection").append("<br/>").append(element);
    i++;
}

function createFileInput() {
    //new Input stored in element
    if (fileCount == 4) {
        var element = $("<div>", {
            class: "text-warning",
            text: "You cannot exceed 5 files"
        })
        $("#fileSection").append(element);
    }
     else if (fileCount < 4) {
        var element = $("<input>", {
            //your Attributes
            name: "theInputName",
            type: "file",
            class: "margin5"
        });
        $("#fileSection").append(element);
    }
    fileCount++;
}
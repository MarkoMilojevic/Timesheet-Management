var Utility = function () {

    var loadContent = function (controllerActionUrl, destElemId) {
        var options = {
            url: controllerActionUrl,
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var $destElem = $(destElemId);
            $destElem.hide();
            $destElem.html(data);
            $destElem.fadeIn();
        });
    }

    var loadDropdown = function (parentDropdownId, dropdownId, url) {
        var $dropdown = $(dropdownId);
        var parentEntityId = $(parentDropdownId).val();
        if (!parentEntityId) {
            $dropdown.empty();
            $dropdown.val(null);
            $dropdown.trigger("change");
            return;
        }

        $.getJSON(url + parentEntityId, function (result) {
            $dropdown.empty();
            addOptionToDropdown($dropdown, null, null);

            $(result).each(function () {
                addOptionToDropdown($dropdown, this.Value, this.Text);
            });

            $dropdown.trigger("change");
        });
    }

    function addOptionToDropdown($dropdown, value, text) {
        $(document.createElement("option"))
            .attr("value", value)
            .text(text)
            .appendTo($dropdown);
    }

    return {
        LoadContent: loadContent,
        LoadDropdown: loadDropdown
    };

}();

$(document).ready(function () {
    $("#tab-content").ready(function () {
        var opt = {
            url: "/tasks/index",
            type: "get"
        };
        $.ajax(opt)
            .done(function (data) {
                var $contentElem = $("#tab-content");
                $contentElem.hide();
                $contentElem.html(data);
                $contentElem.fadeIn();
            });
    });

    $('a[data-tm-ajax="true"]').click(loadContent);

    function loadContent() {
        var $source = $(this);
        var options = {
            url: $source.attr("data-tm-action"),
            type: "get"
        };
        $.ajax(options)
            .done(function (data) {
                var contentElemId = $source.attr("data-tm-target");
                var $contentElem = $(contentElemId);
                $contentElem.hide();
                $contentElem.html(data);
                $contentElem.fadeIn();
        });
    }
});

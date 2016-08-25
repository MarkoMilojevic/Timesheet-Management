$(document).ready(function () {
    $("#tab-content").ready(function () {
        Utility.LoadContent("/tasks/index", "#tab-content");
    });

    $('a[data-tm-ajax="true"]').click(Utility.LoadContent($(this).attr("data-tm-action"), $(this).attr("data-tm-target")));
});

$(document).ready(function () {
    $("#tab-content").ready(function () {
        Utility.LoadContent($("#tab1").data("tm-action"), $("#tab1").data("tm-target"));
    });

    $('a[data-tm-ajax="true"]').click(Utility.LoadContent($(this).data("tm-action"), $(this).data("tm-target")));
});

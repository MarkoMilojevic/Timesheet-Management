$(document).ready(function () {
    $("#tab-content").ready(function () {
        Utility.LoadContent($("#tab1").attr("data-tm-action"), $("#tab1").attr("data-tm-target"));
    });

    $('a[data-tm-ajax="true"]').click(Utility.LoadContent($(this).attr("data-tm-action"), $(this).attr("data-tm-target")));
});

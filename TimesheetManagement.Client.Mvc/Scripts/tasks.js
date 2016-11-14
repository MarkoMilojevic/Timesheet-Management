$(document).ready(function () {
    $("#accordion").on("show.bs.collapse", function (e) {
        Utility.LoadContent($("#add-activity-accordian").data("tm-action"), $("#add-activity-accordian").data("tm-target"));
    });

    $("[data-toggle='collapse']").click(function (e) {
        e.preventDefault();
        var collapseableElem = $(this).attr("href");
        $(collapseableElem).collapse("toggle");
        return false;
    });
});

$(document).ready(function () {
    $("#accordion").on("show.bs.collapse", function (e) {
        Utility.LoadContent("/tasks/gettaskactivity", "#collapseOneBody");
    });

    $('[data-toggle="collapse"]').click(function (e) {
        e.preventDefault();
        var collapseableElem = $(this).attr("href");
        $(collapseableElem).collapse("toggle");
        return false;
    });
});

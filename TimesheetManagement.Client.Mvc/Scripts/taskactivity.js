$(document).ready(function () {
    $("#accountsDropdown").change(function () {
        Utility.LoadDropdown("#" + this.id, "#projectsDropdown", "/tasks/getprojects?accountId=");
    });

    $("#projectsDropdown").change(function () {
        Utility.LoadDropdown("#" + this.id, "#tasksDropdown", "/tasks/gettasks?projectId=");
    });
});

﻿$(document).ready(function () {
    $("#accounts-dropdown").change(function () {
        Utility.LoadDropdown("#" + this.id, "#projects-dropdown", "/tasks/getprojects?clientId=");
    });

    $("#projects-dropdown").change(function () {
        Utility.LoadDropdown("#" + this.id, "#tasks-dropdown", "/tasks/gettasks?projectId=");
    });
});

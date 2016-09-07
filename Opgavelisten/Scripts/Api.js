$(document).ready(function () {
    var prefix = "Opgaveliste-";
    var Opgave = prefix + "opgave";
    var storage = localStorage; //sessionStorage ved større og aktiv shop

    function GetTasks() {
        $("#task").empty();
        $.ajax({
            url: "api/tasks/"
        })
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { class: 'pull-left list-group-item list-item', text: OutputText(item) })
                .append($('<a>', { class: 'deleteTask btn btn-danger btn-lg btn-style', "data-id": item.Id, text: "Slet", href: "#" }))
                .append($('<a>', { class: 'editTask btn btn-primary btn-lg btn-style', "data-id": item.Id, text: "redigér", href: "#" }))
                .appendTo($("#task"));
            });
            $(".deleteTask").on("click", function () {
                var id = $(this).data().id;
                $.ajax({
                    url: "api/tasks/" + id,
                    method: "DELETE"
                }).done(function (data) {
                });
            });

            $('.editTask').on("click", function () {
                var id = $(this).data().id;
                $.ajax({
                    url: "api/tasks/" + id,
                    method: "GET"
                }).done(function (data) {
                    $('#editId').val(data.Id)
                    $('#editName').val(data.Name)
                    $('#editDate').val(data.DateCreated)
                    $('#editCategoryId').val(data.CategoryId)
                    $('#editAssignmentState').val(data.FinishedAssignment)
                });
            });

        });
    };
    GetTasks();

    //OPRET OPGAVE
    $("#btnCreate").on("click", function () {
        var data = $("#createTask").serialize();

        console.log(data);
        $.ajax({
            url: "api/tasks/",
            method: "POST",
            data: data
        }).done(function (data) {
            GetTasks();
        });
    });

    $("#btnEdit").on("click", function () {
        console.log(data);
        var data = $("#editTask").serialize();
        $.ajax({
            url: "api/tasks/",
            method: "PUT",
            data: data
        }).done(function (data) {
            GetTasks();
            $("#editId").val('');
            $("#editName").val('');
            $("#editDate").val('');
            $("#editCategoryId").val('');
            $("#editAssignmentState").val('');
        });
    });

    function OutputText(item) {
        return item.Name + " " + item.CategoryId + " " + item.DateCreated + " " + item.FinishedAssignment;
    }
});
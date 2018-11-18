
//Users View Functions
function getUsers() {
    $.getJSON("/api/users/get",
        function (data) {
            $.each(data, function (key, val) {
                $.getJSON(
                    {
                        url: "/api/tasks/getUserTasksCount/" + val.Id,
                        async: false
                    },
                    function (taskCount) {
                        $.getJSON("/api/tasks/getUserCompletedTasks/" + val.Id,
                            function (completed) {
                                $("<tr id=User_" + val.Id + ">" +
                                    "<td contenteditable=true id=userFirst_" + val.Id + ">" + val.First_Name + "</td>" +
                                    "<td contenteditable=true id=userLast_" + val.Id + ">" + val.Last_Name + "</td>" +
                                    "<td contenteditable=true class=age id=userAge_" + val.Id + ">" + val.Age + "</td>" +
                                    "<td>" + taskCount + "</td>" +
                                    "<td>" + completed + "</td>" +
                                    "<td><a href=/Home/UserInfo/" + val.Id + ">Show tasks</a>|<a href='/home/' onclick=updateUser(" + val.Id + ")>Edit</a>|<a href='/home/' onclick=deleteUser(" + val.Id + ")>Delete</a></td>" +
                                    "</tr>").appendTo($('.table'));
                            });

                    });

            });
        });
}

function createUser() {
    var userData = {
        First_Name: document.getElementById("first_name").value,
        Last_Name: document.getElementById("last_name").value,
        Age: document.getElementById("age").value

    };
    if (Number.isInteger(+userData.Age)) {
        return $.ajax({
            type: "POST",
            data: JSON.stringify(userData),
            url: "/api/users/create",
            contentType: "application/json",
            dataType: "json",
            async: false,
            success: function (data, textStatus, error) {
                return;
            },
            error: function (data, textStatus, error) {
                alert("Insert Errror");
            }
        });
    }
    else alert("Age must be a number");
}

function updateUser(id) {
    var data = {
        First_Name: document.getElementById("userFirst_" + id).innerHTML,
        Last_Name: document.getElementById("userLast_" + id).innerHTML,
        Age: document.getElementById("userAge_" + id).innerHTML,
        Id: id
    };
    if (Number.isInteger(+data.Age)) {
        return $.ajax({
            type: "PUT",
            data: JSON.stringify(data),
            async: false,
            contentType: "application/json",
            datatype: 'json',
            url: "/api/users/update/",
            success: function () {
            },
            error: function () {
                alert("Insert error");
            }

        });
    }
    else {
        alert("Age must be a number");
    }
}

function deleteUser(id) {

    return $.ajax({
        type: "DELETE",
        async: false,
        url: "/api/users/delete/" + id,
        success: function (data, textStatus, error) {
            return;
        },
        error: function (data, textStatus, error) {
        }
    });

}


//UserInfo View functions
function showUserInfo(id) {
    $.get("/api/users/get/" + id,
        function (user) {
            $("<h1>User's " + user.First_Name + " " + user.Last_Name + " info</h1>").appendTo("#info");
            $.get("/api/tasks/getusertaskscount/" + id,
                function (count) {
                    $.get("/api/tasks/getUserCompletedTasks/" + id,
                        function (completed) {
                            $("<p style='float:right'>Total Tasks: " + count + ", Completed Tasks: " + completed + "</p>").appendTo("#info");

                            $.each(user.Tasks, function (key, val) {
                                if (val.Completed) {
                                    var completed = "Completed";
                                }
                                else { var completed = "Not completed"; }
                                $("<tr id='Task_" + val.Name + "'>" +
                                    "<td contenteditable=true id=TaskName_" + val.Id + ">" + val.Name + "</td>" +
                                    "<td onclick=changeStatus(" + val.Id + ") id=currentStatus_" + val.Id + ">" + completed + "</td>" +
                                    "<td><a onclick=updateTask(" + val.Id + ") href='/home/userinfo/" + id + "'>Update</a>|<a onclick=deleteTask(" + val.Id + ") href='/home/userinfo/" + id + "'>Delete</a></td>" +
                                    "</tr>").appendTo(".table");
                                $("<tr ></>")
                            });
                        });
                });
        });
}


function deleteTask(taskId) {

    return $.ajax({
        type: "DELETE",
        url: "/api/tasks/delete/" + taskId,
        success: function (data, textStatus, error) {
            return;
        },
        error: function (data, textStatus, error) {

        }
    });

}

function updateTask(id) {
    if (document.getElementById("currentStatus_" + id).innerHTML == "Completed") {
        var status = true;
    }
    else var status = false;
    var taskData = {
        Name: document.getElementById("TaskName_" + id).innerHTML,
        Completed: status,
        User_id: document.getElementById("user_id").value,
        Id: id
    };
    return $.ajax({
        type: "PUT",
        data: JSON.stringify(taskData),
        async: false,
        contentType: "application/json",
        datatype: 'json',
        url: "/api/tasks/update/" + id,
        success: function () {
            return;
        },
        error: function () {
            alert(JSON.stringify(taskData));
        }

    });
}

function createTask() {
    var taskData = {
        Name: document.getElementById("task_name").value,
        Completed: document.getElementById("status").checked,
        User_id: document.getElementById("user_id").value

    };
    return $.ajax({
        type: "POST",
        data: JSON.stringify(taskData),
        url: "/api/tasks/create",
        contentType: "application/json",
        async: false,
        dataType: "json",
        success: function (data, textStatus, error) {
            return;
        },
        error: function (data, textStatus, error) {

        }
    });
}

function changeStatus(id) {
    x = document.getElementById("currentStatus_" + id);
    if (x.innerHTML === "Completed") {
        x.innerHTML = "Not completed";
    }
    else x.innerHTML = "Completed";

}







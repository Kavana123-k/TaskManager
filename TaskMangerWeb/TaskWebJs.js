
var url =
    "http://localhost:8090/api/Task/";

var tasks = [];
var id;

function loaddisplay() {
    document.getElementById('loading').style.display = "block";
}

function loadhidden() {
    document.getElementById('loading').style.display = "none";
}

function loadfunction() {
    //document.getElementById('loading').style.display = "block";
    loaddisplay();
}

window.onload = function () {
    //document.getElementById('loading').style.display = "none";
    loadhidden();
    getAllTask();

}

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-center",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function addTaskDetails() {
    document.getElementById("addsubmit").style.display = "block";
    document.getElementById("editsubmit").style.display = "none";
}

function add(tasks) {
    var tableBody = document.querySelector('#dataTable tbody');
    if (tableBody) {
        if (tasks !== null) {
            for (var i = 0; i < tasks.length; i++) {
                var status;
                var today = new Date();
                // var date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
                var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
                var time = today.getHours() + ':' + today.getMinutes() + ':' + today.getSeconds();
                var et = date + ' ' + time;
                var endtime1;
                console.log(tasks[i]);
                var task = tasks[i];
                if (task.status == 'Open') {
                    status = '<span class="badge bg-warning text-dark">' + task.status + '</span>';
                }
                else if (task.status == 'Closed') {
                    status = '<span class="badge bg-success">' + task.status + '</span>';
                }
                else if (task.status == 'Inprogress') {
                    status = '<span class="badge bg-primary">' + task.status + '</span>';
                }
                else if (task.status == 'Onhold') {
                    status = '<span class="badge bg-secondary">' + task.status + '</span>';
                }
                else {
                    status = '<span class="badge bg-light text-dark">' + task.status + '</span>';
                }
                if (task.endTime < et) {
                    endtime1 = '<p style="color:red">' + task.endTime + '</p>';
                }
                else {
                    endtime1 = '<p style="color:black">' + task.endTime + '</p>';
                }
                let htmlText = '<tr><td>' + task.name + '</td>';
                htmlText += '<td>' + status + '</td>';
                htmlText += '<td>' + task.description + '</td>';
                htmlText += '<td>' + task.createdTime + '</td>';
                htmlText += '<td>' + endtime1 + '</td>';
                htmlText += '<td>' + "<button type='button' onclick='editTaskDetails(" + JSON.stringify(task) + ") ' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#exampleModal' > <i class='fas fa-edit'></i> " + "</button> " + '</td > ';
                htmlText += '<td>' + "<button type = 'button' onclick = 'deleteTask(" + task.id + ")' class='btn btn-primary' > " + " <i class='fas fa-trash' ></i> " + "</button > " + '</td></tr>';
                tableBody.innerHTML += htmlText;
            }
        }
    }
}

function editTaskDetails(task) {
    document.getElementById("editsubmit").style.display = "block";
    document.getElementById("addsubmit").style.display = "none";
    //var datetime = createdTime;
    document.getElementById("taskid").value = task.id;
    document.getElementById("name").value = task.name;
    document.getElementById("status").value = task.status;
    document.getElementById("description").value = task.description;
    document.getElementById("sdate").value = task.createdTime.split(' ')[0];
    document.getElementById("stime").value = task.createdTime.split(' ')[1];
    document.getElementById("edate").value = task.endTime.split(' ')[0];
    document.getElementById("etime").value = task.endTime.split(' ')[1];
}

function addTask(task) {
    document.getElementById("tablebody").innerHTML = " ";
    var id = document.getElementById("taskid").value;
    var name = document.getElementById("name").value;
    var e = document.getElementById("status");
    var status = e.value;
    var description = document.getElementById("description").value;
    var startdate = document.getElementById("sdate").value;
    var starttime = document.getElementById("stime").value;
    // var createdTime = startdate + ' ' + starttime;
    var enddate = document.getElementById("edate").value;
    var endtime = document.getElementById("etime").value;
    // var endTime = enddate + ' ' + endtime;
    var obj = {
        id: id,
        name: name,
        status: status,
        description: description,
        createdTime: startdate + ' ' + starttime,
        endTime: enddate + ' ' + endtime,
    };
    // document.getElementById('loading').style.display = "block"
    loaddisplay();
    const userAction = async () => {
        const response = await fetch((url + "create"), {
            method: 'POST',
            body: JSON.stringify(obj),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status == 201) {
            //  document.getElementById('loading').style.display = "none"
            loadhidden();
            getAllTask();
            toastr.success('Task addeded successfully', 'Success');
        }
        else if (response.status == 500) {

            toastr.error('Adding Task details failed', 'Failure');
        }
        else if (response.status == 404) {

            toastr.warning('Server not connected', 'warning');
        }
        else {
            toastr.info('User pending action');
        }
    }
    var response = userAction();
}

function editTask(task) {
    document.getElementById("tablebody").innerHTML = " ";
    var id = document.getElementById("taskid").value;
    var name = document.getElementById("name").value;
    var e = document.getElementById("status");
    var status = e.value;
    var description = document.getElementById("description").value;
    var startdate = document.getElementById("sdate").value;
    var starttime = document.getElementById("stime").value;
    // var createdTime = startdate + ' ' + starttime;
    var enddate = document.getElementById("edate").value;
    var endtime = document.getElementById("etime").value;
    // var endTime = enddate + ' ' + endtime;
    var obj = {
        id: id,
        name: name,
        status: status,
        description: description,
        createdTime: startdate + ' ' + starttime,
        endTime: enddate + ' ' + endtime,
    };

    // document.getElementById('loading').style.display = "block";
    loaddisplay();
    const userAction = async () => {
        const response = await fetch((url + "Edit?id=" + id), {
            method: 'POST',
            body: JSON.stringify(
                obj
            ),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.status == 200) {
            // document.getElementById('loading').style.display = "none"
            loadhidden();
            getAllTask();
            toastr.success('Task updated successfully', 'Success');
        }
        else if (response.status == 304) {
            toastr.error('Update task failed', 'Failure');
        }
        else if (response.status == 404) {

            toastr.warning('Server not connected', 'warning');
        }
        else {
            toastr.info('User pending action');
        }
    }
    var response = userAction();
}


function deleteTask(id) {
    var deleteconfirm = confirm("Are you sure you want to delete?");
    if (deleteconfirm) {
        document.getElementById("tablebody").innerHTML = " ";
        // document.getElementById('loading').style.display = "block";
        loaddisplay();
        const userAction = async () => {
            const response = await fetch((url + "Delete?id=" + id), {
                method: 'DELETE',
                //body: JSON.stringify({id:id}),
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (response.status == 200) {
                //document.getElementById('loading').style.display = "none"
                loadhidden();
                getAllTask();
                toastr.success('Task deleted successfully', 'Success');
            }
            else if (response.status == 304) {
                toastr.error('Failed to delete the task', 'Failure');
            }
            else if (response.status == 404) {

                toastr.warning('server not connected', 'warning');
            }
            else { toastr.info('User pending action'); }

        }
        var response = userAction();
        return true;
    }

}

function getAllTask() {
    //document.getElementById('loading').style.display = "block";
    loaddisplay();
    const userAction = async () => {
        const response = await fetch((url + "GetAll"), {
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        }).catch(function (err) {
            //console.log('Fetch Error :-S', err);

            toastr.warning('Server not reachable', 'Warning');
            //document.getElementById('loading').style.display = "none"----
        });
        //document.getElementById('loading').style.display = "none"
        loadhidden();
        const myJson = await response.json();
        console.log(response);
        console.log(myJson);
        add(myJson);
    }
    var response = userAction();
}

function getTask(id) {

    const userAction = async () => {
        const response = await fetch((url + "Get?id=" + id), {
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        });
        const myJson = await response.json();
        console.log(response);
        console.log(myJson);
        return myJson;
    }
    var response = userAction();
}

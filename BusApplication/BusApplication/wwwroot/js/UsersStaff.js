var dataTable;

$(document).ready(function () {
    var url = window.location.search;

    if (url.includes("employee")) {
        loadDataTable("GetAllEmployee");
    }
    else if (url.includes("admin")) {
        loadDataTable("GetAllAdmin");
    }
    else if (url.includes("user")) {
        loadDataTable("GetAllUser");
    }
    else {
        loadDataTable("GetAll");
    }
});

function loadDataTable(url) {

    dataTable = $('#tblData').DataTable({
        searching: false,
        "ajax": {
            "url": "/staff/users/" + url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nick", "width": "15%" },
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "roles", "width": "15%" },
            { "data": "isActive", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/staff/users/details/${data}" class='btn btn-success text-white mb-1' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Szczegóły
                                </a>
                            </div>
                            <div class="text-center">
                                <a href="/staff/users/changeStatus/${data}" class='btn btn-success text-white mb-1' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Zablokuj Odblokuj
                                </a>
                            </div>
                            `;
                }, "width": "10%"
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Polish.json"
        },
        "width": "100%"
    });
}



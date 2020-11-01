var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("approved")) {
        loadDataTable("GetAllApproved");
    }
    else {
        if (url.includes("pending")) {
            loadDataTable("GetAllPending");
        }
        else {
            loadDataTable("GetAll");
        }
    }


});

function loadDataTable(url) {

    dataTable = $('#tblData').DataTable({
        searching: false,
        "ajax": {
            "url": "/staff/messages/" + url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "mail", "width": "20%" },
            { "data": "title", "width": "20%" },
            {
                "data": "date",
                "render": function (data) {
                    return data.substring(0, 10);
                },
                "width": "20%"
            },
            {
                "data": "status",
                "render": function (data) {
                    if (data == true) {
                        return 'Wysłano odpowiedź';
                    }
                    else {
                        return 'Oczekujące';
                    }
                },
                "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Staff/messages/Details/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Szczegóły
                                </a>           
                            </div>
                            `;
                }, "width": "20%"
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Polish.json"
        },
        "width": "100%"
    });
}

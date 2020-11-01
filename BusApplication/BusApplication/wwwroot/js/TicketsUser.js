var dataTable;

$(document).ready(function () {
    var url = window.location.search;

    if (url.includes("approved")) {
        loadDataTable("GetAllApproved");
    }
    else if (url.includes("pending")) {
        loadDataTable("GetAllPending");
    }
    else if (url.includes("canceled")) {
        loadDataTable("GetAllCanceled");
    }
    else {
        loadDataTable("GetAll");
    }
});

function loadDataTable(url) {

    dataTable = $('#tblData').DataTable({
        searching: false,
        "ajax": {
            "url": "/user/tickets/" + url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "date", "width": "10%" },
            { "data": "startBusStopName", "width": "10%" },
            { "data": "departure", "width": "10%" },
            { "data": "endBusStopName", "width": "10%" },
            { "data": "arrival", "width": "10%" },
            {
                "data": "numberOfNormalTickets",
                "render": function (data) {
                    return data + ' szt.';
                },
                "width": "10%"
            },
            {
                "data": "numberOfStudentsTickets",
                "render": function (data) {
                    return data + ' szt.';
                },
                "width": "10%"
            },
            {
                "data": "numberOfExtraBaggages",
                "render": function (data) {
                    return data + ' szt.';
                },
                "width": "10%"
            },
            {
                "data": "paymentStatus",
                "render": function (data) {
                    if (data == "New") {
                        return 'Nowy';
                    }
                    else if (data == "Confirmed") {
                        return 'Aktywny';
                    }
                    else {
                        return 'Anulowany';
                    }
                },
                "width": "10%"
            },
            {
                "data": "ticketId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/user/tickets/details/${data}" class='btn btn-success text-white mb-1' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Szczegóły
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

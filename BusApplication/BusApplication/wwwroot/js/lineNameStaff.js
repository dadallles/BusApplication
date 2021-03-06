﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        searching: false,
        "ajax": {
            "url": "/staff/lineName/GetAllAsList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "stationList", "width": "50%" },
            {
                "data": "isActive",
                "render": function (data) {
                    if (data == true) {
                        return 'Tak';
                    }
                    else {
                        return 'Nie';
                    }
                },
                "width": "10%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/staff/lineName/Update/${data}" class='btn btn-success text-white mb-1' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Zmień
                                </a>
                                <br />
                                <a onclick=ChangeStatus("/staff/lineName/ChangeStatus/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class="fas fa-retweet"></i> Status
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

function ChangeStatus(url) {
    swal({
        title: "Jesteś pewnien, że chcesz zmienić status aktywności tej linii?",
        text: "Linia może przestać być widoczna!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Anuluj",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Tak",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'PUT',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}


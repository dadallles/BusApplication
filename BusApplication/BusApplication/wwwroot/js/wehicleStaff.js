var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        searching: false,
        "ajax": {
            "url": "/staff/wehicle/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "brand", "width": "20%" },
            { "data": "model", "width": "20%" },
            { "data": "yearOfManufacture", "width": "10%" },
            { "data": "numberOfSeats", "width": "10%" },
            {
                "data": "airConditioning",
                "render": function (data) {
                    if (data == true) {
                        return 'Tak';
                    }
                    else {
                        return 'Nie';
                    }
                },
                "width": "5%"
            },
            {
                "data": "premiumClass",
                "render": function (data) {
                    if (data == true) {
                        return 'Tak';
                    }
                    else {
                        return 'Nie';
                    }
                },
                "width": "5%"
            },
            {
                "data": "toilet",
                "render": function (data) {
                    if (data == true) {
                        return 'Tak';
                    }
                    else {
                        return 'Nie';
                    }
                },
                "width": "5%"
            },
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
                "width": "5%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/staff/wehicle/UpdateInsert/${data}" class='btn btn-success text-white mb-1' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Edytuj
                                </a>
                                <br />
                                <a onclick=ChangeStatus("/staff/wehicle/ChangeStatus/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class="fas fa-retweet"></i> Status
                                </a>
                            </div>
                            `;
                }, "width": "30%"
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
        title: "Jesteś pewnien, że chcesz zmienić status aktywności pojazdu?",
        text: "Pojazd może przestać być widoczny!",
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


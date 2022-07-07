//import { ajax } from "jquery";

$(document).ready(function () {
    get();
    $('#table tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" id="' + title + '" placeholder="Search ' + title + '" />');
    });
    $('#CreatedOn').attr('type', "date");
    $('#Name').on('keyup', function (data) {
        var data = $('#Name').val();
        $('#table').DataTable().ajax.url(`/getAllCustomers?nameSearch=` + data).load();
    });

    $('#FName').on('keyup', function (data) {
        var data = $('#FName').val();
        $('#table').DataTable().ajax.url(`/getAllCustomers?fnameSearch=` + data).load();
    });
    $('#Phone').on('keyup', function (re) {
        var data = $("#Phone").val();
        $('#table').DataTable().ajax.url(`/getAllCustomers?phone=` + data).load();
    });
    $('#CreatedOn').on('keyup', function (data) {
        var data = $("#Phone").val();
        $('#table').DataTable().ajax.url(`/getAllCustomers?createdOn=` + data).load();
    });
    $('#0').on('change', function () {
        let value = $(this).is(":checked");
        $('#table').DataTable().column(0).visible(value);
    });
    $('#1').on('change', function () {
        let value = $(this).is(":checked");
        $('#table').DataTable().column(1).visible(value);
    });
    $('#2').on('change', function () {
        let value = $(this).is(":checked");
        $('#table').DataTable().column(2).visible(value);
    });
    $('#3').on('change', function () {
        let value = $(this).is(":checked")
            ;//.prop().isChecked;
        $('#table').DataTable().column(3).visible(value);
    });
    $('#4').on('change', function () {
        let value = $(this).is(":checked");
        $('#table').DataTable().column(4).visible();
    });
    //$('#5').on('change', function () {
    //    let value = $(this).is(':checked');
    //    $('#table').DataTable().column(5).visible(value);
    //});
});

function get() {
    var table = $('#table').dataTable({
        "bServerSide": true,
        "sAjaxSource": '/GetAllCustomers',
        "bProcessing": true,
        "aoColumns": [
            { "mData": "Name", "searchable": true ,"bSortable": true},
            { "mData": "Fname", "searchable": true ,"bSortable": true},
            { "mData": "Phone" ,"bSortable": true},
            { "mData": "CreatedOn","bSortable": true },
            {
                'mData': function (data) {
                    return `<a href="#" class="btn btn-danger delete_btn" onclick="deleteFunc(\`` + '' + data.Id + `\`);" >
    <i class="fa fa-trash" aria-hidden="true">
    </i></a><a href="#" onclick="edit(\``+ '' + data.Id + `\`);" class=" m-2 btn btn-primary">
    <i class="fa fa-pencil" aria-hidden="true"clas="fa fa-pencil" ></i></a>`;
                    //"<a href='#' onclick='edit(" + data.Id + ")' class='btn btn-primary'>  <i class='fa fa-pencil' aria-hidden='true' class='fa fa-pencil' ></i>Edit</a> | <a href='#' onclick='deleteFunc(" + data.Id.toString() + ")' class='btn btn-danger'> Delete</a>";
                }
            }]
    });
    //var table = $("#table").dataTable({
    //    "processing": true,
    //    "serverSide": true,
    //    //"filter":true,
    //    "searching": { "regex": true },
    //    "ajax": {
    //        url: "/getAllCustomers",
    //        type: "GET",
    //        "dataSrc": ""
    //    },
    //    "columns": [
    //        { "data": "name" },
    //        { "data": "fname" },
    //        { "data": "phone" },
    //        { "data": "createdOn" },
    //        {
    //            "data": function (elem) {
    //                return `<a href="#" class="btn btn-danger delete_btn" onclick="deleteFunc(\`` + '' + elem.id + `\`);" >
    //<i class="fa fa-trash" aria-hidden="true">
    //</i></a><a href="#" onclick="edit(\``+ '' + elem.id + `\`);" class=" m-2 btn btn-primary">
    //<i class="fa fa-pencil" aria-hidden="true"clas="fa fa-pencil" ></i></a>`;
    //                //"<a href='#' onclick='edit(" + data.id + ")' class='btn btn-primary'>  <i class='fa fa-pencil' aria-hidden='true' class='fa fa-pencil' ></i>Edit</a> | <a href='#' onclick='deleteFunc(" + data.id + ")' class='btn btn-danger'> Delete</a>";
    //            }
    //        }
    //    ],
    //});

    //setInterval(function () {
    //    table.ajax.reload();
    //}, 3000);
    //    $.ajax({
    //        type: "GET",
    //        url: "/getAllCustomers",
    //        //data: JSON.stringify(model),
    //        dataType: "json",
    //        contentType: 'application/json; charset=utf-8',
    //        success: function (data) {
    //            $("#con").html(` <table class="table table-default table-striped table-hover w-100" id="table">
    //            <tobdy>
    //                <tr>
    //                    <th>Name</th>
    //                    <th>Fname</th>
    //                    <th>Phone</th>
    //                    <th>CreatedOn</th>
    //                    <th class="">Action</th>
    //                </tr>
    //            </tobdy>

    //        </table> `);
    //            var table = $("#table tbody");
    //            $.each(data, function (idx, elem) {
    //                table.append(`<tr>
    //<td id="${idx}" class="d-none">` + elem.id + `</td>
    //<td>` + elem.name +
    //                    `</td><td>` + elem.fname +
    //                    `</td>  
    //              <td>` + elem.phone + `</td>
    //              <td>` + elem.createdOn + `</td>
    //              <td> <a href="#" class="btn btn-danger delete_btn" onclick="deleteFunc(\``+ '' + elem.id + `\`);" >
    //<i class="fa fa-trash" aria-hidden="true">
    //</i></a><a href="#" onclick="edit(\``+ '' + elem.id + `\`);" class=" m-2 btn btn-primary">
    //<i class="fa fa-pencil" aria-hidden="true"clas="fa fa-pencil" ></i></a>
    //</td>
    //</tr>`);
    //            });
    //        },
    //        error: function () {
    //            alert("Error occured!!");
    //        }
    //    });

}

function edit(id) {
    var _url;
    id != null ? _url = "/addCustomer?id=" + id : _url = "/addCustomer";
    $.ajax({
        type: "GET",
        //async: true,
        //dataType: "json",
        url: _url,
        //contentType: "application/json; charset=utf-8",
        success: function (res) {
            var modal = $("#exampleModal");
            modal.html(res);
            $('#exampleModal').modal('show');
            //$('#table').DataTable().ajax.reload();
        },
        error: function (err) {
            alert("erro!");
            console.log(err);
        }

    });
}
function submitForm(isEdit) {
    var _id = $("#cus_id").val();
    var _name = $("#name").val();
    var _fname = $("#fname").val();
    var _phone = $("#phone").val();

    if (isEdit > 0) {
        var model = {
            id: _id,
            name: _name,
            fname: _fname,
            phone: _phone
        }
        $.ajax({
            type: "POST",
            url: "/updateCustomer",
            contentType: "application/json; charset=utf-8",
            //contentType: "json",
            data: JSON.stringify(model),
            success: function (data) {
                $('#table').DataTable().ajax.reload();
                //alert(data);
                //get();
                $('#exampleModal').modal('hide');

            }
        });

    }
    else {
        var createmodel = {
            name: _name,
            fname: _fname,
            phone: _phone
        };
        $.ajax({
            type: "POST",
            url: "/createCustomer",
            contentType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(createmodel),
            success: function (data) {
                $("#exampleModal").modal('show');
                //$("#table").dataTable().ajax.reload();
                //get();
                $('#table').DataTable().ajax.reload();
                $('#exampleModal').modal('hide');
                //$('#exampleModal').modal('close');

            }
        });
    }
}

//function showHide(e, id) {

//$('#table').DataTable().column(id).visible($('' + id + '').val());
//}
//}

function deleteFunc(id) {
    let is = confirm("are you sure?");
    if (is) {
        $.ajax({
            type: "POST",
            async: true,
            data: JSON.stringify(id),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            url: "/delete",
            success: function (res) {
                alert("customer succesfully deleted");
                $('#table').DataTable().ajax.reload();

                ////get();
            }, error: function () {
                console.log("some thing went wrong");
            }
        });
    }
}
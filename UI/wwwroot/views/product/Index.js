$(document).ready(function () {
    get();
    $('#table tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" id="' + title + '" placeholder="Search ' + title + '" />');
    });
    $('#CreatedOn').attr('type', "date");
    $('#Name').on('keyup', function (data) {
        var data = $('#Name').val();
        setTimeout(function () {

            $('#table').DataTable().ajax.url(`/getAllCustomers?nameSearch=` + data).load();
        }, 700);
    });

    $('#FName').on('keyup', function (data) {
        var data = $('#FName').val();
        setTimeout(function () {
            $('#table').DataTable().ajax.url(`/getAllCustomers?fnameSearch=` + data).load();
        }, 700);
    });
    $('#Phone').on('keyup', function (re) {
        var data = $("#Phone").val();
        setTimeout(function () {
            $('#table').DataTable().ajax.url(`/getAllCustomers?phone=` + data).load();
        }, 1000);
    });
    $('#CreatedOn').on('keyup', function (data) {
        var data = $("#Phone").val();
        setTimeout(function () {
            $('#table').DataTable().ajax.url(`/getAllCustomers?createdOn=` + data).load();
        }, 700);
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
});
function get() {
    var table = $('#table').dataTable({
        "bServerSide": true,
        "sAjaxSource": '/GetAllCustomers',
        "bJQueryUI": true,

        "bSortable_1": true,
        "bProcessing": true,
        "bSort": true, "bJQueryUI": true,

        "sDom": 'Rlfrtip',
        "oColReorder": {
        },
        "aoColumns": [
            { "mData": "Name", "searchable": true, "bSortable": true },
            { "mData": "Fname", "searchable": true, "bSortable": true },
            { "mData": "Phone", "bSortable": true },
            { "mData": "CreatedOn", "bSortable": true },
            {
                'mData': function (data) {
                    return `<a href="#" class="btn btn-danger delete_btn" onclick="deleteFunc(\`` + '' + data.Id + `\`);" >
    <i class="fa fa-trash" aria-hidden="true">
    </i></a><a href="#" onclick="edit(\``+ '' + data.Id + `\`);" class=" m-2 btn btn-primary">
    <i class="fa fa-pencil" aria-hidden="true"clas="fa fa-pencil" ></i></a>`;
                }
            }]
    });

}
function edit(id) {
    var _url;
    id != null ? _url = "/addCustomer?id=" + id : _url = "/addCustomer";
    $.ajax({
        type: "GET",

        url: _url,

        success: function (res) {
            var modal = $("#exampleModal");
            modal.html(res);
            $('#exampleModal').modal('show');
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
            data: JSON.stringify(model),
            success: function (data) {
                $('#table').DataTable().ajax.reload();

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

                $('#table').DataTable().ajax.reload();
                $('#exampleModal').modal('hide');


            }
        });
    }
}
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

            }, error: function () {
                console.log("some thing went wrong");
            }
        });
    }
}
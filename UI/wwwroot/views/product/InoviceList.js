$(document).ready(function () {
    getList();
});

function getList() {

    var table = $("#table").dataTable({
        "processing": '<div><h2>Loading...</h2></div>',
        "serverSide": true,
        "paging": true,
        "searching": { "regex": true },
        "ajax": {
            url: "/getInvoiceList",
            type: "GET",
            "dataSrc": ""
        },
        "columns": [
            { "data": "id" },
            { "data": "items" },
            { "data": "subTotal" },
            { "data": "discount" },
            { "data": "total" },
            {
                "data": function (elem) {
                    return `<button onclick="edit(\`` + '' + elem.id + `\`);" class=" m-2 btn btn-primary">
    <i class="fa fa-pencil" aria-hidden="true"clas="fa fa-pencil" ></i></button>`;
                }
            }
        ],
    });

}


function edit(id) {
    alert(id);
}
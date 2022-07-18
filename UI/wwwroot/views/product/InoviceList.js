$(document).ready(function () {
    getList();
});

function getList() {
    ("#table").DataTable({
        "serverside": true,
        "processing": true,
        ajax: {
            url: "/getInoviceList",
            type: "GET"
        },
        success: function (data) {

        }
    });

}
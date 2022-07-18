$(document).ready(function () {
    var list = null;
    list = getProductList();
    console.log(list);
    $('#addItems').off('click').on('click', function () {
        var id = generateGuid();
        $('#tbl').append(`<tr id="${id}">
                                                    <td>
                                                       <select id="sel`+ id + `" name="productId" onchange="changeSelection(this,'` + id + `')">
<option value="null">select a product</option>
</select>
                                                    </td>
<td id="`+id+`id" class=" d-none childId"></td>
                                                    <td id="`+ id + `price" class="price"><h5></h5></td>
                                                    <td id="`+ id + `des" class="desc"><h5></h5></td>
                                                    <td class="qty"><input type="number" id="`+ id + `qty" class="form-control " onchange="qtyChange('` + id + `')"/></td>
                                                    <td id="`+ id + `total" class="total total" ><h5></h5></td>
                                                    <td><h5>
<button class='btn btn-danger' onclick="removeRow('`+ id + `' )"> remove</button>
</h5></td>
                                                </ tr >
`);
        $.each(list, function (index, elem) {
            $('#sel' + id).append(`<option value="${elem.id}">${elem.name}</option>`);
        })
    });
});

function changeSelection(e, id) {
    $.ajax({
        url: "/GetProdcut?id=" + e.value,
        method: "GET",
        success: function (data) {
            debugger
            $(`#${id}price`).html(data.price);
            $(`#${id}id`).html(data.id);
            $(`#${id}des`).html(data.description);
            $(`#${id}qty`).attr('value', 1);
            $(`#${id}total`).html(data.price);
            var total = parseInt(data.price);
            let price = $("#subtotal").text() == "" ? 0 : parseInt($("#subtotal").text());
            let dis = $("#discount").val() == "" ? 0 : parseInt($("#discount").val());

            $("#subtotal").html(parseInt(data.price) + price);
            if (dis == null || dis != '') {
                $("#discount").attr('value', 0);
            }

            var g = $("#gtotal").text() == "" ? 0 : parseInt($("#gtotal").text());
            let gtotal = total + g;
            $('#gtotal').html(gtotal);
        }
    });
}
function removeRow(id) {
    $("#" + id).remove();
    sumAll();
}
function sumAll() {
    let total = 0;
    let match = $('.total');
    if (match.length != 0) {
        match.each(function (index, elem) {
            total = total + parseInt(elem.textContent);
        });
        $("#subtotal").html(total);
        calculateSum();
    }
    else {
        $("#sutotal").html(0);
    }
    let rows = $('tr');
    rows.each(function (index, elem) {
        console.log(elem);
    });
}
function qtyChange(id) {
    let price = $(`#${id}price`).text();
    let qty = $(`#${id}qty`).val();
    let total = price * qty;
    $(`#${id}total`).html(total);
    sumAll();
}
function calculateSum() {
    let dis = $("#discount").val();
    let total = parseInt($("#subtotal").text());
    let tdis = dis * total / 100;
    let pay = total - tdis;
    $("#gtotal").text(pay);
}
function generateGuid() {
    var result, i, j;
    result = '';
    for (j = 0; j < 32; j++) {
        if (j == 8 || j == 12 || j == 16 || j == 20)
            result = result + '-';
        i = Math.floor((Math.random()) * 0x10000)
            .toString(16)
            ;
        Math.floor(Math.random() * 16).toString(16).toUpperCase();
        result = result + i;
    }
    return result;
}
function getProductList() {
    var res;
    $.ajax({
        url: "/product/getInvoiceDetails",
        method: "GET",
        dataType: "json",
        contentType: "application/jason",
        async: false,
        success: function (data) {
            res = data;
        }
    });
    return res;
}
function saveInvoice() {
    let _count = $('.total').length;
    let _sub = $('#subtotal').text();
    let _total = $('#gtotal').text();
    let list = [];
    $('tr').each(function (index, elem) {

        var element = {
            productId: $(this).find('.childId').text(),
            productPrice: parseInt($(this).find('.price').text()),
            qty: parseInt($(this).find('.qty input').val()),
        };
        list.push(element);
    });
    let _discount = $('#discount').val();
    var model = {
        items: _count,
        subtotal: _sub,
        total: _total,
        discount: _discount,
        invoiceModelDtos: list
    };

    $.ajax({
        url: "/saveInvoice",
        type: "POST",
        //contentType: "application/json; charset=utf-8",
        data: model,
        success: function (data) {
            alert("saved!");
        },
        error: function (ex) {
            console.log(ex);
        }
    });
}
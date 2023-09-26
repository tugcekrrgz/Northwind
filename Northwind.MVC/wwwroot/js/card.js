$(document).ready(function () {

    $.ajax({
        url: "https://localhost:7000/api/card/getitems",
        xhrFields: {
            withCredentials: true
        },
        type: "Get",
        success: function (data) {
            console.log(data);    
            fillCardTable(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
    $("#productTableBody").on("click", function (e) {
        if (e.target.name == "addtocard") {
            addToCard(e.target.id);
        }
    })

    function addToCard(id) {
        $.ajax({
            url: "https://localhost:7000/api/card/addtocard/" + id,
            //xml header request : UI'den sessiona ulaşmak için tanımlandı.
            xhrFields: {
                withCredentials:true
            },
            type: "Get",
            success: function (data) {
                console.log(data);
                alert(data.productName + " sepete eklendi.");
                $("#count").text(data.length);
            },
            error: function (err) {
                console.log(err);
            }
        })
    }

    function fillCardTable(items) {
        var totalPrice = 0;
        const cardTableBody = $("#cardTableBody");
        items.map(function (value, index) {
            totalPrice += value.subTotal;
            const tr = `
                <tr>
                    <td>${value.productName}</td>
                    <td>${value.unitPrice}</td>
                    <td>${value.quantity}</td>
                    <td>${value.subTotal}</td>
                    <td>
                        <button name="removeitem" id="${value.id}" class="btn btn-danger btn-sm">Remove</button>
                    </td>
                </tr>
            `;
            cardTableBody.append(tr);
        })

        $("#totalPrice").text(totalPrice + " ₺");
    }
    
})
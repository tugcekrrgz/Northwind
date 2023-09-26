$(document).ready(function () {

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
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
    
})
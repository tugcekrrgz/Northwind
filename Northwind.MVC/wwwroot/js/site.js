$(document).ready(function () {

    $.ajax({
        url: "https://localhost:7000/api/card/getitems",
        xhrFields: {
            withCredentials: true
        },
        type: "Get",
        success: function (data) {
            console.log(data);
            $("#count").text(data.length);
        },
        error: function (err) {
            console.log(err);
        }
    })

    
})
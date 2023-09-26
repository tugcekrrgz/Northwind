$(document).ready(function () {

    //Get Product
    function getProducts() {
        $.ajax({
            url: "https://localhost:7000/api/product",
            type: "Get",
            success: function (data) {
                console.log(data);
                fillTableProductData(data);
            },
            error: function (err) {
                console.log(err);
            }
        })
    }

    //Fill Table
    function fillTableProductData(products) {

        const productTableBody = $("#productTableBody");
        products.map(function (value, index) {
            const tr = `
                <tr>
                    <td>${value.productId}</td>
                    <td>${value.productName}</td>
                    <td>${value.unitPrice}</td>
                    <td>${value.unitsInStock}</td>
                    <td>${value.category.categoryName}</td>
                    <td>${value.supplier.companyName}</td>
                    <td>
                        <button name="addtocard" id="${value.productId}" class="btn btn-primary btn-sm">Add To Card</button>
                    </td>
                </tr>
            `;

            productTableBody.append(tr);
        })
    }



    getProducts();

})
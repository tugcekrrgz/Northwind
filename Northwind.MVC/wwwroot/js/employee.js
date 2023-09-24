$(document).ready(function () {

    const employeesURL = "https://localhost:7000/api/employee";
    const salesDetailsURL = "https://localhost:7000/api/employee/salesdetails";
    class Employee {

        constructor(_id, _firstname, _lastname, _title) {
                this.id = _id,
                this.firstname = _firstname,
                this.lastname = _lastname,
                this.title = _title
        }

        static employeeList = new Array();
    }

    class EmployeeAPI {
        static getEmployees() {
            $.ajax({
                url: `${employeesURL}`,
                type: "Get",
                success: function (data) {
                    data.forEach(function (value, index) {
                        const employee = new Employee(value.id, value.firstname, value.lastname, value.title);
                        Employee.employeeList.push(employee);
                    })
                    fillTable();
                },
                error: function (err) {
                    console.log(err);
                },
            })
        }

        static getSalesDetails(id) {
            $.ajax({
                url: `${salesDetailsURL}/${id}`,
                type: "Get",
                success: function (data) {
                    console.log(data);
                    fillEmployeeCard(data);
                },
                error: function (err) {
                    console.log(err);
                }
            })
        }
    }

    function fillTable() {
        const tbody = $("#employeeBody");
        if (Employee.employeeList.length > 0) {
            Employee.employeeList.forEach(function (value, index) {
                const tr = `
                    <tr>
                        <td>${value.id}</td>
                        <td>${value.firstname}</td>
                        <td>${value.lastname}</td>
                        <td>${value.title}</td>
                        <td>
                            <button name="salesDetails" id="${value.id}" class="btn btn-sm btn-secondary">Sales Details</button>
                        </td>
                    </tr>
                `;
                tbody.append(tr);
            })
        }
    }

    function fillEmployeeCard(data) {
        $("#employeeFullName").text(`${data.firstname} ${data.lastname}`);
        $("#employeeTotalSaleCount").text(`${data.totalSales}`);
        $("#employeeCard").removeClass("d-none").addClass("d-block");
    }

    $("#employeeBody").on("click", function (e) {
        if (e.target.name == "salesDetails") {
            EmployeeAPI.getSalesDetails(e.target.id);
        }
    })

    EmployeeAPI.getEmployees();

})



$(document).ready(function () {
    $("#Masterform").hide();
    $("#CancelId").hide();
    // Fetch data from the Web API using AJAX
    $.ajax({
        url: "/api/BooksApi/GetPublisherWiseSortList", // URL of your Web API endpoint
        type: "GET",
        dataType: "json",
        success: function (res) {
            // Process the retrieved data
            displayBooks(res);
        },
        error: function (xhr, status, error) {
            // Handle errors
            console.error("Error:", error);
        }
    });

    // Function to display products in the frontend
    function displayBooks(books) {
        var html = "<tr>";
        var total = 0;
        $.each(books, function (index, book) {

            html += "<td style='width:200px;'>" + "<a onclick='updateEntry(" + book.booksId + ")' class='pe-2'>Edit</a>" + "<a href='/PublisherListView/Detail/" + book.booksId + "' class='pe-2'>Delete</a>" + "<a href='/PublisherListView/Detail/" + book.booksId + "'>Detail</a>" + "</td>";
            html += "<td>" + book.publisher + "</td>";
            html += "<td>" + book.authorLastName + "," + book.authorFirstName + "</td>";
            html += "<td>" + book.title + "</td>";
            html += "<td class='text-end'>" + book.price + "</td>";
            html += "</tr>";

            total += book.price;
        });

        var fhtml = "<tr>";
        fhtml += "<td>" + "</td>";
        fhtml += "<td>" + "</td>";
        fhtml += "<td>" + "</td>";
        fhtml += "<td><strong>" + "Total" + "</strong></td>";
        fhtml += "<td class='text-end'><strong>" + total + "</strong></td>";

        $("#ListView #bookslist").html(html);
        $("#ListView #footTotal").html(fhtml);
    }
});
function adnewclick() {

    $("#ListView").hide();
    $("#Masterform").show();
    $("#UpdateId").hide();

}

function updateEntry(id) {
    $("#ListView").hide();
    $("#Masterform").show();
    $("#SaveId").hide();
    $("#AddNewId").hide();
    $("#CancelId").hide();
    //var id = $("#BooksId").val();


    var data = { BookId: id };
    $.ajax({
        url: "/PublisherListView/getBook", // URL of your Web API endpoint
        type: "GET",
        data: data,
        success: function (res) {
            // Process the retrieved data
            $("#BooksId").val(res.booksId);
            $("#Publisher").val(res.publisher);
            $("#AuthorLastName").val(res.authorLastName);
            $("#AuthorFirstName").val(res.authorFirstName);
            $("#Title").val(res.title);
            $("#Price").val(res.price);
        },
        error: function (xhr, status, error) {
            // Handle errors
            console.error("Error:", error);
        }
    });
}
function deleteEntry() {

    var id = $("#BooksId").val();
    var data = { BookId: id };
    $.ajax({
        url: "/PublisherListView/DetailRemove", // URL of your Web API endpoint
        type: "POST",
        data: data,
        success: function (result) {
            var result = response.result;

            // Use the boolean result as needed
            if (result) {
                // The result is true
                console.log('The result is true');
            } else {
                // The result is false
                console.log('The result is false');
            }
        },
        error: function (xhr, status, error) {
            // Handle errors
            console.error("Error:", error);
        }
    });
}

function AddOrUpdateCategory(id) {
    $.ajax({
        url: "/Admin/Category/AddOrUpdateCategory?id=" + id,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            $('input[name="CategoryId"]').val(data.categoryId);
            $('input[name="CategoryName"]').val(data.categoryName);
            $('input[name="CategoryImage"]').val(data.categoryImage);
            $('img.category-image').attr("src", data.categoryImage);
        },
        error: function () { },
        complete: function () { }
    })
}

$('img.input-img').on('load', function () {
    if (imgPath == "") {
        imgPath = $('input[name="CategoryImage"]').val();
    }
    $('input[name="CategoryImage"]').val(imgPath);
});
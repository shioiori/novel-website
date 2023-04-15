
function AddOrUpdateBanner(id) {
    $.ajax({
        url: "/Admin/banner/AddOrUpdateBanner?id=" + id,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            $('input[name="BannerId"]').val(data.bannerId);
            $('input[name="BannerImage"]').val(data.bannerImage);
            $('select[name="BannerSize"]').val(data.bannerSize);
            $('select[name="BookId"]').val(data.bookId);

            $('img.input-img').attr("src", data.bannerImage);
        },
        error: function () { },
        complete: function () { }
    })
}

$('img.input-img').on('load', function () {
    if (imgPath == "") {
        imgPath = $('input[name="BannerImage"]').val();
    }
    $('input[name="BannerImage"]').val(imgPath);
});

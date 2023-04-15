
$.ajax({
    url: "/Billboard/GetListCategory" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-chuong').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        data.forEach((item, index) => {
            $('#list-chuong').append(`<li class="list-group-item col-4">
                        <a href="/truyen/${link}/chuong-${item.chapterNumber}/${item.slug}-${item.chapterId}">Chương ${item.chapterNumber}: ${item.chapterName}</a>
                        </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Book/GetListChapters?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-chuong').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        data.forEach((item, index) => {
            $('#list-chuong').append(`<li class="list-group-item col-4">
                        <a href="/truyen/${link}/chuong-${item.chapterNumber}/${item.slug}-${item.chapterId}">Chương ${item.chapterNumber}: ${item.chapterName}</a>
                        </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})
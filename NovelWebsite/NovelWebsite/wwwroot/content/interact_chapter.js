var isChapterLike = false;

function GetChapterLike() {
    $.ajax({
        url: "/interact/get-chapter-like/" + chapterId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isChapterLike = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateChapterLike() {
    $.ajax({
        url: "/interact/update-chapter-like/" + chapterId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function onClickBtnLikeChapter(el) {
    UpdateChapterLike();
    var $btn = $(el);
    var count = parseInt($btn.text().trim());
    if ($(el).hasClass("like-active")) {
        $(el).removeClass("like-active");
        $btn.html('<i class="fa-regular fa-thumbs-up"></i> ' + --count);
    } else {
        $(el).addClass("like-active");
        $btn.html('<i class="fa-regular fa-thumbs-up"></i> ' + ++count);
    }
}

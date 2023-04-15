var isCommentLike = false;

function GetCommentLike(commentId) {
    $.ajax({
        url: "/interact/get-comment-like/" + commentId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isCommentLike = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateCommentLike(commentId) {
    $.ajax({
        url: "/interact/update-comment-like/" + commentId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function onClickBtnLikeComment(el, commentId) {
    UpdateCommentLike(commentId);
    var $btn = $(el);
    var count = parseInt($btn.text().trim());
    if ($(el).hasClass("like-active")) {
        $(el).removeClass("like-active");
        $btn.html('<i class="fa-regular fa-thumbs-up info-icon"></i> ' + --count);
    } else {
        $(el).addClass("like-active");
        $btn.html('<i class="fa-regular fa-thumbs-up info-icon"></i> ' + ++count);
    }
}
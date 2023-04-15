var isPostLike = false;

function GetPostLike() {
    $.ajax({
        url: "/interact/get-post-like/" + postId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isPostLike = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdatePostLike() {
    $.ajax({
        url: "/interact/update-post-like/" + postId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function onClickBtnLikePost(el) {
    UpdatePostLike();
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
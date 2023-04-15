function CommentUserLike() {
    $('.comment-group').map(function () {
        var id = this.id.split('-');
        var cmtId = id[id.length - 1];
        GetCommentLike(cmtId);
        if (isCommentLike == true) {
            var cmt = '#comment-like-btn-' + cmtId;
            $(cmt).addClass("like-active");
            $(cmt).find('i').addClass("like-active");
            $(cmt).find('.thank-num').addClass("like-active");
        }
        isCommentLike = false;
    });
}

function AddBookComment(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            BookId: id,
            UserId: user.userId,
            Content: $('#comment-editor').html()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
            location.reload();
        },
        error: function () { },
        complete: function () { }
    })
}

function AddChapterComment(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            ChapterId: id,
            UserId: user.userId,
            Content: $('#chapter-editor').html()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
            location.reload();
        },
        error: function () { },
        complete: function () { }
    })
}



function AddPostComment(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            PostId: id,
            UserId: user.userId,
            Content: $('#postcomment-editor').html()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
            location.reload();
        },
        error: function () { },
        complete: function () { }
    })
}

function AddReplyComment(id) {
    var user = GetUserInfo();
    var contentEle = '#reply' + id + '-editor';
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            ReplyCommentId: id,
            UserId: user.userId,
            Content: $(contentEle).html()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            GetListComment();
            var el = "#btn-reply-cmt-" + id;
            console.log(123);
            $(el).click();
        },
        error: function () { },
        complete: function () { }
    })
}
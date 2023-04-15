var queryString = window.location.href;
var param = queryString.split('-');
var id = param[param.length - 1];
var p = queryString.split('/');
var link = p[p.length - 1];


window.onload = function () {
    GetBookFav();
    GetBookRec();
    GetBookFollow();
    if (isBookFav == true) {
        $('#btn-fav').addClass("selected");
        $('#btn-fav').text("Bỏ yêu thích");
    }
    if (isBookRec == true) {
        $('#btn-rec').addClass("selected");
        $('#btn-rec').text("Bỏ đề cử");
    }
    if (isBookFollow == true) {
        $('#btn-follow').addClass("selected");
        $('#btn-follow').text("Bỏ theo dõi");
    }
    GetListComment();
    ReviewUserLike();
    CommentUserLike();
}

function ReviewUserLike() {
    $('.review-group').map(function () {
        var id = this.id.split('-');
        var reviewId = id[id.length - 1];
        GetReviewLike(reviewId);
        if (isReviewLike == true) {
            var rv = '#review-like-btn-' + reviewId;
            $(rv).addClass("like-active");
            $(rv).find('i').addClass("like-active");
            $(rv).find('.thank-num').addClass("like-active");
        }
        isReviewLike = false;
    });
}


$.ajax({
    url: "/Book/GetListChapters?id=" + bookId,
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
    url: "/Book/GetListReviews?id=" + bookId,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-review').html('');
        var user = GetUserInfo();
        $('#list-review').append(`<li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="${user.user.avatar}">
                                            </a>
                                        </div>                                       
                                        <div class="input-comment col">
                                            <div id="review-toolbar"></div>
                                            <div id="review-editor" class="input--box"></div>
                                        </div>
                                        <div class="submit-btn col-md-12">
                                            <div class="submit-btn-wrap">
                                                <button class="btn btn-primary" onclick="AddReview(${bookId})">Đăng</button>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);
        data.forEach((item, index) => {
            var content = $('<textarea />').html(item.content).text();
            $('#list-review').append(`<li class="list-group-item">
                                    <div class="row user--comment-section review-group" id="review-${item.reviewId}">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="${item.user.avatar}">
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)">${item.user.userName}</a>
                                                </p>
                                                <p class="comments">
                                                    ${content}
                                                </p>
                                                <p class="info--wrap">
                                                    <span>${item.createdDate} </span>
                                                    <a href="javascript:void(0)" id="review-like-btn-${item.reviewId}" onclick="onClickBtnLikeReview(this,${item.reviewId})">
                                                        <i class="fa-regular fa-thumbs-up"></i>
                                                        <span class="thank-num">${item.likes}</span>
                                                    </a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);
            
        });
        startCKEditor('review-toolbar', 'review-editor');
    },
    error: function () { },
    complete: function () { }
})

function GetListComment() {
    $.ajax({
        url: "/Book/GetListComments?id=" + bookId,
        type: "GET",
        async: false,
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            $('#list-comment').html('');
            let row = jQuery('<div>', {
                class: 'index__theloai--chitiet row',
            });
            var user = GetUserInfo();

            $('#list-comment').append(`<li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="${user.user.avatar}">
                                            </a>
                                        </div>                                       
                                        <div class="input-comment col">
                                            <div id="comment-toolbar"></div>
                                            <div id="comment-editor" class="input--box"></div>
                                        </div>
                                        <div class="submit-btn col-md-12">
                                            <div class="submit-btn-wrap">
                                                <button class="btn btn-primary" onclick="AddBookComment(${bookId})">Đăng</button>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);

            data.forEach((item, index) => {
                var content = $('<textarea />').html(item.content).text();
                $('#list-comment').append(`<li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="${item.user.avatar}">
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main" id="${item.commentId}">
                                            <div class="user--discussion comment-group" id="comment-${item.commentId}">
                                                <p class="users">
                                                    <a href="javascript:void(0)">${item.user.userName}</a>
                                                </p>
                                                <p class="comments">
                                                    ${content}
                                                </p>
                                                <p class="info--wrap">
                                                    <span>${item.createdDate} </span>
                                                    <a href="javascript:void(0)" onclick="replyComment(${item.commentId})">
                                                        <i class="fa-regular fa-comment-dots info-icon"></i>
                                                        ${item.numberOfReplyComment} trả lời
                                                    </a>
                                                    <a href="javascript:void(0)" id="comment-like-btn-${item.commentId}" onclick="onClickBtnLikeComment(this, ${item.commentId})">
                                                        <i class="fa-regular fa-thumbs-up info-icon"></i>
                                                        ${item.likes}
                                                    </a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);
                if (index % 2 == 1) {
                    $('.index__theloai--wrap').append(row);
                    row = jQuery('<div>', {
                        class: 'index__theloai--chitiet row',
                    });;
                }
            });
            startCKEditor('comment-toolbar', 'comment-editor');
        },
        error: function () { },
        complete: function () { }
    })

}

$.ajax({
    url: "/Book/GetAuthorBooks?id=" + authorId,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-same-author').html('');
        /*        let row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });*/
        $('#book-same-author').append(`<li class="list-group-item">
                                <h5>Truyện cùng tác giả</h5>
                            </li>`)
        data.forEach((item, index) => {
            console.log(item);
            console.log(link);
            $('#book-same-author').append(`<li class="list-group-item">
                                <a href="/truyen/${item.slug}-${item.bookId}">&#x2022; ${item.bookName}</a>
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
    url: "/Book/GetUserBooks?id=" + userId,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-same-user').html('');
        /*        let row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });*/
        $('#book-same-user').append(`<li class="list-group-item">
                                <h5>Truyện cùng người đăng</h5>
                            </li>`)
        data.forEach((item, index) => {
            $('#book-same-user').append(`<li class="list-group-item">
                                <a href="/truyen/${item.slug}-${item.bookId}">&#x2022; ${item.bookName}</a>
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
    url: "/Book/BooksMaybeYouLike?id=" + categoryId,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-same-like').html('');
        data.forEach((item, index) => {
            $('#book-same-like').append(`<li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="/truyen/${item.slug}-${item.bookId}">
                                        <img src="${item.avatar}">
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                                    <p>${item.author.authorName}</p>
                                    <a href="/truyen/${item.slug}-${item.bookId}" class="btn index__left-wrap--cardbtn truyen-btn">
                                        Đọc truyện
                                        <i class="fa-solid fa-chevron-right"></i>
                                    </a>
                                </h4>
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

function startCKEditor(toolbar, editor) {
    DecoupledEditor
        .create(document.querySelector('#' + editor), {
            toolbar: {
                items: [
                    'selectAll', '|',
                    'heading', '|',
                    'bold', 'italic', 'strikethrough', 'underline', '|',
                    'bulletedList', 'numberedList', '|',
                    'outdent', 'indent', '|',
                    'undo', 'redo',
                    '-',
                    'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', '|',
                    'alignment', '|',
                    'link', 'blockQuote', 'insertTable', 'mediaEmbed', '|',
                ],
                shouldNotGroupWhenFull: true
            },
            // Changing the language of the interface requires loading the language file using the <script> tag.
            language: 'vi',
            list: {
                properties: {
                    styles: true,
                    startIndex: true,
                    reversed: true
                }
            },

            heading: {
                options: [
                    { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                    { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                    { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                    { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                    { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                    { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                    { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
                ]
            },

            // placeholder: 'Welcome to CKEditor 5!',

            fontFamily: {
                options: [
                    'default',
                    'Arial, Helvetica, sans-serif',
                    'Courier New, Courier, monospace',
                    'Georgia, serif',
                    'Lucida Sans Unicode, Lucida Grande, sans-serif',
                    'Tahoma, Geneva, sans-serif',
                    'Times New Roman, Times, serif',
                    'Trebuchet MS, Helvetica, sans-serif',
                    'Verdana, Geneva, sans-serif'
                ],
                supportAllValues: true
            },

            fontSize: {
                options: [10, 12, 14, 'default', 18, 20, 22],
                supportAllValues: true
            },

        })
        .then(editor => {
            const toolbarContainer = document.querySelector('#' + toolbar);

            toolbarContainer.prepend(editor.ui.view.toolbar.element);

            window.editor = editor;
        })
        .catch(err => {
            console.error(err.stack);
        });

}

$.ajax({
    url: "/Book/GetBookTags?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        console.log(data);
        $('#book-tag').html('');
        data.forEach((item, index) => {
            $('#book-tag').append(`<a href="javascript:void(0)">${item.tagName}</a>`);
        });
    },
    error: function () { },
    complete: function () { }
})

function AddReview(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Review/AddReview",
        type: "POST",
        data: {
            BookId: id,
            UserId: user.userId,
            Content: $('#review-editor').html()
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
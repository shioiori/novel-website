var isReviewLike = false;

function GetReviewLike(reviewId) {
    $.ajax({
        url: "/interact/get-review-like/" + reviewId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isReviewLike = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateReviewLike(reviewId) {
    $.ajax({
        url: "/interact/update-review-like/" + reviewId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function onClickBtnLikeReview(el, reviewId) {
    UpdateReviewLike(reviewId);
    var thankNum = parseInt($(el).find('.thank-num').text());

    console.log($(el).siblings('.thank-num').text())
    if ($(el).hasClass("like-active")) {
        $(el).removeClass("like-active");
        $(el).find('i').removeClass("like-active");
        $(el).find('.thank-num').removeClass("like-active");
        $(el).find('.thank-num').text(thankNum - 1);
    } else {
        $(el).addClass("like-active");
        $(el).find('i').addClass("like-active");
        $(el).find('.thank-num').addClass("like-active");
        $(el).find('.thank-num').text(thankNum + 1);
    }
}


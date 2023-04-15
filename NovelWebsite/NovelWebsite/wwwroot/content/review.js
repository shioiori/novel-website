window.onload = function () {
    $('.review-group').map(function () {
        var id = this.id.split('-');
        var reviewId = id[id.length - 1];
        GetReviewLike(reviewId);
        console.log(isReviewLike);
        if (isReviewLike == true) {
            var rv = '#review-like-btn-' + reviewId;
            $(rv).addClass("like-active");
            $(rv).find('i').addClass("like-active");
            $(rv).find('.thank-num').addClass("like-active");
        }
        isReviewLike = false;
    });
}

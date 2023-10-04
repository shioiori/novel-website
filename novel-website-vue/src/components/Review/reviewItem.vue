<template>
    <div class="reviewitem-container">
        <div class="comment-group">
            <div class="comment-element">
                <div class="comment-avatar-box">
                    <div class="center-align comment-avatar">
                        <a href="/user/lycorisaki" class="avatar-link">
                            <img src="../../assets/logo.png" class="avatar-img" />
                        </a>
                    </div>
                </div>
                <div class="comment-content">
                    <div class="comment-content-box">
                        <div class="comment-username">
                            <a href="/user/lycorisaki" class="username-link">
                                @item.User.UserName
                            </a>
                        </div>
                        <div class="comment-info">
                            <a href="#!" class="comment-interval"></a>
                        </div>
                        <div class="comment-content-msg word-wrap">
                            @Html.Raw(HttpUtility.HtmlDecode(item.Content))
                        </div>
                        <div class="comment-content-footer">
                            <div
                                class="comment-view-controls"
                                style="
                                    display: inline-block;
                                    margin-right: 0.5rem;
                                "
                            >
                                <a href="#!" class="comment-report-btn"
                                    >Báo cáo</a
                                >
                            </div>
                            <a
                                href="javascript:void(0)"
                                class="comment-reply-btn"
                                onclick="onClickBtnLikeReview(this, @item.ReviewId)"
                                id="review-like-btn-@item.ReviewId"
                            >
                                <i class="fa-sharp fa-regular fa-thumbs-up"></i>
                                Cảm ơn
                                <span class="thank-num">@item.Likes</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="book-item float-wrapper hide-on-med-and-up">
            <a
                class="hoverable smallbook"
                href="/truyen/@item.Book.Slug-@item.Book.BookId"
            >
                <img
                    class="cover-wrapper carousel-inner"
                    src=""
                    alt="Card image"
                />
            </a>
            <div class="midup-body card-body">
                <h5 class="book-title">
                    <a href="/truyen/@item.Book.Slug-@item.Book.BookId"
                        >@item.Book.BookName</a
                    >
                </h5>
                <p class="book-author index__truyenmoito--theloai">
                    <a class="truncate" href="">@item.Book.Author.AuthorName</a>
                </p>
                <p class="index__truyenmoito--gioithieu">
                    <i
                        >@Html.Raw(HttpUtility.HtmlDecode(item.Book.Introduce.Substring(0,128)))
                    </i>
                </p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "reviewitem-layout",
};
</script>

<style>
.reviewitem-container {
    display: flex;
    justify-content: space-between;
    margin-top: 1rem;
}
.comment-element {
    display: flex;
}
.comment-avatar img {
    width: 72px;
    height: 72px;
    border-radius: 100%;
}
.comment-content {
    border: 1px solid black
}
</style>

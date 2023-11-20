<template>
    <div class="reviewitem-container">
        <div class="comment-group">
            <div class="comment-element">
                <div class="comment-avatar-box">
                    <div class="center-align comment-avatar">
                        <a href="/user/lycorisaki" class="avatar-link">
                            <img
                                src="../../assets/logo.png"
                                class="avatar-img"
                            />
                        </a>
                    </div>
                </div>
                <div class="comment-content">
                    <div class="comment-content-box">
                        <div class="comment-username">
                            <a href="/user/lycorisaki" class="username-link">
                                {{ userName }}
                            </a>
                        </div>
                        <div class="comment-info">
                            <a href="#!" class="comment-interval"></a>
                        </div>
                        <div class="comment-content-msg word-wrap" v-html="content">
                        </div>
                        <div class="comment-content-footer float-end">
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
                                <span class="thank-num">{{ likes }}</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="book-item float-wrapper hide-on-med-and-up reviewbook-item">
            <a
                class="hoverable smallbook"
                href="/truyen/@item.Book.Slug-@item.Book.BookId"
            >
                <img
                    class="cover-wrapper carousel-inner"
                    src="https://wikidich6.com/photo/63d8b4ed54b80862372b0936?o=1"
                    alt="Card image"
                />
            </a>
            <div class="midup-body card-body">
                <h5 class="book-title">
                    <a href="/truyen/@item.Book.Slug-@item.Book.BookId">{{ bookName}}</a>
                </h5>
                <p class="book-author index__truyenmoito--theloai">
                    <a class="truncate" href="">{{ authorName }}</a>
                </p>
                <p class="index__truyenmoito--gioithieu">
                    <i>{{ describe }}</i>
                </p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "reviewitem-layout",
    props: {
        avatar: String,
        userName: String,
        content: String,
        likes: Number,
        bookCover: String,
        bookName: String,
        authorName: String,
        describe: String,
    },
};
</script>

<style>
.reviewitem-container {
    display: flex;
    justify-content: space-between;
    margin-top: 1rem;
}
.comment-group {
    flex: 1;
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
    padding: 1rem;
    border: 1px solid #bbb;
    border-radius: 10px;
    flex: 1;
    margin: 0 1rem;
}
.cover-wrapper {
    width: 150px;
    height: 210px;
}
.reviewbook-item {
    text-align: center;
}
.username-link {
    font-weight: bold;
    color: #3838c1;
    font-size: 1.1rem;
}
.comment-content-msg {
    margin: 1rem 0;
    font-size: 1rem;
}
.book-item {
    margin: 0;
}
</style>

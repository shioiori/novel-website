<template>
  <div class="book--information">
            <div class="row">
                <div class="col-md-2">
                    <div class="book--img">
                        <a href="javascript:void(0)">
                            <img src="" />
                        </a>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="book--info">
                        <h1>@Model.BookName</h1>
                        <p class="book--info-tag">
                            <a
                                href="/tac-gia/@Model.AuthorId/@Model.Author.Slug"
                                >@Model.Author.AuthorName</a
                            >
                            <a href="javascript:void(0)"
                                >@Model.BookStatus.BookStatusName</a
                            >
                            <a href="javascript:void(0)"
                                >@Model.Category.CategoryName</a
                            >
                        </p>
                        <p>
                            <span class="like">@Model.Likes</span>
                            <i class="no-italic">Yêu thích</i>
                            <i>|</i>

                            <span class="view">@ViewData["Views"]</span>
                            <i class="no-italic">Lượt xem</i>
                            <i>|</i>

                            <span class="nominate">@Model.Recommends</span>
                            <i class="no-italic">Đề cử</i>
                        </p>
                        <p class="book--info-buttons">
                            <a
                                class="btn"
                                href="/truyen/@Model.Slug-@Model.BookId/@firstChapterUrl"
                                >Đọc truyện</a
                            >
                            <a
                                class="btn"
                                id="btn-fav"
                                href="javascript:void(0)"
                                onclick="onClickInfoBtn(this,1)"
                                >Yêu thích</a
                            >
                            <a
                                class="btn"
                                id="btn-follow"
                                href="javascript:void(0)"
                                onclick="onClickInfoBtn(this,2)"
                                >Theo dõi</a
                            >
                            <a
                                class="btn"
                                id="btn-rec"
                                href="javascript:void(0)"
                                onclick="onClickInfoBtn(this,3)"
                                >Đề cử</a
                            >
                        </p>
                    </div>
                </div>
            </div>
        </div>
</template>

<script>
export default {
    name: 'bookInfo-layout'
}
</script>

<style>

</style>
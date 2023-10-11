<template>
    <div class="rank-box-main-body">
        <div class="rank-view-list">
            <div class="rank-view-list-item">
                <ul class="list-group" id="filter-book">
                    <li class="list-group-item">
                        <div class="book--img">
                            <a href="/truyen/@book.Slug-@book.BookId">
                                <img src="https://wikidich6.com/photo/63d8b4ed54b80862372b0936?o=1" class="book--imgcss" />
                            </a>
                        </div>
                        <div class="book--info">
                            <h3>
                                <a href="/truyen/@book.Slug-@book.BookId"
                                    >@book.BookName</a
                                >
                            </h3>
                            <div class="book-state">
                                <a
                                    href="/tac-gia/@book.AuthorId/@book.Author.Slug"
                                    >@book.Author.AuthorName</a
                                >
                                <i>|</i>
                                <p>@book.BookStatus.BookStatusName</p>
                                <i>|</i>
                                <p>@book.NumberOfChapters chương</p>
                            </div>
                            <div class="describe">
                                @Html.Raw(HttpUtility.HtmlDecode(book.Introduce))
                            </div>
                        </div>
                        <div class="book--info-buttons">
                            <p class="book--info-buttons-filterarea">
                                <a
                                    class="btn"
                                    href="/truyen/@book.Slug-@book.BookId"
                                    >Đọc truyện</a
                                >
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="book--img">
                            <a href="javascript:void(0)">
                                <img
                                    src="/image/test3.jpg"
                                    class="book--imgcss"
                                />
                            </a>
                        </div>
                        <div class="book--info">
                            <h3>
                                <a href="/html/truyen.html">Tên truyện mới 1</a>
                            </h3>
                            <div class="book-state">
                                <a href="javascript:void(0)">Tác giả</a>
                                <i>|</i>
                                <a href="javascript:void(0)">thục sơn</a>
                                <i>|</i>
                                <p>Tình trạng</p>
                                <i>|</i>
                                <p>Số chương</p>
                            </div>
                            <div class="describe">
                                Giới thiệu về truyện mới 1 Giới thiệu về truyện
                                mới 1 Giới thiệu về truyện mới 1 Giới thiệu v
                                truyện mới 1Giới thiệu về truyện mới 1Giới thiệu
                                về truyện mới 1 Giới thiệu về truyện mới 1 Giới
                                thiệu về truyện mới 1 Giới thiệu v truyện mới
                                1Giới thiệu về truyện mới 1Giới thiệu về truyện
                                mới 1 Giới thiệu về truyện mới 1 Giới thiệu về
                                truyện mới 1 Giới thiệu v truyện mới 1Giới thiệu
                                về truyện mới 1 Giới thiệu về truyện mới 1 Giới
                                thiệu về truyện mới 1 Giới thiệu về truyện mới 1
                                Giới thiệu v truyện mới 1Giới thiệu về truyện
                                mới 1Giới thiệu về truyện mới 1 Giới thiệu về
                                truyện mới 1 Giới thiệu về truyện mới 1 Giới
                                thiệu v truyện mới 1Giới thiệu về truyện mới
                                1Giới thiệu về truyện mới 1 Giới thiệu về truyện
                                mới 1 Giới thiệu về truyện mới 1 Giới thiệu v
                                truyện mới 1Giới thiệu về truyện mới 1
                            </div>
                        </div>
                        <div class="book--info-buttons">
                            <p class="book--info-buttons-filterarea">
                                <a class="btn" href="/html/truyen.html"
                                    >Đọc truyện</a
                                >
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "filterRankbody",
};
</script>

<style></style>

<template>
    <div class="row-right col-md-9">
        <div class="row" style="padding: 0 10px">
            <div class="reading col-md-6">
                <span>Truyện đã đăng</span>
            </div>
            <div class="col-md-6">
                <a
                    class="btn btn-secondary float-end"
                    href="/dang-tai/@ViewBag.UserId/truyen"
                    >Đăng truyện mới</a
                >
            </div>
        </div>
        <div class="rank-view-list">
            <div class="rank-view-list-item user-upload-book">
                <ul class="list-group" id="filter-book">
                    <li class="list-group-item col-12">
                        <div class="book--img">
                            <a href="javascript:void(0)">
                                <img src="" class="book--imgcss" />
                            </a>
                        </div>
                        <div class="book--info">
                            <h3>
                                <a href="/truyen/@item.Slug-@item.BookId"
                                    >@item.BookName</a
                                >
                            </h3>
                            <div class="book-state">
                                <a href="javascript:void(0)"
                                    >@item.Author.AuthorName</a
                                >
                                <i>|</i>
                                @item.BookStatus.BookStatusName
                                <i>|</i>
                                @item.NumberOfChapters
                            </div>
                            <div class="describe">
                                <i class="fa-solid fa-quote-left"></i>
                                @Html.Raw(HttpUtility.HtmlDecode(item.Introduce))
                            </div>
                        </div>
                        <div class="book--info-buttons user-upload-book-btn">
                            <p>
                                <a
                                    class="btn"
                                    href="/dang-tai/@item.UserId/truyen/@item.BookId"
                                    >Sửa truyện</a
                                >
                                <a
                                    class="btn"
                                    href="/dang-tai/@item.UserId/truyen/@item.BookId/danh-sach-chuong"
                                    >Danh sách chương</a
                                >
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <div class="rank-box-main-pagination">
            <ul class="pagination justify-content-end pagination-user">
                <li class="page-item">
                    <a
                        class="page-link"
                        href="/bo-loc?pageNumber=@Math.Max(1, pageNumber - 1)"
                    >
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>

                <li class="page-item">
                    <a class="page-link" href="/bo-loc?pageNumber=@i">@i</a>
                </li>

                <li class="page-item">
                    <a
                        class="page-link"
                        href="/bo-loc?pageNumber=@Math.Min(pageNumber + 1, pageCount)"
                    >
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
import "../../assets/css/truyendadang.css"

export default {
    name: "user-uploadbook",
};
</script>

<style></style>

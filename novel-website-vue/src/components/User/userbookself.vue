<template>
  <div class="row-right col-md-9">
      <div class="reading"><span>Đang đọc</span></div>
      <div class="index__right-wrap--list row">
          <div class="index__right-wrap--listitem col-md-12">
              <div class="book--img">
                  <a href="/truyen/@item.Slug-@item.BookId">
                      <img src="" class="book--imgcss" />
                  </a>
              </div>
              <div class="book--info">
                  <div class="book-name">
                      <a href="/truyen/@item.Slug-@item.BookId"
                          >@item.BookName</a
                      >
                  </div>
                  <div class="book-state">
                      <a href="javascript:void(0)">@item.Author.AuthorName</a>
                  </div>

                  <div class="describe">
                      <i class="fa-solid fa-quote-left"></i>
                      @Html.Raw(HttpUtility.HtmlDecode(item.Introduce))
                  </div>
              </div>
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
export default {
  name: "user-bookself",
};
</script>

<style></style>

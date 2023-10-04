<template>
    <div class="book-item col">
        <div class="cover-col">
            <a class="hoverable" href="/truyen/@item.Slug-@item.BookId">
                <img class="cover-wrapper carousel-inner" src="" />
            </a>
        </div>
        <div class="info-col">
            <a
                class="tooltipped"
                data-position="bottom"
                data-delay="50"
                data-tooltip="@item.BookName"
                href="/truyen/@item.Slug-@item.BookId"
            >
                <h5 class="book-title truncate">@item.BookName</h5>
            </a>
            <p class="book-author">
                <a
                    class="truncate"
                    href="/tac-gia/@item.Author.Slug-@item.Author.AuthorId"
                    >@item.Author.AuthorName</a
                >
            </p>
            <p class="book-publisher">
                <a class="truncate" href="/ho-so/@item.UserId"
                    >@item.User.UserName</a
                >
            </p>
            <p class="book-publisher">
                <a class="truncate" href="">@item.BookStatus.BookStatusName</a>
            </p>
            <p class="book-stats-box">
                <span class="book-stats"
                    ><i class="fa fa-light fa-eye"></i
                    ><span data-ready="abbrNum">@item.Views</span></span
                >
                <span class="book-stats"
                    ><i class="fa fa-thin fa-thumbs-up"></i
                    ><span data-ready="abbrNum">@item.Likes</span></span
                >
                <span class="book-stats"
                    ><i class="fa fa-thin fa-star"></i
                    ><span data-ready="abbrNum">@item.Recommends</span></span
                >
            </p>
        </div>
    </div>
</template>

<script>
export default {
    name: "billboard-item",
};
</script>

<style></style>

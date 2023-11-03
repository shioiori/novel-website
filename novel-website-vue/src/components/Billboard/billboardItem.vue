<template>
    <div class="book-item col">
        <div class="cover-col">
            <a class="hoverable" :href="slug">
                <img class="carousel-inner billboard-cover" :src="avatar" />
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
                <h5 class="book-title truncate">{{ bookName }}</h5>
            </a>
            <p class="book-author">
                <a
                    class="truncate"
                    href="/tac-gia/@item.Author.Slug-@item.Author.AuthorId"
                    >{{ authorName }}</a
                >
            </p>
            <p class="book-publisher">
                <a class="truncate" href="/ho-so/@item.UserId"
                    >{{ userName }}</a
                >
            </p>
            <p class="book-publisher">
                <a class="truncate" href="">{{ bookStatus }}</a>
            </p>
            <p class="book-stats-box">
                <span class="book-stats"
                    ><i class="fa fa-light fa-eye"></i
                    ><span data-ready="abbrNum">{{ views }}</span></span
                >
                <span class="book-stats"
                    ><i class="fa fa-thin fa-thumbs-up"></i
                    ><span data-ready="abbrNum">{{ likes }}</span></span
                >
                <span class="book-stats"
                    ><i class="fa fa-thin fa-star"></i
                    ><span data-ready="abbrNum">{{ recommends }}</span></span
                >
            </p>
        </div>
    </div>
</template>

<script>
export default {
    name: "billboard-item",
    props: {
        slug: String,
        avatar: String,
        bookName: String,
        authorName: String,
        userName: String,
        bookStatus: String,
        views: Number,
        likes: Number,
        recommends: Number,
    }
};
</script>

<style>
.billboard-cover {
    width: 200px;
    height: 280px;
}
.book-item {
    margin-top: 1rem;
}
.cover-col, .info-col {
    text-align: center;
}
</style>

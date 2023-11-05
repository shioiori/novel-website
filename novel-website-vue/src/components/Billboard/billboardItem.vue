<template>
    <div class="book-item col">
        <div class="cover-col">
            <a class="hoverable" @click="$router.push(`/book/${slug}-${bookId}`)">
                <img class="carousel-inner billboard-cover" :src="avatar" />
            </a>
        </div>
        <div class="info-col">
            <a
                class="tooltipped"
                data-position="bottom"
                data-delay="50"
                data-tooltip="@item.BookName"
                @click="$router.push(`/book/${slug}-${bookId}`)"
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
                <a class="truncate" href="/ho-so/@item.UserId">{{
                    userName
                }}</a>
            </p>
            <p class="book-publisher">
                <a class="truncate" href="">{{ bookStatusFix }}</a>
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
        bookId: Number,
        authorName: String,
        userName: String,
        bookStatus: String,
        views: Number,
        likes: Number,
        recommends: Number,
    },
    data() {
        return {
            bookStatusFix: "",
        };
    },
    created() {
        this.dataCleanse();
    },
    methods: {
        dataCleanse() {
            switch (this.bookStatus) {
                case "hoanthanh":
                    this.bookStatusFix = "HOÀN THÀNH";
                    break;
                case "tamngung":
                    this.bookStatusFix = "TẠM NGỪNG";
                    break;
                case "contiep":
                    this.bookStatusFix = "CÒN TIẾP";
                    break;
            }
        },
    },
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
.cover-col,
.info-col {
    text-align: center;
}
.book-stats-box {
    display: flex;
    justify-content: space-evenly;
}
.book-stats i {
    margin-right: 0.5rem;
}
.tooltipped {
    display: -webkit-box;
    -webkit-box-orient: vertical;
    -webkit-line-clamp: 2;
    overflow: hidden;
}
.hoverable:hover, .tooltipped:hover {
    cursor: pointer;
}
.hoverable img {
    transition: transform 0.25s;
}
.hoverable:hover img {
    transform: scale(1.05);
}
</style>

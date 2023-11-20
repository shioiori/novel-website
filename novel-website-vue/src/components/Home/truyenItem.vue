<template>
    <div class="index__right-wrap--listitem col-md-6">
        <div class="book--img">
            <a href="javascript:void(0)">
                <img :src="Avatar" class="book--imgcss" />
            </a>
        </div>
        <div class="book--info">
            <div class="book-name speca">
                <a @click="$router.push(`/book/${Slug}/${BookId}`)"
                    >{{ BookName }}</a
                >
            </div>
            <div class="book-state specb">
                <a @click="$router.push(`/author/${SlugAuthor}/${AuthorId}`)">{{ Author }}</a>
            </div>
            <p>
                <em>
                    <span class="chapters">{{ TotalChapters }}</span>
                </em>
                <cite> Số chương</cite>
                <i> | </i>
                <em>
                    <span class="views">{{ Views }}</span>
                </em>
                <cite> Lượt xem</cite>
            </p>
            <div class="category">
                <p>Thể loại:</p>
                <p class="category-wrap specc">
                    <a href="javascript:void(0)">{{ Category }}</a>
                </p>
            </div>
            <div class="describe">
                <i class="fa-solid fa-quote-left"></i>
                <p v-html="Introduce"></p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "truyenItem-layout",
    props: {
        Avatar: String,
        BookName: String,
        Author: String,
        TotalChapters: Number,
        Views: Number,
        Category: String,
        Introduce: String,
        BookId: String,
        Slug: String,
        SlugAuthor: String,
        AuthorId: Number
    }
};
</script>

<style>
.book-name a:hover, .book-state a:hover {
    cursor: pointer;
}
.speca a {
    font-size: 1.4rem !important;
}
.specb a {
    font-size: 1.1rem !important;
}
.specc a {
    font-size: 1.1rem !important;
}
</style>

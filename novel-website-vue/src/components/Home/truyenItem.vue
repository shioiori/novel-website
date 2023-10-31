<template>
    <div class="index__right-wrap--listitem col-md-6">
        <div class="book--img">
            <a href="javascript:void(0)">
                <img :src="avatar" class="book--imgcss" />
            </a>
        </div>
        <div class="book--info">
            <div class="book-name">
                <a href="/html/truyen.html"
                    >{{ bookName }}</a
                >
            </div>
            <div class="book-state">
                <a href="javascript:void(0)">{{ author }}</a>
            </div>
            <p>
                <em>
                    <span class="chapters">{{ numbChap }}</span>
                </em>
                <cite>Số chương</cite>
                <i>|</i>
                <em>
                    <span class="views">{{ views }}</span>
                </em>
                <cite>Lượt xem</cite>
            </p>
            <div class="category">
                <p>Thể loại:</p>
                <p class="category-wrap">
                    <a href="javascript:void(0)">{{ category }}</a>
                </p>
            </div>
            <div class="describe">
                <i class="fa-solid fa-quote-left"></i>
                {{ describe }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "truyenItem-layout",
    props: {
        avatar: String,
        bookName: String,
        author: String,
        numbChap: Number,
        views: Number,
        category: String,
        describe: String,
    }
};
</script>

<style></style>

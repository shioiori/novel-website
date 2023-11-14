<template>
    <div class="rank-box-main-body">
        <div class="rank-view-list">
            <div class="rank-view-list-item">
                <ul class="list-group" id="filter-book">
                    <li
                        class="list-group-item"
                        v-for="(item, index) in tempBookArr"
                        :key="index"
                    >
                        <div class="book--img">
                            <a @click="$router.push(`/book/${item.slug}/${item.bookId}`)">
                                <img :src="item.avatar" class="book--imgcss" />
                            </a>
                        </div>
                        <div class="book--info book--info-rankbodyfilter">
                            <h3>
                                <a @click="$router.push(`/book/${item.slug}/${item.bookId}`)">{{
                                    item.bookName
                                }}</a>
                            </h3>
                            <div class="book-state">
                                <a
                                    href="/tac-gia/@book.AuthorId/@book.Author.Slug"
                                    >{{ item.authorName }}</a
                                >
                                <i>|</i>
                                <p>{{ item.bookStatus }}</p>
                                <i>|</i>
                                <p>{{ item.totalChapters }} chương</p>
                            </div>
                            <div class="describe" v-html="item.introduce"></div>
                        </div>
                        <div class="book--info-buttons">
                            <p class="book--info-buttons-filterarea">
                                <a
                                    class="btn"
                                    @click="$router.push(`/book/${item.slug}-${item.bookId}`)"
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
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "filterRankbody",
    data() {
        return {
            tempBookArr: [],
            // slug: "",
            // avatar: "",
            // bookName: "",
            // authorName: "",
            // bookStatus: "",
            // numberOfChapter: "",
            // describe: ""
        };
    },
    created() {
        this.getBook();
    },
    computed: {
        bookArr() {
            return this.$store.getters.getBookArr;
        },
    },
    watch: {
        bookArr(newArr) {
            console.log(newArr, "thay doi");
            this.tempBookArr = newArr;
        },
    },
    methods: {
        async getBook() {
            try {
                let url = `${apiPath}/book/get-all`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay sach loc");
                this.tempBookArr = res;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
.describe {
    height: 100px;
    overflow: hidden;
}
.book--info-rankbodyfilter {
    width: calc(100% - 200px) !important;
}
</style>

<template>
    <div class="rank-box-main-body">
        <div class="rank-view-list">
            <div class="rank-view-list-item">
                <ul class="list-group" id="filter-book">
                    <li class="list-group-item" v-for="(item, index) in tempBookArr" :key="index">
                        <div class="book--img">
                            <a href="/truyen/@book.Slug-@book.BookId">
                                <img src="https://wikidich6.com/photo/63d8b4ed54b80862372b0936?o=1" class="book--imgcss" />
                            </a>
                        </div>
                        <div class="book--info">
                            <h3>
                                <a href="/truyen/@book.Slug-@book.BookId"
                                    >{{ item.bookName }}</a
                                >
                            </h3>
                            <div class="book-state">
                                <a
                                    href="/tac-gia/@book.AuthorId/@book.Author.Slug"
                                    >{{ item.authorName }}</a
                                >
                                <i>|</i>
                                <p>{{ item.bookStatus }}</p>
                                <i>|</i>
                                <p>{{ item.numberOfChapter }} chương</p>
                            </div>
                            <div class="describe">
                                {{ item.describe }}
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
        }
    },
    created() {
        this.getBook()
    },
    computed: {
        bookArr() {
            return this.$store.getters.getBookArr
        }
    },
    watch: {
        bookArr(newArr) {
            console.log(newArr, "thay doi");
            this.tempBookArr = newArr
        }
    },
    methods: {
        async getBook() {
            try {
                let url = `${apiPath}/book/get-all`
                let res = (await axios.get(url)).data
                console.log(res, "lay sach loc");
                this.tempBookArr = res
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

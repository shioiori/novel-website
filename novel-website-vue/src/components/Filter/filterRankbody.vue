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
                            <a
                                @click="
                                    $router.push(
                                        `/book/${item.Slug}/${item.BookId}`
                                    )
                                "
                            >
                                <img :src="item.Avatar" class="book--imgcss" />
                            </a>
                        </div>
                        <div class="book--info book--info-rankbodyfilter">
                            <h3>
                                <a
                                    @click="
                                        $router.push(
                                            `/book/${item.Slug}/${item.BookId}`
                                        )
                                    "
                                    >{{ item.BookName }}</a
                                >
                            </h3>
                            <div class="book-state">
                                <a
                                    @click="
                                        $router.push(
                                            `/author/${item.Author.Slug}/${item.Author.AuthorId}`
                                        )
                                    "
                                    >{{ item.Author.AuthorName }}</a
                                >
                                <i>|</i>
                                <p>{{ item.BookStatus }}</p>
                                <i>|</i>
                                <p>{{ item.TotalChapters }} chương</p>
                            </div>
                            <div class="describe" v-html="item.Introduce"></div>
                        </div>
                        <div class="book--info-buttons">
                            <p class="book--info-buttons-filterarea">
                                <a
                                    class="btn"
                                    @click="
                                        $router.push(
                                            `/book/${item.Slug}/${item.BookId}`
                                        )
                                    "
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
        this.handleNewCateBookArr();
        this.handleSearchName();
    },
    // mounted() {
        
    // },
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
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lay sach loc");
                this.tempBookArr = res;
            } catch (e) {
                console.log(e);
            }
        },
        async handleNewCateBookArr() {
            let key = localStorage.getItem("cateId");
            if (key == null || key == "") {
                return;
            } else {
                try {
                    let url = `${apiPath}/book/get-by-category-id?categoryId=${key}`;
                    let res = (await axios.get(url)).data.Data;
                    if (res) {
                        this.$store.dispatch("setBookArr", res);
                    } else {
                        this.$store.dispatch("setBookArr", null);
                    }
                    localStorage.removeItem("cateId");
                } catch (e) {
                    console.log(e);
                }
            }
        },
        async handleSearchName() {
            let key = localStorage.getItem("searchName");
            if (key == null || key == "") {
                return;
            } else {
                try {
                    let url = `${apiPath}/book/get-by-filter?SearchName=${key}`;
                    let res = (await axios.get(url)).data.Data;
                    if (res) {
                        this.$store.dispatch("setBookArr", res);
                    } else {
                        this.$store.dispatch("setBookArr", null);
                    }
                    localStorage.removeItem("searchName");
                } catch (e) {
                    console.log(e);
                }
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

<template>
    <div>
        <Header></Header>
        <bookInfo
            :book-cover="avatar"
            :book-name="bookName"
            :book-category="category"
            :book-author="bookAuthor"
            :book-status="bookStatus"
            :likes="likes"
            :views="views"
            :recommend="recommend"
        ></bookInfo>
        <bookNav></bookNav>
        <Footer></Footer>
    </div>
</template>

<script>
import "../../assets/css/truyen.css";
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import bookInfo from "./bookInfo.vue";
import bookNav from "./bookNav.vue";

import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "book-layout",
    components: {
        Header,
        Footer,
        bookInfo,
        bookNav,
    },
    data() {
        return {
            avatar: "",
            bookName: "",
            bookAuthor: "",
            bookAuthorId: null,
            bookStatus: "",
            category: "",
            likes: null,
            views: null,
            recommend: null,
            bookSlug: "",
            bookTotalChapters: null,

            bookUser: "",
            bookUserId: null,
            bookIntroduce: "",
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                console.log(this.$route.params.id);
                let url = `${apiPath}/book/get-by-book-id?bookId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(url);
                console.log(res);
                this.avatar = res.avatar;
                this.bookName = res.bookName;
                this.bookAuthor = res.author;
                this.bookStatus = res.bookStatus;
                this.likes = res.likes;
                this.views = res.views;
                this.recommend = res.recommend;
                this.bookSlug = res.slug;
                this.category = res.categoryId
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

<template>
    <div>
        <Header></Header>
        <bookInfo v-if="loadFlag"></bookInfo>
        <bookNav v-if="loadFlag"></bookNav>
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
            bookAuthorSlug: "",
            bookStatus: "",
            category: null,
            likes: null,
            views: null,
            recommend: null,
            bookSlug: this.$route.params.slug,
            bookTotalChapters: null,

            bookUser: "",
            bookUserId: null,
            bookIntroduce: "",
            bookId: this.$route.params.id,

            loadFlag: false,
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
                // this.avatar = res.Avatar;
                // this.bookName = res.BookName;
                // this.bookAuthor = res.Author.AuthorName;
                // this.bookAuthorId = res.Author.AuthorId;
                // this.bookAuthorSlug = res.Author.Slug;
                // this.bookStatus = res.BookStatus;
                // this.likes = res.Likes;
                // this.views = res.Views;
                // this.recommend = res.Recommends;
                // this.bookSlug = res.Slug;
                // this.category = res.Category.CategoryName;
                // this.bookUser = res.User;
                // this.bookUserId = res.UserId;
                // this.bookIntroduce = res.Introduce;
                // this.bookId = res.BookId;
                // this.bookTotalChapters = res.TotalChapters
                // this.$store.dispatch('setAuthorId', this.bookAuthorId)
                // this.$store.dispatch('setUserIdTemp', this.bookUserId)
                this.$store.dispatch("setBookStore", res);
                console.log(
                    this.$store.state.bookStore,
                    "bookstore trong state ne"
                );
                this.loadFlag = true;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

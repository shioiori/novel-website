<template>
    <div>
        <Header></Header>
        <div class="container">
            <billboardNav></billboardNav>
            <div class="book-list row row-cols-5">
                <billboardItem
                    v-for="(item, index) in bookArray"
                    :key="index"
                    :slug="item.slug"
                    :avatar="item.avatar"
                    :bookName="item.bookName"
                    :bookId="item.bookId"
                    :authorName="item.authorName"
                    :userName="item.userName"
                    :bookStatus="item.bookStatus"
                    :views="item.views"
                    :likes="item.likes"
                    :recommends="item.recommends"
                ></billboardItem>
            </div>
            <div class="rank-box-main-pagination">
                <ul class="pagination justify-content-end">
                    <li class="page-item">
                        <a
                            class="page-link"
                            href="/bo-loc?pageNumber=@Math.Max(1, pageNumber - 1)"
                        >
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>

                    <li class="page-item">
                        <a class="page-link" href="/bo-loc?pageNumber=@i">@i</a>
                    </li>

                    <li class="page-item">
                        <a
                            class="page-link"
                            href="/bo-loc?pageNumber=@Math.Min(pageNumber + 1, pageCount)"
                        >
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import billboardNav from "./billboardNav.vue";
import billboardItem from "./billboardItem.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "billboard-layout",
    components: {
        Header,
        Footer,
        billboardNav,
        billboardItem,
    },
    data() {
        return {
            bookArray: [],
            key: "",
            slug: "",
            avatar: "",
            bookName: "",
            bookId: "",
            authorName: "",
            userName: "",
            bookStatus: "",
            views: 0,
            likes: 0,
            recommends: 0,
        };
    },
    created() {
        this.fetchData();
    },
    computed: {
        bookArr() {
            return this.$store.getters.getBookArr
        }
    },
    watch: {
        bookArr(newArr) {
            this.bookArray = newArr
        }
    },
    methods: {
        async fetchData() {
            try {
                let url = `${apiPath}/book/get-all`;
                let res = (await axios.get(url)).data;
                this.bookArray = res;
                console.log(this.bookArray)
            } catch (e) {
                console.log(e);
            }
        }, 
    },
};
</script>

<style>
.container {
    padding-top: 20px;
    margin: auto;
    width: 1200px;
}
.book-list {
    margin-top: 1rem;
}
</style>

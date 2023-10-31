<template>
    <div>
        <Header></Header>
        <div class="container">
            <lopnav></lopnav>
            <div class="topic-list row">
                <lopitem
                    v-for="(item, index) in postArr"
                    :key="index"
                    :avatar="item.avatar"
                    :title="item.title"
                    :userName="item.userName"
                    :createdDate="item.createdDate"
                    :description="item.description"
                ></lopitem>
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
import lopnav from "./lopNav.vue";
import lopitem from "./lopItem.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "listofpost-layout",
    components: {
        Header,
        Footer,
        lopnav,
        lopitem,
    },
    data() {
        return {
            postArray: [],
            avatar: "",
            title: "",
            userName: "",
            createdDate: "",
            description: "",
        };
    },
    created() {
        this.getPostArray();
    },
    computed: {
        postArr() {
            return this.$store.getters.getPostArray;
        },
    },
    watch: {
        postArr(newArr) {
            console.log(newArr);
        },
    },
    methods: {
        async getPostArray() {
            try {
                let url = `${apiPath}/post/get-by-filter`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay post");
                this.postArray = res;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

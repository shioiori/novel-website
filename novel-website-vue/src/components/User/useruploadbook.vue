<template>
    <div class="row-right">
        <Userbooklist
            v-if="tabFlag == 1"
            @tabChange="handleTabChange"
        ></Userbooklist>
        <Userchapterlist
            v-if="tabFlag == 2"
            @tabChange="tabFlag = 1"
            :chapterArr="chapterArr"
        ></Userchapterlist>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import "../../assets/css/truyendadang.css";
import Userbooklist from "./userbooklist.vue";
import Userchapterlist from "./userchapterlist.vue";

export default {
    name: "user-uploadbook",
    data() {
        return {
            tabFlag: 1,
            chapterArr: [],
        };
    },
    created() {
        this.fetchBookArr();
    },
    methods: {
        async fetchBookArr() {
            try {
                let url = `${apiPath}/book/get-by-user?userId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res);
                this.userBookArr = res;
            } catch (e) {
                console.log(e);
            }
        },
        async handleTabChange(bookId) {
            try {
                let url = `${apiPath}/chapter/get-all?bookId=${bookId}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, "chapterArr");
                this.chapterArr = res;
                this.tabFlag = 2;
                this.$store.dispatch('setBookId', bookId)
            } catch (e) {
                console.log(e);
            }
        },
    },
    components: { Userbooklist, Userchapterlist },
};
</script>

<style>
.describe-userupload p {
    display: -webkit-box !important;
    -webkit-box-orient: vertical !important;
    -webkit-line-clamp: 3;
    overflow: hidden !important;
    white-space: initial !important;
}
.user-upload-book-btn p > a:first-child {
    margin-right: 1rem !important;
}
.user-upload-book-btn p {
    margin-left: 1rem;
}
</style>

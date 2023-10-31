<template>
    <div class="index__right-wrap col-md-9" id="newbook">
        <div class="index__right-wrap--list row">
            <truyenItem
                v-for="(item, index) in bookArray"
                :key="index"
                :avatar="item.avatar"
                :bookName="item.bookName"
                :author="item.author"
                :numbChap="item.numbChap"
                :views="item.views"
                :category="item.category"
                :describe="item.describe"
            ></truyenItem>
        </div>
    </div>
</template>

<script>
import truyenItem from "./truyenItem.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "truyenMoi-layout",
    components: {
        truyenItem,
    },
    props: {
        itemStatus: String,
    },
    data() {
        return {
            bookArray: [],
        };
    },
    created() {
        this.fetchBook();
    },
    methods: {
        async fetchBook() {
            try {
                let url = `${apiPath}/book/get-by-book-status?status=${this.itemStatus}`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay sach moi");
                for (let i = 0; i < 6; i++) {
                    this.bookArray.push(res.data[i]);
                }
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

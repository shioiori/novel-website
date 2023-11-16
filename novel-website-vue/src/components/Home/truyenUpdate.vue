<template>
    <div class="index__truyenmoi col-md-3">
        <h4>Truyện mới cập nhật</h4>
        <div class="index__truyenmoi--list">
            <ul class="list-group list-group-flush" id="new-chapters">
                <li class="list-group-item" v-for="(item, index) in bookArray" :key="index">
                    <i class="fa-solid fa-book-open"></i>
                    <a href="/book">{{ item.BookName }}</a>
                    <span class="index__truyenmoi--chuong">{{ item.TotalChapters }}</span>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "truyenUpdate-layout",
    data() {
        return {
            bookArray: []
        }
    },
    created() {
        this.getBookArray()
    },
    methods: {
        async getBookArray() {
            try {
                let url = `${apiPath}/book/get-by-book-status?status=contiep`
                let res = (await axios.get(url)).data.Data
                console.log(res, "top moi cap nhat");
                this.bookArray = res
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

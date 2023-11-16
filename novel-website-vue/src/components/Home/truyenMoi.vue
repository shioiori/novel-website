<template>
    <div class="index__right-wrap col-md-9" id="newbook">
        <div class="index__right-wrap--list row">
            <truyenItem
                v-for="(item, index) in bookArray"
                :key="index"
                :Avatar="item.Avatar"
                :BookName="item.BookName"
                :Author="item.Author.AuthorName"
                :TotalChapters="item.TotalChapters"
                :Views="item.Views"
                :Category="item.Category.CategoryName"
                :Introduce="item.Introduce"
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
                console.log(123)
                console.log(url,"sach moi")
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lay sach moi");
                res.forEach((item, index) => {
                    this.bookArray.push(item);
                    if (index > 5) return;
                });
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

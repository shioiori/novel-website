<template>
    <div class="index__left-wrap col-md-3" id="newbook-avatar">
        <div class="index__left-wrap-detail card">
            <img class="card-img-top" :src="bookCoverCard" alt="Card image" />
            <div class="card-body">
                <h4 class="card-title">
                    <a @click="$router.push(`/book/${bookSlugCard}/${bookId}`)">{{ bookNameCard }}</a>
                </h4>
                <p class="card-text index__left-wrap--theloai">
                    {{ bookCategoryCard }}
                </p>
                <p class="card-text index__left-wrap--sochuong">
                    {{ bookNumberChaptersCard }} chương
                </p>
                <p class="card-text index__left-wrap--gioithieu">
                    <i v-html="bookDescribeCard"> </i>
                </p>
                <a
                    href="/html/truyen.html"
                    class="btn btn-primary index__left-wrap--cardbtn"
                >
                    Đọc truyện
                    <i class="fa-solid fa-chevron-right"></i>
                </a>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "truyenCard-layout",
    data() {
        return {
            bookNameCard: "",
            bookCoverCard: "",
            bookCategoryCard: "",
            bookNumberChaptersCard: "",
            bookDescribeCard: "",
            bookSlugCard: "",
            bookId: "",
        };
    },
    props: {
        itemStatus: String,
    },
    created() {
        this.fetchBook();
    },
    methods: {
        async fetchBook() {
            try {
                let url = `${apiPath}/book/get-by-book-status?status=${this.itemStatus}`;
                let res = (await axios.get(url)).data.Data[0];
                console.log(res, "lay sach moi");
                this.bookNameCard = res.BookName;
                this.bookCategoryCard = res.Category.CategoryName;
                this.bookDescribeCard = res.Introduce;
                this.bookCoverCard = res.Avatar;
                this.bookNumberChaptersCard = res.TotalChapters;
                this.bookSlugCard = res.Slug;
                this.bookId = res.BookId
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

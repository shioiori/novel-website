<template>
    <div class="index__left-wrap col-md-3" id="newbook-avatar">
        <div class="index__left-wrap-detail card">
            <img class="card-img-top" :src="bookCoverCard" alt="Card image" />
            <div class="card-body">
                <h4 class="card-title">
                    <a href="/html//truyen.html">{{ bookNameCard }}</a>
                </h4>
                <p class="card-text index__left-wrap--theloai">
                    {{ bookCategoryCard }}
                </p>
                <p class="card-text index__left-wrap--sochuong">
                    {{ bookNumberChaptersCard }}
                </p>
                <p class="card-text index__left-wrap--gioithieu">
                    <i>
                        {{ bookDescribeCard }}
                    </i>
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
                let res = (await axios.get(url)).data;
                console.log(res, "lay sach moi");
                this.bookNameCard = res.bookNameCard
                this.bookCategoryCard = res.bookCategoryCard
                this.bookDescribeCard = res.bookDescribeCard
                this.bookCoverCard = res.bookCoverCard
                this.bookNumberChaptersCard = res.bookNumberChaptersCard
                this.bookSlugCard = res.bookSlugCard
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

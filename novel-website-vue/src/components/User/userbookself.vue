<template>
    <div class="row-right col-md-9">
        <div class="reading"><span>Đang đọc</span></div>
        <div class="index__right-wrap--list row">
            <div
                class="index__right-wrap--listitem col-md-12"
                v-for="item in userBookArr"
                :key="item.id"
            >
                <div class="book--img">
                    <a href="/truyen/@item.Slug-@item.BookId">
                        <img :src="item.avatar" class="book--imgcss" />
                    </a>
                </div>
                <div class="book--info">
                    <div class="book-name">
                        <a href="/truyen/@item.Slug-@item.BookId">{{
                            item.bookName
                        }}</a>
                    </div>
                    <div class="book-state">
                        <a href="javascript:void(0)">{{ item.author }}</a>
                    </div>

                    <div class="describe">
                        <i class="fa-solid fa-quote-left"></i>
                        {{ item.introduce }}
                    </div>
                </div>
            </div>
        </div>
        <div class="rank-box-main-pagination">
            <ul class="pagination justify-content-end pagination-user">
                <li class="page-item">
                    <a
                        class="page-link"
                        href="/bo-loc?pageNumber=@Math.Max(1, pageNumber - 1)"
                    >
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>
                <li class="page-item">
                    <a class="page-link" href="/bo-loc?pageNumber=@i"></a>
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
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "user-bookself",
    data() {
        return {
            userBookArr: [],
        };
    },
    created() {
        this.fetchBookArr()
    },
    methods: {
        async fetchBookArr() {
            try {
                let url = `${apiPath}/book/get-by-interaction-type?type=3`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.userBookArr = res.data;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

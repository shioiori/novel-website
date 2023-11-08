<template>
    <div class="row-right col-md-9">
        <div class="row" style="padding: 0 10px 10px">
            <div class="reading col-md-6">
                <span>Truyện đã đăng</span>
            </div>
            <div class="col-md-6" style="padding-right: 0">
                <a
                    class="btn btn-secondary float-end"
                    @click="changeTab()"
                    v-if="userFlag"
                    >Đăng truyện mới</a
                >
            </div>
        </div>
        <div class="rank-view-list">
            <div class="rank-view-list-item user-upload-book">
                <ul class="list-group" id="filter-book">
                    <li
                        class="list-group-item col-12"
                        v-for="truyen in userBookArr"
                        :key="truyen.id"
                    >
                        <div class="book--img">
                            <a href="javascript:void(0)">
                                <img
                                    :src="truyen.avatar"
                                    class="book--imgcss"
                                />
                            </a>
                        </div>
                        <div class="book--info">
                            <h3>
                                <a href="/truyen/@item.Slug-@item.BookId">{{
                                    truyen.bookName
                                }}</a>
                            </h3>
                            <div class="book-state">
                                <a href="javascript:void(0)">{{
                                    truyen.authorName
                                }}</a>
                                <i>|</i>
                                {{ truyen.bookStatus }}
                                <i>|</i>
                                {{ truyen.numberOfChapter }}
                            </div>
                            <div class="describe">
                                <i class="fa-solid fa-quote-left"></i>
                                {{ truyen.describe }}
                            </div>
                        </div>
                        <div class="book--info-buttons user-upload-book-btn">
                            <p>
                                <a
                                    class="btn"
                                    href="/dang-tai/@item.UserId/truyen/@item.BookId"
                                    >Sửa truyện</a
                                >
                                <a
                                    class="btn"
                                    href="/dang-tai/@item.UserId/truyen/@item.BookId/danh-sach-chuong"
                                    >Danh sách chương</a
                                >
                            </p>
                        </div>
                    </li>
                </ul>
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
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import "../../assets/css/truyendadang.css";
import { EventBus } from "@/main";

export default {
    name: "user-uploadbook",
    data() {
        return {
            userBookArr: [],
        };
    },
    props: {
        userFlag: Boolean
    },
    created() {
        this.fetchBookArr();
    },
    methods: {
        async fetchBookArr() {
            try {
                let url = `${apiPath}/book/get-by-author?authorId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.userBookArr = res.data;
            } catch (e) {
                console.log(e);
            }
        },
        changeTab() {
            EventBus.$emit('changeTab', 4)
        }
    },
};
</script>

<style></style>

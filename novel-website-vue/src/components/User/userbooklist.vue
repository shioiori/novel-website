<template>
  <div class="col-md-12">
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
                        :key="truyen.BookId"
                    >
                        <div class="book--img">
                            <a href="javascript:void(0)">
                                <img
                                    :src="truyen.Avatar"
                                    class="book--imgcss"
                                />
                            </a>
                        </div>
                        <div class="book--info">
                            <h3>
                                <a href="/truyen/@item.Slug-@item.BookId">{{
                                    truyen.BookName
                                }}</a>
                            </h3>
                            <div class="book-state">
                                <a href="javascript:void(0)">{{
                                    truyen.Author.AuthorName
                                }}</a>
                                <i>|</i>
                                {{ truyen.BookStatus }}
                                <i>|</i>
                                {{ truyen.TotalChapters }}
                            </div>
                            <div class="describe-userupload">
                                <i class="fa-solid fa-quote-left"></i>
                                <p v-html="truyen.Introduce"></p>
                            </div>
                        </div>
                        <div class="book--info-buttons user-upload-book-btn">
                            <p>
                                <a
                                    class="btn"
                                    @click="suatruyen(truyen)"
                                    >Sửa truyện</a
                                >
                                <a
                                    class="btn"
                                    @click="$emit('tabChange', truyen.BookId)"
                                    >Danh sách chương</a
                                >
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import { EventBus } from "@/main";
export default {
    name: "userbooklist-layout",
    data() {
        return {
            userBookArr: [],
            userFlag: false
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
                let header = {
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("JWT"),
                    },
                }
                console.log(res);
                this.userBookArr = res;
                let flagCheckId = (await axios.get(`${apiPath}/user/get-user`, header)).data.UserId
                if(flagCheckId == this.$route.params.id) {
                    this.userFlag = true;
                }
            }
            catch (e) {
                console.log(e);
            }
        },
        changeTab() {
            EventBus.$emit("changeTab", 4);
        },
        changeTabFix() {
            EventBus.$emit("changeTab", 5);
        },
        suatruyen(item) {
            this.changeTabFix();
            this.$store.dispatch('setBookFixItem', item)
        }
    },
}
</script>

<style>
.user-upload-book {
    padding: 0;
}
</style>
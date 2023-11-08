<template>
    <div>
        <Header></Header>
        <div class="row user-layout">
            <div class="row-left col-md-3">
                <ul class="row-lef-top">
                    <li
                        class="col-left"
                        id="hoso"
                        :class="{ 'active-userprofile': flag == 1 }"
                    >
                        <a @click="changeTab(1)"
                            ><i class="fa fa-user"></i>Hồ sơ</a
                        >
                    </li>

                    <li
                        class="col-left"
                        id="tutruyen"
                        :class="{ 'active-userprofile': flag == 2 }"
                    >
                        <a @click="changeTab(2)">
                            <i class="fa fa-book"></i>Tủ truyện
                        </a>
                    </li>

                    <li
                        class="col-left"
                        id="truyendang"
                        :class="{ 'active-userprofile': flag == 3 }"
                    >
                        <a @click="changeTab(3)"
                            ><i class="fa fa-bell"></i>Truyện đã đăng</a
                        >
                    </li>
                    <li
                        class="col-left"
                        :class="{ 'active-userprofile': flag == 4 }"
                        v-if="userFlag"
                    >
                        <a @click="changeTab(4)">
                            <i class="fa-solid fa-briefcase"></i>
                            Đăng truyện
                        </a>
                    </li>
                </ul>
                <!-- <ul class="row-lef-bottom">
                    <li id="dangtruyen" class="col-left">
                        <a href="/dang-tai/@Model.UserId/truyen">
                            <i
                                class="fa-sharp fa-light fa-book-circle-arrow-up"
                            ></i>
                            Đăng truyện
                        </a>
                    </li>
                    <li class="col-left">
                        <a href="/ho-so/@Model.UserId/truyen-da-dang">
                            <i class="fa-solid fa-briefcase"></i>
                            Quản lí truyện
                        </a>
                    </li>
                    <li class="col-left">
                        <a href="/ho-so/@Model.UserId/bao-mat"
                            ><i class="fa-solid fa-shield-halved"></i>Bảo mật</a
                        >
                    </li>
                </ul> -->
            </div>
            <UserProfile v-if="flag == 1"></UserProfile>
            <UserBookself v-if="flag == 2"></UserBookself>
            <UserUploadBook v-if="flag == 3" :user-flag="userFlag"></UserUploadBook>
            <UserCreateBook v-if="flag == 4 && userFlag"></UserCreateBook>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import "../../assets/css/userprofile.css";
import UserProfile from "../User/userprofile.vue";
import UserBookself from "../User/userbookself.vue";
import UserUploadBook from "../User/useruploadbook.vue";
import UserCreateBook from "../User/usercreatebook.vue";
import { EventBus } from "@/main";

import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "user-layout",
    components: {
        Header,
        Footer,
        UserProfile,
        UserBookself,
        UserUploadBook,
        UserCreateBook,
    },
    data() {
        return {
            flag: 1,
            userFlag: false,
            userId: null,
        };
    },
    mounted() {
        EventBus.$on("changeTab", (flag) => {
            this.flag = flag;
        });
        this.fetchUser()
    },
    methods: {
        changeTab(tabIndex) {
            this.flag = tabIndex;
        },
        async fetchUser() {
            try {
                let url = `${apiPath}/user/get-by-id?userId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                let flagCheckId = this.$store.state.userId
                this.userId = res.userId;
                if(flagCheckId == this.userId) {
                    this.userFlag = true;
                }
                console.log(this.userFlag)
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

<template>
    <div class="col login">
        <!-- <management></management>
        <notification></notification> -->
        <a
            href="#"
            data-bs-toggle="modal"
            data-bs-target="#dangnhap"
            v-if="!loginFlag"
        >
            <i class="fa-solid fa-user"></i>
            Tài khoản
            <i class="fa-solid fa-right-to-bracket"></i>
        </a>
        <loginAvatar
            v-if="loginFlag"
            :user-id="id"
            :user-slug="slug"
            :avatar="avatar"
        ></loginAvatar>
    </div>
</template>

<script>
// import notification from "./notification.vue";
// import management from "./management.vue";
import loginAvatar from "./loginAvatar.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "login-layout",
    components: {
        // notification,
        // management,
        loginAvatar,
    },
    data() {
        return {
            loginFlag: false,
            id: null,
            slug: "",
            avatar: "",
        };
    },
    mounted() {
        this.checkLogin();
    },
    methods: {
        async checkLogin() {
            if (localStorage.getItem("JWT") != null) {
                let url = `${apiPath}/user/get-user`;
                let header = {
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("JWT"),
                    },
                };
                console.log(header);
                let res = (await axios.get(url, header)).data;
                console.log(res, "user thong tin");
                if (res) {
                    this.loginFlag = true;
                    this.id = res.UserId;
                    this.avatar = res.Avatar;
                    this.slug = res.Username;
                    this.$store.dispatch("setAuthenFlag", true);
                } else {
                    this.loginFlag = false;
                }
            } else {
                return;
            }
        },
    },
};
</script>

<style></style>

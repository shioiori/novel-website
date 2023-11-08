<template>
    <div class="col login">
        <management></management>
        <notification></notification>
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
import notification from "./notification.vue";
import management from "./management.vue";
import loginAvatar from "./loginAvatar.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "login-layout",
    components: {
        notification,
        management,
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
            let token = this.$store.state.token;
            let userId = this.$store.state.userId;
            if (token) {
                this.loginFlag = true;
                try {
                    let url = `${apiPath}/user/get-by-id?userId=${userId}`;
                    let res = (await axios.get(url)).data;
                    console.log(res);
                    this.id = res.userId;
                    this.slug = res.username;
                    this.avatar = res.avatar;
                } catch (e) {
                    console.log(e);
                }
            } else {
                this.loginFlag = false;
            }
        },
    },
};
</script>

<style></style>

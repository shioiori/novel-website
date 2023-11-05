<template>
    <div class="col login">
        <management></management>
        <notification></notification>
        <a href="#" data-bs-toggle="modal" data-bs-target="#dangnhap" v-if="!loginFlag">
            <i class="fa-solid fa-user"></i>
            Tài khoản
            <i class="fa-solid fa-right-to-bracket"></i>
        </a>
        <loginAvatar v-if="loginFlag"></loginAvatar>
    </div>
</template>

<script>
import notification from './notification.vue';
import management from './management.vue';
import loginAvatar from './loginAvatar.vue';

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
        }
    },
    mounted() {
        this.checkLogin()
    },
    methods: {
        checkLogin() {
            let token = this.$store.state.token;
            if(token) {
                this.loginFlag = true;
            } else {
                this.loginFlag = false;
            }
        }
    }
};
</script>

<style></style>

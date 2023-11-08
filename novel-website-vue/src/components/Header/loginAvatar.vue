<template>
    <div class="dropdown avatar-dropdown">
        <a
            class="login-avatar"
            href="#"
            role="button"
            id="dropdownMenuLink"
            data-bs-toggle="dropdown"
            aria-expanded="false"
        >
            <img :src="avatar" />
        </a>

        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <li><a class="dropdown-item" @click="$router.push(`/user/${userSlug}-${userId}?auth=true`)">Trang cá nhân</a></li>
            <li><a class="dropdown-item" @click="onLogOut()">Thoát</a></li>
        </ul>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "avatar-layout",
    props: {
        avatar: String,
        userId: Number,
        userSlug: String,
    },
    methods: {
        async onLogOut() {
            try {
                let url = `${apiPath}/logout?returnURL=%2F`;
                let res = await axios.get(url)
                console.log(res, 'res logout')
                this.$store.dispatch('clearToken')
                window.location.reload()
            } catch (e) {
                console.log(e);
            }
        },
    },

};
</script>

<style>
.avatar-dropdown {
    margin: auto 0;
}
.login-avatar img {
    width: 44px;
    height: 44px;
    border-radius: 100%;
}
</style>

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
            <li><a class="dropdown-item" @click="changeRoute()">Trang cá nhân</a></li>
            <li><a class="dropdown-item" @click="onLogOut()">Thoát</a></li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "avatar-layout",
    props: {
        avatar: String,
        userId: String,
        userSlug: String,
    },
    methods: {
        onLogOut() {
            try {
                localStorage.removeItem('JWT')
                window.location.reload()
                this.$store.dispatch('setAuthenFlag', false);
            } catch (e) {
                console.log(e);
            }
        },
        changeRoute() {
            if(this.userSlug == this.$route.params.slug && this.userId == this.$route.params.id) {
                return;
            } else {
                this.$router.push(`/user/${this.userSlug}-${this.userId}`)
            }
        }
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

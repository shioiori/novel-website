<template>
    <div class="header__main">
        <div class="header__box--center row">
            <headerLogo></headerLogo>
            <headerSearch></headerSearch>
            <login></login>
            <loginModal></loginModal>
            <registerModal></registerModal>
        </div>
        <div class="navbar navbar-expand-md">
            <headerNavbar></headerNavbar>
        </div>
    </div>
</template>

<script>
import headerLogo from "./headerLogo.vue";
import login from "./login.vue";
import registerModal from "./registerModal.vue";
import loginModal from "./loginModal.vue";
import headerNavbar from "./headerNavbar.vue";
import headerSearch from "./headerSearch.vue";
// import headerdropdown from "./headerDropdown.vue";

export default {
    name: "header_layout",
    components: {
        headerLogo,
        login,
        loginModal,
        registerModal,
        headerNavbar,
        headerSearch,
        // headerdropdown,
    },
};
</script>

<style></style>

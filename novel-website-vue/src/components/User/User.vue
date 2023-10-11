<template>
    <div>
        <Header></Header>
        <div class="row user-layout">
            <UserNavBar></UserNavBar>
            <UserProfile v-if="flag == 1"></UserProfile>
            <UserBookself v-if="flag == 2"></UserBookself>
            <UserUploadBook v-if="flag == 3"></UserUploadBook>
            <UserCreateBook v-if="flag == 4"></UserCreateBook>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import "../../assets/css/userprofile.css";
import UserNavBar from "../User/usernavbar.vue";
import UserProfile from "../User/userprofile.vue";
import UserBookself from "../User/userbookself.vue";
import UserUploadBook from "../User/useruploadbook.vue";
import UserCreateBook from "../User/usercreatebook.vue";

export default {
    name: "user-layout",
    components: {
        Header,
        Footer,
        UserNavBar,
        UserProfile,
        UserBookself,
        UserUploadBook,
        UserCreateBook,
    },
    data() {
        return {
            flag: 1,
        };
    },
};
</script>

<style></style>

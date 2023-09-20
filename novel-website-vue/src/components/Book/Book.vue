<template>
    <div>
        <Header></Header>
        <bookInfo></bookInfo>
        <bookNav></bookNav>
        <Footer></Footer>
    </div>
</template>

<script>
import '../../assets/css/truyen.css'
import Header from '../Header/Header.vue'
import Footer from '../Footer/Footer.vue'
import bookInfo from './bookInfo.vue';
import bookNav from './bookNav.vue';

export default {
    name: "book-layout",
    components: {
        Header,
        Footer,
        bookInfo,
        bookNav
    }
};
</script>

<style></style>

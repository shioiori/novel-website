<template>
    <div>
        <Header></Header>
        <div class="container body-container">
            <div class="content">
                <a href="/truyen/@Model.Book.Slug-@Model.BookId"><h1 class="truyen-title">{{ bookName }}</h1></a>
                <h2 class="truyen-chapter">Chương {{ chapNumb }}: {{ chapName }}</h2>
                <p class="truyen-author">
                    Người đăng:
                    <a href="javascript:void(0)">{{ authorName }}</a>
                </p>
                <p class="truyen-time">Ngày đăng: {{ createdDate }}</p>
            </div>
            <chapterContent></chapterContent>
        </div>
        <Footer></Footer>
    </div>
  
</template>

<script>
import '../../assets/css/truyen.css'
import '../../assets/css/doctruyen.css'
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import chapterContent from './chapterContent.vue'

export default {
    name: 'chapter-layout',
    components: {
        Header,
        Footer,
        chapterContent,
    },
    data() {
        return {
            bookName: "",
            chapNumb: "",
            chapName: "",
            authorName: "",
            createdDate: "",
        }
    }
}
</script>

<style>

</style>
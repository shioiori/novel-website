<template>
    <div>
        <Header></Header>
        <div class="container body-container">
            <div class="content">
                <a href="/truyen/@Model.Book.Slug-@Model.BookId"><h1 class="truyen-title">@Model.Book.BookName</h1></a>
                <h2 class="truyen-chapter">Chương @Model.ChapterNumber: @Model.ChapterName</h2>
                <p class="truyen-author">
                    Người đăng:
                    <a href="javascript:void(0)">@Model.Book.Author.AuthorName</a>
                </p>
                <p class="truyen-time">Ngày đăng: @Model.CreatedDate</p>
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
    }
}
</script>

<style>

</style>
<template>
    <div>
        <Header></Header>
        <div class="container">
            <billboardNav></billboardNav>
            <div class="book-list row row-cols-5">
                <billboardItem></billboardItem>
                <billboardItem></billboardItem>
                <billboardItem></billboardItem>
                <billboardItem></billboardItem>
                <billboardItem></billboardItem>
                <billboardItem></billboardItem>
            </div>
            <div class="rank-box-main-pagination">
                <ul class="pagination justify-content-end">
                    <li class="page-item">
                        <a
                            class="page-link"
                            href="/bo-loc?pageNumber=@Math.Max(1, pageNumber - 1)"
                        >
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>

                    <li class="page-item">
                        <a class="page-link" href="/bo-loc?pageNumber=@i">@i</a>
                    </li>

                    <li class="page-item">
                        <a
                            class="page-link"
                            href="/bo-loc?pageNumber=@Math.Min(pageNumber + 1, pageCount)"
                        >
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import billboardNav from "./billboardNav.vue";
import billboardItem from "./billboardItem.vue";

export default {
    name: "billboard-layout",
    components: {
        Header,
        Footer,
        billboardNav,
        billboardItem,
    },
};
</script>

<style>
.container {
    padding-top: 20px;
    margin: auto;
    width: 1200px;
}
</style>

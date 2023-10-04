<template>
    <div>
        <Header></Header>
        <div class="container">
            <lopnav></lopnav>
            <div class="topic-list row">
                <lopitem></lopitem>
                <lopitem></lopitem>
                <lopitem></lopitem>
                <lopitem></lopitem>
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
                            <a class="page-link" href="/bo-loc?pageNumber=@i"
                                >@i</a
                            >
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
import lopnav from "./lopNav.vue";
import lopitem from "./lopItem.vue";

export default {
    name: "listofpost-layout",
    components: {
        Header,
        Footer,
        lopnav,
        lopitem,
    }
};
</script>

<style></style>

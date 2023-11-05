<template>
    <div>
        <Header></Header>
        <div class="rank-box box-center row">
            <filterRanklist></filterRanklist>
            <div class="rank-box-main col-9">
                <div class="rank-box-main-header">
                    <h4>Bộ lọc</h4>
                    <filterRanktoolbar></filterRanktoolbar>
                </div>
                <filterRankbody></filterRankbody>
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
                                >i</a
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
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import "../../assets/css/boloc.css";
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import filterRanklist from "./filterRanklist.vue";
import filterRankbody from "./filterRankbody.vue";
import filterRanktoolbar from "./filterRanktoolbar.vue";

export default {
    name: "filter-layout",
    components: {
        Header,
        Footer,
        filterRanklist,
        filterRankbody,
        filterRanktoolbar
    },
};
</script>

<style>
.rank-box-main {
    width: 970px !important;
}
</style>

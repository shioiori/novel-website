<template>
    <div>
        <Header></Header>
        <div class="index__row row">
            <category></category>
            <carousel></carousel>
            <articleVue></articleVue>
        </div>
        <div class="index__row row">
            <truyenUpdate></truyenUpdate>
            <btvDecu></btvDecu>
        </div>
        <banner></banner>
        <div class="index__row row">
            <rankList :criteria="view" :criteria_name="'Lượt xem'"></rankList>
            <rankList :criteria="like" :criteria_name="'Yêu thích'"></rankList>
            <rankList :criteria="recommend" :criteria_name="'Đề cử'"></rankList>
            <rankList :criteria="follow" :criteria_name="'Theo dõi'"></rankList>
        </div>
        <banner></banner>
        <div class="index__row row">
            <h4 class="index__wrap-title">
                Truyện mới
                <a href="/bo-loc">
                    Tất cả
                    <i class="fa-solid fa-chevron-right"></i>
                </a>
            </h4>
            <truyenCard :item-status="CONTIEP"></truyenCard>
            <truyenMoi :item-status="CONTIEP"></truyenMoi>
        </div>
        <banner></banner>
        <div class="index__row row">
            <h4 class="index__wrap-title">
                Truyện hoàn thành
                <a href="/bo-loc">
                    Tất cả
                    <i class="fa-solid fa-chevron-right"></i>
                </a>
            </h4>
            <truyenCard :item-status="HOANTHANH"></truyenCard>
            <truyenMoi :item-status="HOANTHANH"></truyenMoi>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import category from "./category.vue";
import carousel from "./carousel.vue";
import articleVue from "./article.vue";
import truyenUpdate from "./truyenUpdate.vue";
import btvDecu from "./btvDecu.vue";
import banner from "./banner.vue";
import truyenCard from "./truyenCard.vue";
import truyenMoi from "./truyenMoi.vue";
import rankList from "./rankList.vue";
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";

export default {
    name: "home-layout",
    components: {
        category,
        carousel,
        articleVue,
        truyenUpdate,
        btvDecu,
        banner,
        truyenCard,
        truyenMoi,
        rankList,
        Header,
        Footer,
    },
};
</script>

<style></style>

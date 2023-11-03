<template>
    <div
        id="demo"
        class="index__slider carousel slide col-md-6"
        data-bs-ride="carousel"
    >
        <div class="carousel-indicators">
            <button
                type="button"
                data-bs-target="#demo"
                data-bs-slide-to="0"
                class="active"
            ></button>
            <button
                type="button"
                data-bs-target="#demo"
                data-bs-slide-to="1"
            ></button>
            <button
                type="button"
                data-bs-target="#demo"
                data-bs-slide-to="2"
            ></button>
        </div>
        <div class="carousel-inner" id="banner-carousel">
            <div :class="index == 1 ? 'carousel-item active' : 'carousel-item'" v-for="(item, index) in bannerArr" :key="index">
                <img :src=item class="d-block w-100" alt="..." />
            </div>
        </div>
        <button
            class="carousel-control-prev"
            type="button"
            data-bs-target="#demo"
            data-bs-slide="prev"
        >
            <span class="carousel-control-prev-icon"></span>
        </button>
        <button
            class="carousel-control-next"
            type="button"
            data-bs-target="#demo"
            data-bs-slide="next"
        >
            <span class="carousel-control-next-icon"></span>
        </button>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "carousel-layout",
    data() {
        return {
            bannerArr: [],
        };
    },
    created() {
        this.getBannerCarousel();
    },
    methods: {
        async getBannerCarousel() {
            try {
                let url = `${apiPath}/banner/get-home-banner`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.bannerArr = res.data;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

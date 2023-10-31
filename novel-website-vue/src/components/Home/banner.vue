<template>
    <div class="index__banner">
        <a href="javascript:void(0)"
            ><img :src="imgURL" class="banner-sm"
        /></a>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "banner-layout",
    data() {
        return {
            imgURL: "",
        };
    },
    created() {
        this.getBannerRandomize();
    },
    methods: {
        async getBannerRandomize() {
            try {
                let url = `${apiPath}/banner/get-random-advertise-banner`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.imgURL = res.data.bannerImage;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

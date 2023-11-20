<template>
    <div class="chapter">
        <div class="chapter-content">
            <boxChapter></boxChapter>
            <div class="quangcaotruyen">
                <a href="javascript:void(0)"
                    ><img src="../../assets/img/test2.jpg" class="banner-sm"
                /></a>
            </div>
            <chapterComment></chapterComment>
        </div>
    </div>
</template>

<script>
import boxChapter from "./boxChapter.vue";
import chapterComment from "./chapterComment.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "chapterContent",
    components: {
        boxChapter,
        chapterComment,
    },
    data() {
        return {
            imgURL: "",
            chapterContent: "",
            chapterLikes: null,
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
        // async getChapterContent() {
        //     try {
        //         let url = `${apiPath}/chapter/get-by-chapter-id?chapterId=${this.$route.params.Id}`;
        //         let res = (await axios.get(url)).data;
        //         console.log(res);
        //         this.chapterContent = res.data;
        //         this.chapterLikes = res.data;
        //     } catch (e) {
        //         console.log(e);
        //     }
        // },
    },
};
</script>

<style></style>

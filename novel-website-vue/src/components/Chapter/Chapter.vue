<template>
    <div>
        <Header></Header>
        <div class="container body-container">
            <div class="content">
                <a href=""
                    ><h1 class="truyen-title">{{ bookName }}</h1></a
                >
                <h2 class="truyen-chapter">
                    Chương {{ chapNumb }}: {{ chapName }}
                </h2>
                <!-- <p class="truyen-author">
                    Người đăng:
                    <a href="javascript:void(0)">{{ authorName }}</a>
                </p>
                <p class="truyen-time">Ngày đăng: {{ createdDate }}</p> -->
            </div>
            <chapterContent></chapterContent>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import "../../assets/css/truyen.css";
import "../../assets/css/doctruyen.css";
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import chapterContent from "./chapterContent.vue";
import { EventBus } from "@/main";

import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "chapter-layout",
    components: {
        Header,
        Footer,
        chapterContent,
    },
    data() {
        return {
            bookName: null,
            chapName: null,
            chapNumb: null,
        };
    },
    mounted() {
        EventBus.$on("changeChap", (value) => {
            console.log('eventbus gọi')
            if (value == 0) {
                this.chapNumb--;
            } else {
                this.chapNumb++;
            }
            this.fetchChapterByIndex();
        });
    },
    created() {
        this.fetchChapter();
    },
    methods: {
        async fetchChapter() {
            try {
                let url = `${apiPath}/chapter/get-by-chapter-index?bookId=${this.$route.params.id}&index=${this.$route.params.number}`;
                let res = (await axios.get(url)).data;
                console.log(url);
                console.log(res, "chapterurl 1");
                this.chapName = res.ChapterName;
                this.chapNumb = res.ChapterNumber;
                let url1 = `${apiPath}/book/get-by-book-id?bookId=${this.$route.params.id}`;
                let res1 = (await axios.get(url1)).data;
                console.log(url1, "chapterurl 2");
                this.bookName = res1.BookName;
                this.loadFlag = true;
            } catch (e) {
                console.log(e);
            }
        },
        async fetchChapterByIndex() {
            try {
                let url = `${apiPath}/chapter/get-by-chapter-index?bookId=${this.$route.params.id}&index=${this.chapNumb}`;
                let res = (await axios.get(url)).data;
                console.log(url);
                this.chapName = res.ChapterName;
                this.chapNumb = res.ChapterNumber;
                this.loadFlag = true;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

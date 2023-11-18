<template>
    <div class="book--chapter tab-pane container fade" id="book--chapter-id">
        <div class="book--chapter-wrap">
            <div class="volume">
                <h4>Danh sách chương</h4>
                <ul
                    class="list-group list-group-horizontal row"
                    id="list-chuong"
                >
                    <li class="list-group-item col-4" v-for="(item, index) in chapterArr" :key="index">
                        <a @click="$router.push(`/book/${bookContent.Slug}/${item.BookId}/chap-${item.ChapterId}`)"
                            >Chương {{ item.ChapterNumber }}: {{ item.ChapterName }}</a
                        >
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "bookNavChapter",
    props: {
        bookId: String,
    },
    data() {
        return {
            chapterArr: [],
            bookContent: this.$store.state.bookStore,
        }
    },
    mounted() {
        this.fetchChapter()
    },
    methods: {
        async fetchChapter() {
            try {
                let url = `${apiPath}/chapter/get-all?bookId=${this.bookContent.BookId}`;
                console.log(url, 'chapter')
                let res = (await axios.get(url)).data.Data;
                console.log(res, 'chapter');
                this.chapterArr = res;
            } catch (e) {
                console.log(e);
            }
        }
    }
};
</script>

<style>
.container {
    width: 1200px !important;
    margin: 20px auto !important;
    padding: initial !important;
}
#book--chapter-id.active {
    border: none;
}
</style>

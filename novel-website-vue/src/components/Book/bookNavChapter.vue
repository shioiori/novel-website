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
                        <a href="/html/doctruyen.html"
                            >Chương {{ item.number }}: {{ item.chapterName }}</a
                        >
                    </li>
                </ul>
            </div>
            <div class="book--pagination">
                <ul class="pagination justify-content-end">
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">1</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">2</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">3</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">4</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">5</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">571</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">572</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">
                            <span aria-hidden="true">&raquo;</span>
                        </a>
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
        bookId: Number,
    },
    data() {
        return {
            chapterArr: [],
        }
    },
    created() {
        this.fetchChapter()
    },
    methods: {
        async fetchChapter() {
            try {
                let url = `${apiPath}/chapter/get-by-book-id?bookId=${this.bookId}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.chapterArr = res.data;
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

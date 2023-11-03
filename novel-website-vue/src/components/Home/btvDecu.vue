<template>
    <div class="index__btv col-md-9">
        <h4>Biên tập viên đề cử</h4>
        <div id="editor-recommend">
            <div class="index__right-wrap--list row">
                <truyenItem
                    v-for="(item, index) in bookArray"
                    :key="index"
                    :avatar="item.avatar"
                    :bookName="item.bookName"
                    :author="item.author"
                    :numbChap="item.numbChap"
                    :views="item.views"
                    :category="item.category"
                    :describe="item.describe"
                ></truyenItem>
            </div>
        </div>
    </div>
</template>

<script>
import truyenItem from "./truyenItem.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "btv-layout",
    components: {
        truyenItem,
    },
    data() {
        return {
            bookArray: [],
        };
    },
    created() {
        this.fetchBookRecommended();
    },
    methods: {
        async fetchBookRecommended() {
            try {
                let url = `${apiPath}/book/get-top-by-interaction-type?type=8`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay sach btv de cu");
                for (let i = 0; i < 6; i++) {
                    this.bookArray.push(res.data[i]);
                }
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

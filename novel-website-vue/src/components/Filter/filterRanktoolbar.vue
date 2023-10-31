<template>
    <div class="rank-toolbar">
        <div class="tool-box">
            <div class="type-list">
                <p id="type-list">
                    <a
                        href="javascript:void(0)"
                        class="active--type-list"
                        @click="getBookByCategory()"
                        >Tất cả</a
                    >
                    <i>·</i>
                    <a href="javascript:void(0)" @click="getBookByCategory(item.id)" v-for="(item, index) in categoryArray" :key="index"
                        >{{ item.name }}</a
                    >
                    <i>·</i>
                </p>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "filterRanktoolbar",
    data() {
        return {
            categoryArray: []
        }
    },
    created() {
        this.fetchCategoryArray() 
    },
    methods: {
        async fetchCategoryArray() {
            try {
                let url = `${apiPath}/category/get-all`
                let res = (await axios.get(url)).data
                console.log(res, "lấy cate");
                this.categoryArray = res.data
            } catch (e) {
                console.log(e)
            }
        },
        async getBookByCategory(criteria) {
            let url
            try {
                if (criteria == "" || criteria == null) {
                    url = `${apiPath}/book/get-by-category`
                } else {
                    url = `${apiPath}/book/get-by-category/categoryId=${criteria}`
                }
                let res = (await axios.get(url)).data
                console.log(res, "lay sach theo tieu chi", criteria)
                this.$store.dispatch("setBookArr", res)
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

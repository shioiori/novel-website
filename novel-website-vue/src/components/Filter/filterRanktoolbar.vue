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
                    <a
                        href="javascript:void(0)"
                        @click="getBookByCategory(item.CategoryId)"
                        v-for="(item, index) in categoryArray"
                        :key="index"
                        >{{ item.CategoryName }}
                        <i>·</i>
                    </a>
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
            categoryArray: [],
        };
    },
    created() {
        this.fetchCategoryArray();
    },
    methods: {
        async fetchCategoryArray() {
            try {
                let url = `${apiPath}/category/get-all`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lấy cate");
                this.categoryArray = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getBookByCategory(criteria) {
            let url;
            try {
                if (criteria == "" || criteria == null) {
                    url = `${apiPath}/book/get-all`;
                    console.log(url)
                } else {
                    url = `${apiPath}/book/get-by-category-id?categoryId=${criteria}`;
                }
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lay sach theo tieu chi", criteria);
                this.$store.dispatch("setBookArr", res);
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
#type-list i {
    margin-right: 5px;
}
</style>

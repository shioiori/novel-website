<template>
    <div class="sort-box float-wrapper d-flex">
        <a
            type="button"
            id="dropdown1"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            >Thể loại<i
                class="fa fa-sort-desc"
                aria-hidden="true"
                style="
                    font-size: 1.6rem;
                    margin: 0 0.4rem;
                    vertical-align: top;
                    line-height: 1.2rem;
                "
            ></i
        ></a>
        <ul aria-labelledby="dropdown1" class="dropdown-menu">
            <li v-for="(item, index) in categoryArray" :key="index">
                <a
                    @click="getBookByCategory(item.CategoryId)"
                    class="dropdown-item"
                    >{{ item.CategoryName }}</a
                >
            </li>
            <li>
                <a class="dropdown-item" @click="getBookByCategory()"
                    >Tất cả</a
                >
            </li>
        </ul>
        <a
            type="button"
            id="dropdown2"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            >Xếp theo<i
                class="fa fa-sort-desc"
                aria-hidden="true"
                style="
                    font-size: 1.6rem;
                    margin: 0 0.4rem;
                    vertical-align: top;
                    line-height: 1.2rem;
                "
            ></i
        ></a>
        <ul aria-labelledby="dropdown2" class="dropdown-menu">
            <li v-for="(item, index) in criteria" :key="index">
                <a @click="getBookBySort(item[1])" class="dropdown-item">{{
                    item[0]
                }}</a>
            </li>
        </ul>
        <a
            class="ms-auto"
            type="button"
            id="dropdown3"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            >Lọc theo<i
                class="fa fa-sort-desc"
                aria-hidden="true"
                style="
                    font-size: 1.6rem;
                    margin: 0 0.4rem;
                    vertical-align: top;
                    line-height: 1.2rem;
                "
            ></i
        ></a>
        <ul aria-labelledby="dropdown3" class="dropdown-menu">
            <li>
                <a @click="getBookByDate(1)" class="dropdown-item"
                    >Mới nhất</a
                >
            </li>
            <li>
                <a @click="getBookByDate(0)" class="dropdown-item"
                    >Cũ nhất</a
                >
            </li>
        </ul>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "billboard-nav",
    data() {
        return {
            categoryArray: [],
            criteria: [
                ["Lượt yêu thích", 1],
                ["Lượt đề cử", 4],
                ["Lượt theo dõi", 3],
                ["Lượt đọc", 6],
            ],
        };
    },
    created() {
        this.getCategory();
    },
    methods: {
        async getCategory() {
            try {
                let url = `${apiPath}/category/get-all`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lay cate");
                this.categoryArray = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getBookByCategory(item) {
            try {
                let url;
                if (item == "" || item == null) {
                    url = `${apiPath}/book/get-all`;
                } else {
                    url = `${apiPath}/book/get-by-category-id?categoryId=${item}`;
                }
                console.log(url, 123)
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lay theo cate");
                this.$store.dispatch("setBookArr", res);
            } catch (e) {
                console.log(e);
            }
        },
        async getBookBySort(criteria) {
            try {
                let url = `${apiPath}/billboard/get-by-filter?interaction=${criteria}`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay theo tieu chi", criteria);
                this.$store.dispatch("setBookArr", res);
            } catch (e) {
                console.log(e);
            }
        },
        async getBookByDate(criteria) {
            try {
                let url = `${apiPath}/billboard/get-by-filter?sortOrder=${criteria}`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay theo ngay", criteria);
                this.$store.dispatch("setBookArr", res);
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
.sort-box {
    margin: auto;
    border-bottom: 1px solid #bbb;
    padding-bottom: 0.5rem;
}

.sort-box a {
    font-size: 1.2rem;
}

.sort-box a:first-child {
    margin-right: 0.5rem;
}
</style>

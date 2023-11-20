<template>
    <div class="sort-box d-flex review-nav">
        <div class="me-auto">
            <i
                class="fa fa-commenting"
                aria-hidden="true"
                style="font-size: 2rem; margin-right: 0.7rem; color: #343434"
            ></i
            ><span style="font-size: 1.37rem; font-weight: bold; color: #555555"
                >Review</span
            >
        </div>
        <a
            type="button"
            id="dropdown1"
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
        <ul aria-labelledby="dropdown1" class="dropdown-menu">
            <li>
                <a
                    @click="getReviewByOrderDate(0)"
                    class="dropdown-item"
                    >Mới nhất</a
                >
            </li>
            <li>
                <a
                    @click="getReviewByOrderDate(1)"
                    class="dropdown-item"
                    >Cũ nhất</a
                >
            </li>
        </ul>
        <a
            type="button"
            id="dropdown2"
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
        <ul aria-labelledby="dropdown2" class="dropdown-menu">
            <li v-for="(item, index) in categoryArray" :key="index">
                <a
                    @click="getReviewByCategory(item.CategoryId)"
                    class="dropdown-item"
                    >{{ item.CategoryName }}</a
                >
            </li>
            <li>
                <a @click="getTempReviewArr()" class="dropdown-item">Tất cả</a>
            </li>
        </ul>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "reviewnav-layout",
    data() {
        return {
            categoryArray: []
        }
    },
    created() {
        this.getCategory()
    },
    methods: {
        async getCategory() {
            try {
                let url = `${apiPath}/category/get-all?PageSize=20`
                let res = (await axios.get(url)).data.Data
                console.log(res, "lay cate");
                this.categoryArray = res
            } catch (e) {
                console.log(e)
            }
        },
        async getReviewByOrderDate(criteria) {
            try {
                let url = `${apiPath}/review/get-by-filter?orderDate=${criteria}`
                let res = (await axios.get(url)).data.Data
                console.log(res, "lay review theo ngay", criteria)
                this.$store.dispatch("setReviewArr", res)
            } catch (e) {
                console.log(e)
            }
        },
        async getReviewByCategory(item) {
            try {
                let url = `${apiPath}/review/get-by-filter?category=${item}`
                let res = (await axios.get(url)).data.Data
                console.log(res, "lay review theo cate")
                this.$store.dispatch("setReviewArr", res)
            } catch (e) {
                console.log(e)
            }
        },
        async getTempReviewArr() {
            try {
                let url = `${apiPath}/review/get-by-filter?PageSize=20`
                let res = (await axios.get(url)).data.Data
                console.log(res, "lay review theo cate all")
                this.$store.dispatch("setReviewArr", res)
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style>
.review-nav {
    align-items: center;
    margin-top: 2rem;
}
.review-nav a:nth-child(2) {
    margin-right: 1rem;
}
</style>

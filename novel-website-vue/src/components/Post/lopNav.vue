<template>
    <div class="sort-box float-wrapper d-flex lop-nav">
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
                <a @click="getPostByDate('down')" class="dropdown-item"
                    >Mới nhất</a
                >
            </li>
            <li>
                <a @click="getPostByDate('up')" class="dropdown-item"
                    >Cũ nhất</a
                >
            </li>
        </ul>

            <div class="right search input-group search-item">
                <input
                    type="text"
                    class="form-control shadow-none"
                    name="name"
                    placeholder="Nhập tiêu đề bài viết"
                    v-model="searchItem"
                />
                <button
                    class="btn btn-success btn--search-color"
                    type="submit"
                    title="searchButton"
                    @click="getPostBySearch(searchItem)"
                >
                    <i
                        class="fa-solid fa-magnifying-glass search__btn--icons"
                    ></i>
                </button>
            </div>

    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "lopnav-layout",
    data() {
        return {
            searchItem: "",
        }
    },
    methods: {
        async getPostByDate(criteria) {
            try {
                let url = `${apiPath}/post/get-by-filter?orderDate=${criteria}`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay post theo ngay", criteria);
                this.$store.dispatch("setPostArr", res);
            } catch (e) {
                console.log(e);
            }
        },
        async getPostBySearch(item) {
            try {
                let url = `${apiPath}/post/get-by-filter?name=${item}`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay post theo search", item);
                this.$store.dispatch("setPostArr", res);
            } catch (e) {
                console.log(e);
            }
        }
    },
};
</script>

<style>
.lop-nav {
    justify-content: space-between;
}
.search-item {
    margin: 0;
}
</style>

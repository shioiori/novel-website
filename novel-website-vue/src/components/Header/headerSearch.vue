<template>
    <div class="col search input-group">
        <input
            type="text"
            class="form-control shadow-none no-border-radius"
            name="searchName"
            placeholder="Nhập tên truyện"
            v-model="tentruyen"
        />
        <button
            class="btn btn-success btn--search-color no-border-radius"
            title="searchButton"
            @click="getBookSearch()"
        >
            <i class="fa-solid fa-magnifying-glass search__btn--icons"></i>
        </button>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "header-search",
    data() {
        return {
            tentruyen: "",
        };
    },
    methods: {
        async getBookSearch() {
            let path = this.$router.currentRoute.path;
            console.log(path);
            if (path == "/filter") {
                try {
                    let url = `${apiPath}/book/get-by-filter?SearchName=${this.tentruyen}`;
                    let res = (await axios.get(url)).data.Data;
                    console.log(res);
                    this.$store.dispatch("setBookArr", res);
                } catch (e) {
                    console.log(e);
                }
            } else {
                localStorage.setItem("searchName", this.tentruyen);
                this.$router.push("/filter");
            }
        },
    },
};
</script>

<style></style>

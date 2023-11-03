<template>
    <div class="index__ranklist col-md-3">
        <h4 class="index__wrap-title">
            {{ criteria_name }}
            <a href="/bang-xep-hang?sort_by=recommend">
                Tất cả
                <i class="fa-solid fa-chevron-right"></i>
            </a>
        </h4>
        <div class="ranklist--list">
            <ul class="list-group" id="book-most-recommends" v-for="(item, index) in bookArray" :key="index">
                <li class="list-group-item">
                    <i class="fa-solid fa-star"></i>
                    <a href="/book">{{ item.name }}</a>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "ranklist-layout",
    props: {
        criteria: String,
        criteria_name: String,
    },
    data() {
        return {
            bookArray: []
        }
    },
    created() {
        this.getBookArray()
    },
    methods: {
        async getBookArray() {
            try {
                let url = `${apiPath}/book/get-top-by-interaction-type?type=${this.criteria}`
                let res = (await axios.get(url)).data
                console.log(res, "danh muc");
                this.bookArray = res
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

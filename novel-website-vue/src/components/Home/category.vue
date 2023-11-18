<template>
    <div class="index__theloai col-md-3">
        <div class="index__theloai--wrap">
            <div class="index__theloai--chitiet row">
                <div class="index__theloai--chitiet-cot col-md-6" v-for="(item, index) in categoryArray" :key="index" @click="getBookByCategory(item.CategoryId)">
                    <a>
                        <!-- <i class="fa-solid fa-tags" :url="item.categoryImage"></i> -->
                        <img :src="item.CategoryImage" />
                        <span>
                            <p class="tentruyen">{{ item.CategoryName }}</p>
                            <p class="soluongtruyen">{{ item.Quantity }}</p>
                        </span>
                    </a>
                </div>
                <div class="index__theloai--chitiet-cot col-md-6" @click="$router.push(`/filter`)">
                    <a>
                        <i class="fa-solid fa-bars"></i>
                        <span>
                            <p class="tentruyen tatca">Tất cả</p>
                        </span>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "category-layout",
    data() {
        return {
            categoryArray: [],
            cateName: "",
            cateQuantity: "",
            cateKey: ""
        }
    },
    created() {
        this.getCategoryArray()
    },
    methods: {
        async getCategoryArray() {
            try {
                let url = `${apiPath}/category/get-all`
                let res = (await axios.get(url)).data
                console.log(res, "cateArray");
                this.categoryArray = res
            } catch (e) {
                console.log(e)
            }
        },
        async getBookByCategory(key) {
            try {
                let url = `${apiPath}/book/get-by-category?categoryId=${key}`
                let res = (await axios.get(url)).data
                console.log(res, "lay sach cate", key)
                this.$store.dispatch("setBookArr", res)
                this.$router.push('filter')
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

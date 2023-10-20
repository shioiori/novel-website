<template>
    <div class="index__tintuc col-md-3">
        <div class="index__notice">
            <h3>Tin tức</h3>
            <div class="index__notice--list">
                <ul class="list-group list-group-flush" id="new-posts">
                    <li :class="getClass(index)" v-for="(item, index) in post" :key="index">
                        <i class="fa-solid fa-share"></i>
                        <a href="javascript:void(0)">{{ item }}</a>
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
    name: "article-layout",
    data() {
        return {
            post: []
        }
    },
    mounted() {
        this.fetchArticle()
    },
    methods: {
        async fetchArticle() {
            try {
                const url = `${apiPath}/post/get-by-filter`
                let res = (await axios.get(url)).data
                console.log(res);
            } catch (e) {
                console.log(e)
            }
        },
        getClass(index) {
            return index % 2 == 0 ? 'list-group-item' : 'list-group-item odd'
        }
    }
};
</script>

<style></style>

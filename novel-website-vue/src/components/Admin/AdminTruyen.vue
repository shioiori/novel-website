<template>
    <div class="col-md-10">
        <admin-truyen-list v-if="flag == 1" @changeToChapter="changeTabChapter" @changeToDuyet="changeToDuyet"></admin-truyen-list>
        <admin-truyen-chapter v-if="flag == 2" @changeToList="changeTab(1)" :chapter-arr="chapterArr"></admin-truyen-chapter>
    </div>
</template>

<script>
import AdminTruyenChapter from "./AdminTruyenChapter.vue";
import AdminTruyenList from "./AdminTruyenList.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "admintruyen-layout",
    components: {
    AdminTruyenChapter,
    AdminTruyenList,
},
    data() {
        return {
            flag: 1,
            bookId: null,
            chapterArr: null,
        }
    },
    methods: {
        changeTab(index) {
            this.flag = index
        },
        async changeTabChapter(n) {
            this.flag = 2;
            try {
                let url = `${apiPath}/chapter/get-all?bookId=${n}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, "chapterArr");
                this.chapterArr = res;
                this.$store.dispatch('setBookId', n)
            } catch (e) {
                console.log(e);
            }
        },
        changeToDuyet() {
            this.$emit('changeToDuyet')
        }
    }
};
</script>

<style></style>

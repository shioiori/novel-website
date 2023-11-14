<template>
    <div class="col-md-10">
        <admin-truyen-list v-if="flag == 1" @changeToChapter="changeTabChapter"></admin-truyen-list>
        <admin-truyen-chapter v-if="flag == 2" @changeToList="changeTab(1)"></admin-truyen-chapter>
    </div>
</template>

<script>
import AdminTruyenChapter from "./AdminTruyenChapter.vue";
import AdminTruyenList from "./AdminTruyenList.vue";

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
        }
    },
    methods: {
        changeTab(index) {
            this.flag = index
        },
        changeTabChapter(n) {
            this.flag = 2;
            this.bookId = n;
        }
    }
};
</script>

<style></style>

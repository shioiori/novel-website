<template>
    <div class="index__btv col-md-9">
        <h4>Biên tập viên đề cử</h4>
        <div id="editor-recommend">
            <div class="index__right-wrap--list row">
                <truyenItem
                    v-for="(item, index) in bookArray"
                    :key="index"
                    :Avatar="item.Avatar"
                    :BookName="item.BookName"
                    :Author="item.Author.AuthorName"
                    :TotalChapters="item.TotalChapters"
                    :Views="item.Views"
                    :Category="item.Category.CategoryName"
                    :Introduce="item.Introduce"
                ></truyenItem>
            </div>
        </div>
    </div>
</template>

<script>
import truyenItem from "./truyenItem.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "btv-layout",
    components: {
        truyenItem,
    },
    data() {
        return {
            bookArray: [],
        };
    },
    created() {
        this.fetchBookRecommended();
    },
    methods: {
        async fetchBookRecommended() {
            try {
                let url = `${apiPath}/book/get-top-by-interaction-type?type=4`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, "lay sach btv de cu");
                res.forEach((item, index) => {
                    this.bookArray.push(item)
                    if(index > 5) 
                        return;
                })
                // for (let i = 0; i < 6; i++) {
                //     console.log(res[i])
                //     this.bookArray.push(res[i]);
                // }
                console.log('book array', this.bookArray)
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

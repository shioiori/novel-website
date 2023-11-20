<template>
    <div>
        <Header></Header>
        <div class="container">
            <div class="intro">
                Bạn vừa đọc xong một truyện cực hay muốn giới thiệu cho nhiều
                người cùng đọc, hoặc vừa bỏ một mớ thời gian oan uổng ra đọc một
                truyện cực dở, muốn cảnh báo mọi người đừng nhảy hố.... Mời bạn
                viết cảm nhận, đánh giá, spoil, trích đoạn vào đây để mọi người
                có thêm sự tham khảo khi chọn truyện đọc.
            </div>
            <div id="commentBoard" class="">
                <reviewNav></reviewNav>
                <div id="commentList">
                    <div class="review-group" id="review-@item.ReviewId">
                        <reviewItem v-for="(item, index) in tempReviewArr" :key="index"
                        :avatar="item.User"
                        :userName="item.UserId"
                        :content="item.Content"
                        :likes="item.Likes"
                        :bookName="item.BookId"
                        ></reviewItem>
                    </div>
                </div>
            </div>
            <!-- <div class="rank-box-main-pagination">
                <ul class="pagination justify-content-end">
                    <li class="page-item">
                        <a
                            class="page-link"
                            href="/bo-loc?pageNumber=@Math.Max(1, pageNumber - 1)"
                        >
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>

                    <li class="page-item">
                        <a class="page-link" href="/bo-loc?pageNumber=@i">@i</a>
                    </li>

                    <li class="page-item">
                        <a
                            class="page-link"
                            href="/bo-loc?pageNumber=@Math.Min(pageNumber + 1, pageCount)"
                        >
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </div> -->
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import reviewNav from "./reviewNav.vue";
import reviewItem from "./reviewItem.vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "review-layout",
    components: {
        Header,
        Footer,
        reviewNav,
        reviewItem
    },
    data() {
        return {
            tempReviewArr: []
        }
    },
    created() {
        this.getTempReviewArr()
    },
    computed: {
        reivewArr() {
            return this.$store.getters.getReviewArr
        }
    },
    watch: {
        reivewArr(newArr) {
            this.tempReviewArr = newArr
        }
    },
    methods: {
        async getTempReviewArr() {
            try {
                let url = `${apiPath}/review/get-by-filter`
                let res = (await axios.get(url)).data.Data
                console.log(res, "lay review");
                this.tempReviewArr = res
                res.forEach((item) => {
                    this.tempReviewArr.push(item)
                })
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

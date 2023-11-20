<template>
    <div class="book--rate tab-pane container fade" id="book--rate-id">
        <div class="user--rate">
            <div class="user--comment-discuss-wrap">
                <div class="user--comment-discuss-list">
                    <div class="user--comment-discuss-list-title">
                        Viết đánh giá
                    </div>

                    <ul class="list-group list-group-flush" id="list-review">
                        <li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <div class="col review-col">
                                    <editor
                                        api-key="4as43w7o9gqeqdobwqmya3u4qnfsc0urrlt94qsrefzqo5s7"
                                        :init="{
                                            height: 300,
                                            menubar: false,
                                            plugins: [
                                                'advlist autolink lists link image charmap print preview anchor',
                                                'searchreplace visualblocks code fullscreen',
                                                'insertdatetime media table paste code help wordcount',
                                            ],
                                            toolbar:
                                                'undo redo | formatselect | bold italic backcolor | \
                                                        alignleft aligncenter alignright alignjustify | \
                                                        bullist numlist outdent indent | removeformat | help',
                                        }"
                                        v-model="userReview"
                                    />
                                </div>

                                <div class="submit-btn col-md-12">
                                    <div class="submit-btn-wrap">
                                        <button
                                            type="button"
                                            class="btn btn-primary"
                                            @click="addReview()"
                                        >
                                            Đăng
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li
                            class="list-group-item"
                            v-for="(item, index) in reviewArr"
                            :key="index"
                        >
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img :src="item.User.Avatar" />
                                    </a>
                                </div>
                                <div class="user--discussion col">
                                    <p class="users">
                                        <a href="javascript:void(0)">{{
                                            item.User.Username
                                        }}</a>
                                    </p>
                                    <p class="comments" v-html="item.Content">

                                    </p>
                                    <p class="info--wrap">
                                        <span>{{ item.CreatedDate }}</span>
                                        <a
                                            href="javascript:void(0)"
                                            @click="
                                                setStatusAction(like, item.id)
                                            "
                                        >
                                            <i
                                                class="fa-solid fa-square-caret-up info-icon rate-up"
                                            ></i>
                                            {{ item.like }}
                                        </a>
                                        <a
                                            href="javascript:void(0)"
                                            @click="
                                                setStatusAction(
                                                    dislike,
                                                    item.id
                                                )
                                            "
                                        >
                                            <i
                                                class="fa-solid fa-square-caret-down info-icon rate-down"
                                            ></i>
                                            {{ item.dislike }}
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <!-- <p class="go--discuss">
                        <a href="javascript:void(0)">Thêm đánh giá</a>
                    </p> -->
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import Editor from "@tinymce/tinymce-vue";

export default {
    name: "bookNavRate",
    // props: {
    //     userId: Number,
    //     bookId: String,
    // },
    data() {
        return {
            userReview: "",
            reviewArr: [],
            bookId: this.$route.params.id,
        };
    },
    components: {
        Editor,
    },
    mounted() {
        this.fetchReview();
    },
    methods: {
        async addReview() {
            try {
                let url = `${apiPath}/review/add`;
                let header = {
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("JWT"),
                    },
                };
                let res = (
                    await axios.post(
                        url,
                        {
                            BookId: this.bookId,
                            Content: this.userReview,
                        },
                        header
                    )
                ).data;
                console.log(res)
                alert("review thanh cong");
                window.location.reload()
            } catch (e) {
                console.log(e);
            }
        },
        async fetchReview() {
            try {
                let url = `${apiPath}/review/get-by-book?bookId=${this.bookId}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res);
                this.reviewArr = res;
            } catch (e) {
                console.log(e);
            }
        },
        async setStatusAction(action, id) {
            try {
                let url = `${apiPath}/interact/review/set-status-${action}?reviewId=${id}`;
                let res = (await axios.get(url)).data;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
.container {
    width: 1200px !important;
    margin: 20px auto !important;
    padding: initial !important;
}
#book--rate-id.active {
    border: none;
}
.tox.tox-tinymce {
    margin: 0 !important;
}
.submit-btn {
    width: 100% !important;
    margin: 0 !important;
}
.review-col {
    padding-right: 0;
}
</style>

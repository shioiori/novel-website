<template>
    <div class="book--content tab-pane container active" id="book--content-id">
        <div class="row">
            <div class="col-md-9">
                <div class="book--content-detail">
                    <div
                        class="book--content-detail-intro"
                        v-html="bookContent.Introduce"
                    ></div>
                    <div class="book--content-detail-state">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <b>Người đăng</b>
                                <div class="detail">
                                    <p class="tag-wrap">
                                        <a href="javascript:void(0)">{{
                                            bookContent.User
                                        }}</a>
                                    </p>
                                </div>
                            </li>
                            <li class="list-group-item">
                                <b>Tags</b>
                                <div class="detail">
                                    <p class="tag-wrap" id="book-tag">
                                        <a
                                            href="javascript:void(0)"
                                            v-for="(item, index) in bookContent.Tags"
                                            :key="index"
                                            >{{ item.Tags.TagName }}</a
                                        >
                                    </p>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="quangcao">
                    <a href="javascript:void(0)"
                        ><img :src="imgURL" class="banner-sm"
                    /></a>
                </div>
                <div class="user--comment">
                    <div class="user--comment-discuss-wrap">
                        <div class="user--comment-discuss-list">
                            <div class="user--comment-discuss-list-title">
                                Viết bình luận
                            </div>

                            <ul
                                class="list-group list-group-flush"
                                id="list-comment"
                            >
                                <comment-area></comment-area>
                                <comment></comment>
                            </ul>
                            <!-- <p class="go--discuss">
                                <a href="javascript:void(0)">Thêm bình luận</a>
                            </p> -->
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card author">
                    <div class="card-body">
                        <h4 class="card-title">{{ bookContent.Author.AuthorName }}</h4>
                        <ul class="list-group" id="book-same-author">
                            <li class="list-group-item">
                                <h5>Truyện cùng tác giả</h5>
                            </li>
                            <li
                                class="list-group-item"
                                v-for="(item, index) in bookAuthorArray"
                                :key="index"
                            >
                                <a
                                    @click="changeRoute(item.Slug, item.BookId)"
                                    >{{ item.BookName }}</a
                                >
                            </li>
                        </ul>
                    </div>
                </div>

                <div class="card author">
                    <div class="card-body">
                        <h4 class="card-title">{{ bookUploader }}</h4>
                        <ul class="list-group" id="book-same-user">
                            <li class="list-group-item">
                                <h5>Truyện cùng người đăng</h5>
                            </li>
                            <li
                                class="list-group-item"
                                v-for="(item, index) in bookUploaderArray"
                                :key="index"
                            >
                                <a
                                    @click="changeRoute(item.Slug, item.BookId)"
                                    >{{ item.BookName }}</a
                                >
                            </li>
                        </ul>
                    </div>
                </div>

                <div class="like-more">
                    <h4>Có thể bạn sẽ thích</h4>
                    <div class="like-more-list">
                        <ul
                            class="list-group list-group-flush"
                            id="book-same-like"
                        >
                            <li
                                class="list-group-item"
                                v-for="(item, index) in bookRecommendArray"
                                :key="index"
                            >
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img :src="item.Avatar" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a
                                        @click="
                                            changeRoute(item.Slug, item.BookId)
                                        "
                                        >{{ item.BookName }}</a
                                    >
                                    <p @click="$router.push(`/author/${item.Author.Slug}/${item.Author.AuthorId}`)">{{ item.Author.AuthorName }}</p>
                                    <a
                                        @click="
                                            changeRoute(item.Slug, item.BookId)
                                        "
                                        class="btn index__left-wrap--cardbtn truyen-btn"
                                    >
                                        Đọc truyện
                                        <i
                                            class="fa-solid fa-chevron-right"
                                        ></i>
                                    </a>
                                </h4>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import CommentArea from "../Comment/CommentArea.vue";
import Comment from "../Comment/Comment.vue";

export default {
    name: "bookNavContent",
    props: {
        bookIntroduce: String,
        bookUploader: String,
        bookUploaderId: String,
        bookTag: Array,
        bookId: String,
        bookAuthor: String,
        bookAuthorId: Number,
    },
    data() {
        return {
            imgURL: "",
            useComment: "",
            bookAuthorArray: [],
            bookUploaderArray: [],
            bookRecommendArray: [],
            bookContent: this.$store.state.bookStore,
            commentArr: [],
        };
    },
    components: {
        CommentArea,
        Comment,
    },
    mounted() {
        this.getBannerRandomize();
        this.getBookAuthor();
        this.getBookUploader();
        this.getBookRecommend();
        this.getComment();
    },
    methods: {
        async getBannerRandomize() {
            try {
                let url = `${apiPath}/banner/get-random-advertise-banner`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.imgURL = res.data.bannerImage;
            } catch (e) {
                console.log(e);
            }
        },
        async addComment() {
            try {
                let url = `${apiPath}/comment/add`;
                let res = (
                    await axios.post(url, {
                        UserId: 1,
                        BookId: this.bookId,
                        Content: this.userComment,
                    })
                ).data;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        },
        async getBookAuthor() {
            try {
                let url = `${apiPath}/book/get-by-author-id?authorId=${this.bookContent.Author.AuthorId}`;
                let res = (await axios.get(url)).data.Data;
                console.log(url, "getbookAuthor url");
                console.log(res, "getbookauthor");
                this.bookAuthorArray = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getBookUploader() {
            try {
                let url = `${apiPath}/book/get-by-user?userId=${this.bookContent.UserId}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res);
                this.bookUploaderArray = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getBookRecommend() {
            try {
                let url = `${apiPath}/book/get-top-by-interaction-type?type=8`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, 'rec');
                this.bookRecommendArray = res;
            } catch (e) {
                console.log(e);
            }
        },
        changeRoute(slug, id) {
            if (this.bookContent.BookId == id) {
                window.scrollTo(0, 0);
                return;
            } else {
                this.$router.push(`/book/${slug}/${id}`);
                window.location.reload();
            }
        },
        async getComment() {
            try {
                let url = `${apiPath}/comment/get-comments-book?id=${this.bookContent.BookId}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res, 'comment');
                url = `${apiPath}/user/get-by-id?userId=${res.UserId}`
                // let res2 = (await axios.get(url)).data;
                this.commentArr = res;
            } catch (e) {
                console.log(e);
            }
        }
    },
};
</script>

<style>
.container {
    width: 1200px !important;
    margin: 20px auto !important;
    padding: initial !important;
}
#book--content-id.active {
    border: none;
}
.tox.tox-tinymce {
    margin: 0 !important;
}
.submit-btn {
    width: 100% !important;
    margin: 0 !important;
}
.relate-content p:hover {
    cursor: pointer;
}
</style>

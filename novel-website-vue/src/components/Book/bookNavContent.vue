<template>
    <div class="book--content tab-pane container active" id="book--content-id">
        <div class="row">
            <div class="col-md-9">
                <div class="book--content-detail">
                    <div class="book--content-detail-intro">
                        {{ bookIntroduce }}
                    </div>
                    <div class="book--content-detail-state">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <b>Người đăng</b>
                                <div class="detail">
                                    <p class="tag-wrap">
                                        <a href="javascript:void(0)">{{
                                            bookUploader
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
                                            v-for="(item, index) in bookTag"
                                            :key="index"
                                            >{{ item }}</a
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
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="input-comment col">
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
                                                v-model="userComment"
                                            />
                                        </div>
                                        <div class="submit-btn col-md-12">
                                            <div class="submit-btn-wrap">
                                                <button
                                                    type="button"
                                                    class="btn btn-primary"
                                                    @click="addComment()"
                                                >
                                                    Đăng
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)"
                                                        >kfc group</a
                                                    >
                                                    <span
                                                        >bá tánh bình dân</span
                                                    >
                                                </p>
                                                <p class="comments">
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                </p>
                                                <p class="info--wrap">
                                                    <span>2 hrs</span>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-comment-dots info-icon"
                                                        ></i>
                                                        0 trả lời
                                                    </a>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-thumbs-up info-icon"
                                                        ></i>
                                                        0
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="user--discussion-child">
                                                <ul
                                                    class="list-group list-group-flush"
                                                >
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="user--discussion-main col"
                                                            >
                                                                <div
                                                                    class="user--discussion"
                                                                >
                                                                    <p
                                                                        class="users"
                                                                    >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                            >kfc
                                                                            group</a
                                                                        >
                                                                        <span
                                                                            >bá
                                                                            tánh
                                                                            bình
                                                                            dân</span
                                                                        >
                                                                    </p>
                                                                    <p
                                                                        class="comments"
                                                                    >
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                    </p>
                                                                    <p
                                                                        class="info--wrap"
                                                                    >
                                                                        <span
                                                                            >2
                                                                            hrs</span
                                                                        >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-comment-dots info-icon"
                                                                            ></i>
                                                                            0
                                                                            trả
                                                                            lời
                                                                        </a>
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-thumbs-up info-icon"
                                                                            ></i>
                                                                            0
                                                                        </a>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="input-comment col"
                                                            >
                                                                <textarea></textarea>
                                                            </div>
                                                            <div
                                                                class="submit-btn col-md-12"
                                                            >
                                                                <div
                                                                    class="submit-btn-wrap"
                                                                >
                                                                    <button
                                                                        class="btn btn-primary"
                                                                    >
                                                                        Đăng
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            <!-- <form class="form-horizontal">
                                                                <input type="hidden" name="" value="testing" />
                                                                <button class="btn btn-primary submit-btn" type="submit">Đăng</button>
                                                            </form> -->
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)"
                                                        >kfc group</a
                                                    >
                                                    <span
                                                        >bá tánh bình dân</span
                                                    >
                                                </p>
                                                <p class="comments">
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                </p>
                                                <p class="info--wrap">
                                                    <span>2 hrs</span>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-comment-dots info-icon"
                                                        ></i>
                                                        0 trả lời
                                                    </a>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-thumbs-up info-icon"
                                                        ></i>
                                                        0
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="user--discussion-child">
                                                <ul
                                                    class="list-group list-group-flush"
                                                >
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="user--discussion-main col"
                                                            >
                                                                <div
                                                                    class="user--discussion"
                                                                >
                                                                    <p
                                                                        class="users"
                                                                    >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                            >kfc
                                                                            group</a
                                                                        >
                                                                        <span
                                                                            >bá
                                                                            tánh
                                                                            bình
                                                                            dân</span
                                                                        >
                                                                    </p>
                                                                    <p
                                                                        class="comments"
                                                                    >
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                    </p>
                                                                    <p
                                                                        class="info--wrap"
                                                                    >
                                                                        <span
                                                                            >2
                                                                            hrs</span
                                                                        >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-comment-dots info-icon"
                                                                            ></i>
                                                                            0
                                                                            trả
                                                                            lời
                                                                        </a>
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-thumbs-up info-icon"
                                                                            ></i>
                                                                            0
                                                                        </a>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="input-comment col"
                                                            >
                                                                <textarea></textarea>
                                                            </div>
                                                            <div
                                                                class="submit-btn col-md-12"
                                                            >
                                                                <div
                                                                    class="submit-btn-wrap"
                                                                >
                                                                    <button
                                                                        class="btn btn-primary"
                                                                    >
                                                                        Đăng
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            <!-- <form class="form-horizontal">
                                                                <input type="hidden" name="" value="testing" />
                                                                <button class="btn btn-primary submit-btn" type="submit">Đăng</button>
                                                            </form> -->
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)"
                                                        >kfc group</a
                                                    >
                                                    <span
                                                        >bá tánh bình dân</span
                                                    >
                                                </p>
                                                <p class="comments">
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                </p>
                                                <p class="info--wrap">
                                                    <span>2 hrs</span>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-comment-dots info-icon"
                                                        ></i>
                                                        0 trả lời
                                                    </a>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-thumbs-up info-icon"
                                                        ></i>
                                                        0
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="user--discussion-child">
                                                <ul
                                                    class="list-group list-group-flush"
                                                >
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="user--discussion-main col"
                                                            >
                                                                <div
                                                                    class="user--discussion"
                                                                >
                                                                    <p
                                                                        class="users"
                                                                    >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                            >kfc
                                                                            group</a
                                                                        >
                                                                        <span
                                                                            >bá
                                                                            tánh
                                                                            bình
                                                                            dân</span
                                                                        >
                                                                    </p>
                                                                    <p
                                                                        class="comments"
                                                                    >
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                    </p>
                                                                    <p
                                                                        class="info--wrap"
                                                                    >
                                                                        <span
                                                                            >2
                                                                            hrs</span
                                                                        >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-comment-dots info-icon"
                                                                            ></i>
                                                                            0
                                                                            trả
                                                                            lời
                                                                        </a>
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-thumbs-up info-icon"
                                                                            ></i>
                                                                            0
                                                                        </a>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="input-comment col"
                                                            >
                                                                <textarea></textarea>
                                                            </div>
                                                            <div
                                                                class="submit-btn col-md-12"
                                                            >
                                                                <div
                                                                    class="submit-btn-wrap"
                                                                >
                                                                    <button
                                                                        class="btn btn-primary"
                                                                    >
                                                                        Đăng
                                                                    </button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </li>
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
                        <h4 class="card-title">{{ bookAuthor }}</h4>
                        <ul class="list-group" id="book-same-author">
                            <li class="list-group-item">
                                <h5>Truyện cùng tác giả</h5>
                            </li>
                            <li class="list-group-item" v-for="(item, index) in bookAuthorArray" :key="index">
                                <a href="javascript:void(0)"
                                    >{{ item.bookName }}</a
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
                            <li class="list-group-item" v-for="(item, index) in bookUploaderArray" :key="index">
                                <a href="javascript:void(0)"
                                    >{{ item.bookName }}</a
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
                            <li class="list-group-item" v-for="(item, index) in bookRecommendArray" :key="index">
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img :src="item.avatar" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/html/truyen.html"
                                        >{{ item.bookName }}</a
                                    >
                                    <p>{{ item.author }}</p>
                                    <a
                                        href="/html/truyen.html"
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
import Editor from "@tinymce/tinymce-vue";

export default {
    name: "bookNavContent",
    props: {
        bookIntroduce: String,
        bookUploader: String,
        bookUploaderId: String,
        bookTag: Array,
        bookId: Number,
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
        };
    },
    components: {
        Editor,
    },
    created() {
        this.getBannerRandomize();
        this.getBookAuthor()
        this.getBookUploader()
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
                let url = `${apiPath}/book/get-by-author?authorId=${this.bookAuthorId}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.bookAuthorArray = res
            } catch (e) {
                console.log(e);
            }
        },
        async getBookUploader() {
            try {
                let url = `${apiPath}/book/get-by-author?authorId=${this.bookUploaderId}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.bookUploaderArray = res
            } catch (e) {
                console.log(e);
            }
        },
        async getBookRecommend() {
            try {
                let url = `${apiPath}/book/get-by-interaction-type?type=8`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.bookRecommendArray = res
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
</style>

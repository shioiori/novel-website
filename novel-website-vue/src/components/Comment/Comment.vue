<template>
    <li class="list-group-item">
        <div class="row user--comment-section">
            <div class="user--photo col-md-auto">
                <a href="javascript:void(0)">
                    <img :src="Avatar" />
                </a>
            </div>
            <div class="col user--discussion-main">
                <div class="user--discussion">
                    <p class="users">
                        <a href="javascript:void(0)">{{ userName }}</a>
                        <!-- <span>bá tánh bình dân</span> -->
                    </p>
                    <p class="comments" v-html="content"></p>
                    <p class="info--wrap">
                        <span>{{ createdDate }}</span>
                        <!-- <a @click="toggleComment()" class="toggleComment">
                            <i class="fa-regular fa-comment-dots info-icon"></i>
                            Trả lời
                        </a> -->
                        <a @click="submitLike('like', commentId)">
                            <i class="fa-regular fa-thumbs-up info-icon" :class="{ 'activeflag' : checkFlagLike}"></i>
                            {{ like }}
                        </a>
                        <a @click="submitLike('dislike', commentId)">
                            <i class="fa-regular fa-thumbs-down info-icon" :class="{ 'activeflag' : checkFlagDislike}"></i>
                            {{ dislike }}
                        </a>
                    </p>
                </div>
                <div class="user--discussion-child" v-if="commentFlag">
                    <ul class="list-group list-group-flush">
                        <nested-comment></nested-comment>
                        <nested-comment></nested-comment>
                        <nested-comment></nested-comment>
                        <nested-comment></nested-comment>
                        <comment-area></comment-area>
                    </ul>
                </div>
            </div>
        </div>
    </li>
</template>

<script>
import NestedComment from "../Comment/NestedComment.vue";
import CommentArea from "../Comment/CommentArea.vue";
import axios from "axios";
// import { stringify } from "postcss";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "comment-template",
    components: {
        NestedComment,
        CommentArea,
    },
    data() {
        return {
            commentFlag: false,
            checkFlagLike: false,
            checkFlagDislike: false,
        };
    },
    props: {
        userName: String,
        content: String,
        createdDate: String,
        like: Number,
        dislike: Number,
        commentId: String,
        Avatar: String,
    },
    mounted() {
        this.checkStatusLike();
        this.checkStatusDisLike()
    },
    methods: {
        toggleComment() {
            this.commentFlag = !this.commentFlag;
        },
        async submitLike(interact, commentId) {
            try {
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem("JWT")
                    }
                }
                let url = `${apiPath}/interact/comment/set-status-${interact}?commentId=${commentId}`;
                let res = (await axios.get(url, header)).data;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        },
        async checkStatusLike() {
            try {
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem("JWT")
                    }
                }
                let url = `${apiPath}/interact/comment/is-liked?commentId=${this.commentId}`;
                let res = (await axios.get(url, header)).data;
                console.log(res);
                this.checkFlagLike = res;
            } catch (e) {
                console.log(e);
            }
        },
        async checkStatusDisLike() {
            try {
                let url = `${apiPath}/interact/comment/is-disliked?commentId=${this.commentId}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.checkFlagDislike = res;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
.toggleComment:hover {
    cursor: pointer;
    color: #0d6efd;
}
.activeflag {
    color: #0d6efd !important;
}
</style>

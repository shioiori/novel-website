<template>
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
                        <a href="javascript:void(0)">kfc group</a>
                        <span>bá tánh bình dân</span>
                    </p>
                    <p class="comments">
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                    </p>
                    <p class="info--wrap">
                        <span>2 hrs</span>
                        <a @click="toggleComment()" class="toggleComment">
                            <i class="fa-regular fa-comment-dots info-icon"></i>
                            0 trả lời
                        </a>
                        <a @click="submitLike()">
                            <i class="fa-regular fa-thumbs-up info-icon"></i>
                            0
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
import NestedComment from "../Comment/NestedComment.vue"
import CommentArea from "../Comment/CommentArea.vue"
import axios from "axios";
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
        }
    },
    methods: {
        toggleComment() {
            this.commentFlag = !this.commentFlag
        },
        async submitLike() {
            try {
                let url = `${apiPath}/interaction/comment/set-like`;
                let res = (await axios.get(url)).data;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        }
    },
};
</script>

<style>
.toggleComment:hover {
    cursor: pointer;
    color: #0d6efd;
}
</style>

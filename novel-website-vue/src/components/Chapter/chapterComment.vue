<template>
    <div class="comment-section">
        <div class="user--comment-discuss-wrap">
            <div class="user--comment-discuss-list">
                <div class="user--comment-discuss-list-title">Bình luận</div>
                <ul
                    class="list-group list-group-flush"
                    id="list-comment-chapter"
                >
                        <comment-area></comment-area>
                        <comment></comment>
                </ul>
                <p class="go--discuss">
                    <a href="javascript:void(0)">Thêm bình luận</a>
                </p>
            </div>
        </div>
    </div>
</template>

<script>
// import axios from "axios";
// const apiPath = process.env.VUE_APP_API_KEY;
import CommentArea from "../Comment/CommentArea.vue";
import Comment from "../Comment/Comment.vue";

export default {
    name: "chapterComment",
    components: {
        CommentArea,
        Comment
    },
    data() {
        return {
            userComment: "",
            chapterId: "",
        };
    },
    methods: {
        // async addComment() {
        //     try {
        //         let url = `${apiPath}/comment/add`;
        //         let res = (
        //             await axios.post(url, {
        //                 UserId: 1,
        //                 ChapterId: this.chapterId,
        //                 Content: this.userComment,
        //             })
        //         ).data;
        //         console.log(res);
        //     } catch (e) {
        //         console.log(e);
        //     }
        // },
    },
};
</script>

<style></style>

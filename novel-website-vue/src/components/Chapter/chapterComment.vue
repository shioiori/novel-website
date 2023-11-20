<template>
    <div class="comment-section">
        <div class="user--comment-discuss-wrap">
            <div class="user--comment-discuss-list">
                <div class="user--comment-discuss-list-title">Bình luận</div>
                <ul
                    class="list-group list-group-flush"
                    id="list-comment-chapter"
                >
                    <comment-area :ChapterId="chapterId" @reload="fetchComment()"></comment-area>
                    <comment
                        v-for="(item, index) in commentArr"
                        :key="index"
                        :user-name="item.UserId"
                        :content="item.Content"
                        :created-date="item.CreatedDate"
                        :like="item.Likes"
                        :dislike="item.Dislikes"
                        :comment-id="item.CommentId"
                    ></comment>
                </ul>
                <p class="go--discuss">
                    <a href="javascript:void(0)">Thêm bình luận</a>
                </p>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import CommentArea from "../Comment/CommentArea.vue";
import Comment from "../Comment/Comment.vue";
import { EventBus } from "@/main";

export default {
    name: "chapterComment",
    components: {
        CommentArea,
        Comment,
    },
    data() {
        return {
            userComment: "",
            chapterId: "",
            commentArr: null,
            chapNumb: this.$route.params.number
        };
    },
    mounted() {
        EventBus.$on("changeChap", (value) => {
            console.log('eventbus gọi cho comment')
            if (value == 0) {
                this.chapNumb--;
            } else {
                this.chapNumb++;
            }
            this.fetchChapterByIndex();
        });
    },
    created() {
        this.fetchChapterByIndex();
        this.fetchComment()
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
        async fetchChapterByIndex() {
            try {
                let url = `${apiPath}/chapter/get-by-chapter-index?bookId=${this.$route.params.id}&index=${this.chapNumb}`;
                let res = (await axios.get(url)).data;
                console.log(url, '123');
                this.chapterId = res.ChapterId;
                url = `${apiPath}/comment/get-comments-chapter?id=${this.chapterId}`;
                res = (await axios.get(url)).data.Data;
                this.commentArr = res;
            } catch (e) {
                console.log(e);
            }
        },
        async fetchComment() {
            try {
                let url = `${apiPath}/comment/get-comments-chapter?id=${this.chapterId}`
                let res = (await axios.get(url)).data.Data;
                console.log(res, "comment");
                this.commentArr = res;
            } catch (e) {
                console.log(e);
            }
        }
    },
};
</script>

<style></style>

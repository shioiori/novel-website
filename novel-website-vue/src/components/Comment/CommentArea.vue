<template>
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
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import Editor from "@tinymce/tinymce-vue";

export default {
    name: "comment-wrapper",
    components: {
        Editor,
    },
    data() {
        return {
            userComment: ""
        }
    },
    props: {
        BookId: String,
        ChapterId: String,
        PostId: String,
        ReviewId: String,
    },
    methods: {
        async addComment() {
            try {
                let url = `${apiPath}/comment/add`;
                let header = {
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("JWT"),
                    },
                };
                console.log(localStorage.getItem("JWT"), 'add')
                let res = (
                    await axios.post(
                        url,
                        {
                            BookId: this.BookId,
                            ChapterId: this.ChapterId,
                            PostId: this.PostId,
                            ReviewId: this.ReviewId,
                            Content: this.userComment,
                        },
                        header
                    )
                ).data;
                console.log(res, 'thanhcong');
                this.$emit('reload')
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

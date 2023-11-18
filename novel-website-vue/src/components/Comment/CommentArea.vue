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
    methods: {
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
    },
};
</script>

<style></style>

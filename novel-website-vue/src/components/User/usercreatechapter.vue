<template>
    <div class="">
        <div class="edit--main-body">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="editor--header">Đăng chương</h3>
                    <a @click="$emit('tabChange')" class="btn btn-secondary"
                        >Quay lại</a
                    >
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Chọn truyện:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content">
                        <select v-model="selectedStatus" class="form-select">
                            <option disabled value="">Please select one</option>
                            <option v-for="item in bookArr" :key="item.BookId">
                                {{ item.BookName }}
                            </option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Tên chương:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content input-group">
                        <input
                            type="text"
                            name="ChapterName"
                            class="editbook--name form-control"
                            placeholder="Nhập tên chương..."
                            value=""
                        />
                        <input
                            type="text"
                            name="BookId"
                            value="@ViewBag.BookId"
                            hidden
                        />
                        <input type="text" name="ChapterId" value="" hidden />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Chương số:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content input-group">
                        <input
                            type="text"
                            class="editbook--name form-control"
                            name="ChapterNumber"
                            value=""
                            readonly
                        />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <h4 class="editor--title">Nội dung chương:</h4>
                </div>
                <div class="col-12">
                    <editor
                        api-key="4as43w7o9gqeqdobwqmya3u4qnfsc0urrlt94qsrefzqo5s7"
                        :init="{
                            height: 500,
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
                        v-model="noidung"
                    />
                </div>
            </div>
            <button class="btn btn-primary submit-btn" type="submit">
                Đăng
            </button>
        </div>
    </div>
</template>

<script>
import Editor from "@tinymce/tinymce-vue";
import "../../assets/css/dangtruyen.css";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "usercreatechapter-layout",
    components: {
        Editor,
    },
    data() {
        return {
            bookArr: [],
        };
    },
    created() {
        this.fetchBookArr();
    },
    methods: {
        async fetchBookArr() {
            try {
                let url = `${apiPath}/book/get-by-user?userId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data.Data;
                console.log(res);
                this.bookArr = res;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

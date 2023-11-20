<template>
    <div class="">
        <div class="edit--main-body">
            <div class="row">
                <div class="col-md-12 thaydoi">
                    <a @click="$emit('tabChange')" class="btn btn-secondary"
                            >Quay lại</a
                        >
                    <h3 class="editor--header">Chỉnh sửa chương</h3>
                    
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
                            v-model="tenchuong"
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
            <button class="btn btn-primary submit-btn" @click="updateChapter()">
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
    name: "userfixchapter-layout",
    components: {
        Editor,
    },
    data() {
        return {
            tenchuong: this.receiveData.ChapterName,
            noidung: this.receiveData.Content,
            chapterId: this.receiveData.ChapterId,
            ChapterNumber: this.receiveData.ChapterNumber
        }
    },
    props: {
        receiveData: Object
    },
    created() {
    },
    methods: {
        async updateChapter() {
            try {
                let url = `${apiPath}/chapter/update`;
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
                            ChapterName: this.tenchuong,
                            ChapterId: this.chapterId,
                            Content: this.noidung,
                            ChapterNumber: this.ChapterNumber,
                            Status: 2
                        },
                        header
                    )
                ).data;
                console.log(res, 'thanhcong khong?')
                alert("Đăng thành công! Chờ xét duyệt!")
                window.location.reload()
            } catch (e) {
                console.log(e);
            }
        }
    }
};
</script>

<style></style>

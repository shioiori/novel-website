<template>
    <div class="row-right">
        <div class="edit--main-body">
            <!-- <div class="row">
                <div class="col-md-12">
                    <div class="alert alert-danger" role="alert">@error</div>
                </div>
            </div> -->
            <div class="row">
                <div class="col-md-12">
                    <h3 class="editor--header">Giao diện đăng truyện</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Tên truyện:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content input-group">
                        <input
                            type="text"
                            class="editbook--name form-control"
                            name="BookName"
                            placeholder="Nhập tên truyện..."
                            value=""
                            v-model="tentruyen"
                        />
                        <input type="text" name="BookId" value="" hidden />
                        <input
                            type="text"
                            name="UserId"
                            value="@ViewBag.UserId"
                            hidden
                        />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Tác giả:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content input-group">
                        <input
                            type="text"
                            class="editbook--name form-control"
                            name="AuthorName"
                            placeholder="Nhập tên tác giả..."
                            value=""
                            v-model="tacgia"
                        />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Tình trạng:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content">
                        <!-- <select
                                name="bookstatusid"
                                class="form-select"
                                asp-for="@Model.BookStatusId"
                                asp-items="@ViewBag.BookStatuses"
                                value="@(Model != null ? Model.BookStatusId : 0)"
                            ></select> -->
                        <select v-model="selectedStatus" class="form-select">
                            <option disabled value="">Please select one</option>
                            <option v-for="item in statusArr" :key="item[1]">
                                {{ item[0] }}
                            </option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Ảnh đại diện:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--img-wrap">
                        <div
                            class="editor--img-container"
                            style="margin-bottom: 10px"
                        >
                            <img src="" class="input-img" />
                        </div>
                        <input type="file" name="fileUpload" />
                        <input
                            type="text"
                            name="Avatar"
                            asp-for="@Model.Avatar"
                            value=""
                            hidden
                        />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Thể loại:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content">
                        <select v-model="selectedCategory" class="form-select">
                            <option value="">Please select one</option>
                            <option v-for="item in categoryArr" :key="item.CategoryId" :value="item.CategoryId">
                                {{ item.CategoryName }}
                            </option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4 class="editor--title">Thể loại phụ:</h4>
                </div>
                <div class="col-md-10">
                    <div class="editor--content sub-catagory row">
                        <div
                            class="form-check form-check-inline col-md-2"
                            v-for="item in tagArr"
                            :key="item.TagId"
                        >
                            <label class="form-check-label">
                                <input
                                    class="form-check-input tag-checkbox"
                                    type="checkbox"
                                    v-model="selectedTag"
                                    :value="item.TagId"
                                />
                                {{ item.TagName }}
                            </label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h4 class="editor--title">Nội dung truyện:</h4>
                </div>
                <div class="col-md-12">
                    <!-- <editor
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
                        v-modal="noidung"
                    /> -->
                    <textarea v-model="noidung"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 1rem">
                    <button
                        class="btn btn-primary submit-btn user-profile-submit-btn"
                        type="submit"
                        @click="addBook()"
                    >
                        Đăng
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
// import Editor from "@tinymce/tinymce-vue";
import "../../assets/css/dangtruyen.css";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "user-createbook",
    components: {
        // Editor,
    },
    data() {
        return {
            categoryArr: [],
            tagArr: [],
            statusArr: [
                ["Đang ra", "CONTIEP"],
                ["Hoàn thành", "HOANTHANH"],
                ["Tạm ngưng", "TAMNGUNG"],
            ],
            selectedStatus: "",
            selectedCategory: "",
            selectedTag: [],
            tentruyen: "",
            tacgia: "",
            noidung: "",
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                let url_category = `${apiPath}/category/get-all`;
                let res1 = (await axios.get(url_category)).data;
                console.log(res1)
                this.categoryArr = res1;
                let url_tag = `${apiPath}/tag/get-all`;
                let res2 = (await axios.get(url_tag)).data;
                this.tagArr = res2;
            } catch (e) {
                console.log(e);
            }
        },
        async addBook() {
            let selectedTagObject = []
            this.selectedTag.forEach((tag) => {
                selectedTagObject.push({
                    TagId: tag
                });
            })
            const headers = { 
                Authorization: "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjcyZDAxYTExLTNkYjctNDE3ZS1iYjA2LTgyOGFiOTI0OTMyOSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImp0aSI6IjhkNmQ5ZjUwLTljM2UtNDFiOS04NTM1LTE2NjY1Yzk3ZTlmZiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3MDAxMzA4NTcsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUyMzQ2LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUyMzQ2LyJ9.QPN6-K3e3YygR3rW8GKXxGRTsx0dnVXFQqb2xvcG-7w"
             };
            try {
                let url = `${apiPath}/book/add`;
                let res = (await axios.post(url, {
                    BookName: this.tentruyen,
                    Author: {
                        AuthorName: this.tacgia,
                    },
                    BookStatus: this.selectedStatus,
                    Category: {
                        CategoryId: this.selectedCategory
                    },
                    Tags: selectedTagObject,
                    Introduce: this.noidung
                },{
                    headers: headers,
                })).data;
                console.log(res)
                // console.log(this.selectedTag);
                // console.log(this.selectedCategory, 'cate');
                // console.log(this.selectedStatus, 'status');

            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

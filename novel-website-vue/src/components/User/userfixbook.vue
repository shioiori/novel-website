<template>
    <div class="row-right">
        <div class="edit--main-body">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="editor--header">Sửa truyện</h3>
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
                        <select v-model="selectedStatus" class="form-select">
                            <option disabled value="">Please select one</option>
                            <option v-for="item in statusArr" :key="item[1]" :value="item[1]">
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
                            <img :src="file_uploaded" class="input-img" />
                        </div>
                        <input type="file" name="fileUpload" @change="handleFileChange($event)" />
                        <input
                            type="text"
                            name="Avatar"
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
                            <option
                                v-for="item in categoryArr"
                                :key="item.CategoryId"
                                :value="item.CategoryId"
                            >
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
            <div class="row">
                <div class="col-md-6" style="margin-top: 1rem">
                    <button
                        class="btn btn-primary submit-btn user-profile-submit-btn"
                        type="submit"
                        @click="updateBook()"
                    >
                        Đăng
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Editor from "@tinymce/tinymce-vue";
import "../../assets/css/dangtruyen.css";
import axios from "axios";

const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "user-suatruyen",
    components: {
        Editor,
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
            avatar: "",
            file_uploaded: "",
            upload_file: "",
            bookId: "",
        };
    },
    created() {
        this.fetchData();
    },
    mounted() {
        this.handlerBookFix();
    },
    methods: {
        async fetchData() {
            try {
                let url_category = `${apiPath}/category/get-all`;
                let res1 = (await axios.get(url_category)).data.Data;
                console.log(res1);
                this.categoryArr = res1;
                let url_tag = `${apiPath}/tag/get-all`;
                let res2 = (await axios.get(url_tag)).data.Data;
                this.tagArr = res2;
            } catch (e) {
                console.log(e);
            }
        },
        async updateBook() {
            this.uploadFile()
            let selectedTagObject = [];
            this.selectedTag.forEach((tag) => {
                selectedTagObject.push({
                    "TagId": tag,
                });
            });
            let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem("JWT")
                    }
                }
            try {
                let url = `${apiPath}/book/update`;
                let res = (
                    await axios.post(
                        url,
                        {
                            BookId: this.bookId,
                            BookName: this.tentruyen,
                            CategoryId: this.selectedCategory,
                            Author: {
                                AuthorName: this.tacgia,
                            },
                            BookStatus: this.selectedStatus,
                            Tags: selectedTagObject,
                            Introduce: this.noidung,
                            Avatar: this.file_uploaded,
                            Status: 1
                        },
                        header
                    )
                ).data;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        },
        handlerBookFix() {
            let temp = this.$store.getters.getBookFixItem;
            if (temp == null) {
                return;
            } else {
                console.log(temp, "bookfixitem");
                (this.selectedStatus = temp.BookStatus),
                (this.selectedCategory = temp.Category.CategoryId),
                (this.selectedTag = temp.Tags),
                (this.tentruyen = temp.BookName),
                (this.tacgia = temp.Author.AuthorName),
                (this.noidung = temp.Introduce);
                (this.file_uploaded = temp.Avatar),
                (this.bookId = temp.BookId)
            }
        },
        async uploadFile() {
            if (this.upload_file) {
                const formData = new FormData();
                formData.append("image", this.upload_file);
                await axios
                    .post("https://api.imgur.com/3/image", formData, {
                        headers: {
                            Authorization: `Client-ID ${process.env.IMGUR_CLIENT_ID}`,
                        },
                    })
                    .then((response) => {
                        this.file_uploaded = response.data.data.link;
                        console.log(
                            "Image uploaded. Link:",
                            this.category.CategoryImage
                        );
                    })
                    .catch((error) => {
                        console.error("Error uploading image:", error);
                    });
            } else {
                console.warn("No file selected for upload.");
            }
        },
        handleFileChange(event) {
            this.upload_file = event.target.files[0];
            if(this.upload_file) {
                this.file_uploaded = URL.createObjectURL(this.upload_file);
            } else {
                this.file_uploaded = null;
            }
        },
    },
};
</script>

<style></style>

<template>
    <div class="row-right">
        <form action="/Upload/AddOrUpdateBook" method="post" id="upload-book">
            <div class="edit--main-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="alert alert-danger" role="alert">
                            @error
                        </div>
                    </div>
                </div>
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
                            <select
                                v-model="selectedStatus"
                                class="form-select"
                            >
                                <option disabled value="">
                                    Please select one
                                </option>
                                <option
                                    v-for="item in statusArr"
                                    :key="item[1]"
                                >
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
                            <select
                                v-model="selectedStatus"
                                class="form-select"
                            >
                                <option disabled value="">
                                    Please select one
                                </option>
                                <option
                                    v-for="item in categoryArr"
                                    :key="item.id"
                                >
                                    {{ item.name }}
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
                            <div class="form-check form-check-inline col-md-2">
                                <label
                                    v-for="item in tagArr"
                                    :key="item.id"
                                    class="form-check-label"
                                >
                                    <input
                                        class="form-check-input tag-checkbox"
                                        type="checkbox"
                                        v-model="selectedTag"
                                        :value="item.tagName"
                                    />
                                    {{ item.tagName }}
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
                        />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12" style="margin-top: 1rem">
                        <button
                            class="btn btn-primary submit-btn user-profile-submit-btn"
                            type="submit"
                        >
                            Đăng
                        </button>
                    </div>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
import Editor from "@tinymce/tinymce-vue";
import "../../assets/css/dangtruyen.css";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "user-createbook",
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
        };
    },
    created() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                let url_category = `${apiPath}/category/get-all`;
                let res1 = (await axios.get(url_category)).data;
                console.log(res1);
                this.categoryArr = res1.data;
                let url_tag = `${apiPath}/tag/get-all`;
                let res2 = (await axios.get(url_tag)).data;
                console.log(res2);
                this.tagArr = res2.data;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

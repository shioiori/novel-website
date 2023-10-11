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
                            <select
                                name="bookstatusid"
                                class="form-select"
                                asp-for="@Model.BookStatusId"
                                asp-items="@ViewBag.BookStatuses"
                                value="@(Model != null ? Model.BookStatusId : 0)"
                            ></select>
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
                                name="categoryid"
                                class="form-select"
                                asp-for="@Model.CategoryId"
                                id="specificSizeSelect"
                                asp-items="@ViewBag.Categories"
                                value="@(Model != null ? Model.CategoryId : 0)"
                            ></select>
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
                                <input
                                    class="form-check-input tag-checkbox"
                                    name="tag"
                                    type="checkbox"
                                    value=""
                                />
                                <label class="form-check-label"
                                    >@item.TagName</label
                                >
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
                    <div class="col-md-12">
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

export default {
    name: "user-createbook",
    components: {
        Editor,
    },
};
</script>

<style></style>

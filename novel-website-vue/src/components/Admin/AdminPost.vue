<template>
    <div>
        <AdminHeader></AdminHeader>
        <div class="container-fluid">
            <div class="row">
                <AdminSidebar></AdminSidebar>
                <div class="row col-md-9">
                    <div class="col-md-3">
                        <div class="box box-primary">
                            <div
                                class="box-body box-profile"
                                id="author-info"
                            ></div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <form
                                method="post"
                                action="/Admin/Post/AddOrUpdatePost"
                                id="upload-post"
                            >
                                <div class="box-header with-border">
                                    <h3 class="box-title">Quản lý bài viết</h3>
                                </div>
                                <div class="box-body">
                                    <input
                                        type="text"
                                        name="userid"
                                        value="@Model.UserId"
                                        hidden
                                    />
                                    <input
                                        type="text"
                                        name="postid"
                                        value="@Model.PostId"
                                        hidden
                                    />
                                    <div class="form-group">
                                        <label for="exampleInputFile"
                                            >Title</label
                                        >
                                        <input
                                            class="form-control"
                                            placeholder="Tiêu đề:"
                                            value=""
                                            name="title"
                                            required
                                        />
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputFile"
                                            >Description</label
                                        >
                                        <input
                                            class="form-control"
                                            placeholder="Description:"
                                            value=""
                                            name="description"
                                        />
                                    </div>
                                    <div class="form-group form-content-block">
                                        <label for="exampleInputFile"
                                            >Nội dung</label
                                        >
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
                                <!-- /.box-body -->
                                <div class="box-footer">
                                    <div class="pull-right">
                                        <button
                                            type="submit"
                                            class="btn btn-primary btnsubmit float-end"
                                            name="submit"
                                        >
                                            <i class="fa fa-envelope"></i>Gửi đi
                                        </button>
                                    </div>
                                </div>
                            </form>
                            <!-- /.box-footer -->
                        </div>
                        <!-- /. box -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import AdminHeader from "./AdminHeader.vue";
import Editor from "@tinymce/tinymce-vue";
import AdminSidebar from "./AdminSidebar.vue";

export default {
    name: "adminpost-layout",
    components: {
        AdminHeader,
        Editor,
        AdminSidebar,
    },
};
</script>

<style></style>

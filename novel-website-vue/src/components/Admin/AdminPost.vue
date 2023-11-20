<template>
    <div class="row col-md-10">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Quản lý bài viết</h3>
                </div>
                <div class="box-body">
                    <!-- <div class="form-group">
                        <label for="exampleInputFile">Author</label>
                        <input
                            class="form-control"
                            placeholder="Tác giả:"
                            value=""
                            name="title"
                            required
                            v-model="tacgia"
                        />
                    </div> -->
                    <div class="form-group">
                        <label for="exampleInputFile">Title</label>
                        <input
                            class="form-control"
                            placeholder="Tiêu đề:"
                            value=""
                            name="title"
                            required
                            v-model="tieude"
                        />
                    </div>
                    <div class="form-group">
                        <label for="exampleInputFile">Description</label>
                        <input
                            class="form-control"
                            placeholder="Description:"
                            value=""
                            name="description"
                            v-model="mota"
                        />
                    </div>
                    <div class="form-group form-content-block">
                        <label for="exampleInputFile">Nội dung</label>
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
                <div class="box-footer">
                    <div class="pull-right">
                        <button
                            type="submit"
                            class="btn btn-primary btnsubmit float-end"
                            name="submit"
                            @click="upPost()"
                        >
                            <i class="fa fa-envelope"></i>Gửi đi
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Editor from "@tinymce/tinymce-vue";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "adminpost-layout",
    components: {
        Editor,
    },
    data() {
        return {
            // tacgia: "",
            tieude: "",
            noidung: "",
            mota: "",
        };
    },
    methods: {
        async upPost() {
            try {
                let url = `${apiPath}/post/add`;
                let header = {
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("JWT"),
                    },
                };
                let res = (
                    await axios.post(
                        url,
                        {
                            Title: this.tieude,
                            Description: this.mota,
                            Content: this.noidung,
                            Status: 2
                        },
                        header
                    )
                ).data;
                console.log(res, 'dang thanh cong')
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
.form-group {
    margin-bottom: 1rem;
}
.pull-right i {
    color: inherit;
    margin-right: 0.5rem;
}
</style>

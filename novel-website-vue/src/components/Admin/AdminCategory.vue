<template>
    <div class="row col-md-10">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <h4>Quản lý thể loại</h4>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead class="table-dark fw-semibold">
                                <tr class="align-middle">
                                    <th>STT</th>
                                    <th>Tên thể loại</th>
                                    <th>Số tác phẩm</th>
                                    <th>Đường dẫn</th>
                                    <th>Ảnh đại diện</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="align-middle"
                                v-for="(item, index) in categories"
                                :key="index">
                                    <td>
                                        <div>{{index + 1}}</div>
                                    </td>
                                    <td>
                                        <div>{{item.CategoryName}}</div>
                                    </td>
                                    <td>
                                        <div>{{item.Quantity}}</div>
                                    </td>
                                    <td>
                                        <div>{{item.Slug}}</div>
                                    </td>
                                    <td>
                                        <div class="category-img">
                                            <img :src="item.Avatar" />
                                        </div>
                                    </td>
                                    <td>
                                        <div class="dropstart theloai">
                                            <button
                                                class="btn btn-primary"
                                                type="button"
                                                @click="editCategory(item.CategoryId)"
                                            >
                                                Edit
                                            </button>
                                            <button
                                                class="btn btn-danger"
                                                type="button"
                                                @click="deleteCategory(item.CategoryId)"
                                            >
                                                Delete
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <!-- <div class="col-md-12">
                    <div class="box-footer">
                        <div class="box-footer-clearfix">
                            <ul
                                class="pagination pagination-sm no-margin pull-right"
                            >
                                <li><a href="">&laquo;</a></li>
                                <li><a href=""></a></li>
                                <li><a href="">&raquo;</a></li>
                            </ul>
                            <ul class="pagination justify-content-end">
                                <li class="page-item">
                                    <a class="page-link" href="">
                                        <span aria-hidden="true">&laquo;</span>
                                    </a>
                                </li>

                                <li class="page-item">
                                    <a
                                        class="page-link"
                                        href="/Admin/Category/Index?pageNumber=@i"
                                        >@i</a
                                    >
                                </li>

                                <li class="page-item">
                                    <a
                                        class="page-link"
                                        href="/Admin/Category/Index?pageNumber=@Math.Min(pageNumber + 1, pageCount)"
                                    >
                                        <span aria-hidden="true">&raquo;</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div> -->
            </div>
        </div>
        <div class="col-md-4 config-box">
            <div class="col-md-12">
                <h4>{{ category_state }} thể loại</h4>
            </div>
            <div class="col-12">
                <label for="inputTenTheLoai" class="form-label"
                    >Tên thể loại</label
                >
                <input
                    type="text"
                    name="CategoryName"
                    class="form-control"
                    id="inputTenTheLoai"
                    v-model="category.CategoryName"
                />
            </div>
            <div class="col-12">
                <label class="form-labal">Ảnh đại diện</label>
            </div>
            <div class="col-auto">
                <div class="category-select-picture">
                    <div class="category-img-container">
                        <img :src="category.CategoryImage" class="input-img" />
                    </div>
                </div>
            </div>
            <input type="text" name="CategoryImage" hidden />
            <div class="col-auto">
                <input type="file" name="fileUpload" @change="handleFileChange($event)"/>
            </div>
            <div class="col-12">
                <button type="submit" class="btn btn-primary" @click="saveChange()">
                    Lưu thay đổi
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const env = process.env

export default {
    name: "admintheloai-layout",
    data(){
        return{
            categories: [],
            category_state: "Thêm",
            category: {
                "CategoryId": 0,
                "CategoryName": "",
                "CategoryImage": null,
            },
            file_upload: null,
        }
    },
    created() {
        this.getCategories();
    },
    methods: {
        async getCategories() {
            try {
                let url = `${env.VUE_APP_API_KEY}/category/get-all`;
                let res = (await axios.get(url)).data.Data;
                this.categories = res;
            } catch (e) {
                console.log(e);
            }
        },
        async editCategory(id){
            this.category_state = "Chỉnh sửa";
            try {
                let url = `${env.VUE_APP_API_KEY}/category/get-by-id?id=` + id;
                let res = (await axios.get(url)).data;
                this.category.CategoryId = res.CategoryId;
                this.category.CategoryName = res.CategoryName;
                this.category.CategoryImage = res.CategoryImage;
            } catch (e) {
                console.log(e);
            }
        },
        async deleteCategory(id){
            try {
                if (id == this.category.CategoryId){
                    this.category_state = "Thêm";
                }
                let url = `${env.VUE_APP_API_KEY}/category/delete?id=` + id;
                await axios.delete(url);
                this.getCategories();
            } catch (e) {
                console.log(e);
            }
        },
        async saveChange(){
            await this.uploadFile();
            try {
                let url = `${env.VUE_APP_API_KEY}/category/${this.category.CategoryId == null ? "add" : "update"}`;
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                axios.post(url, this.category, header);
                console.log(header)
                console.log(this.category)
                this.getCategories();
            } catch (e) {
                console.log(e);
            }
        },
        async uploadFile(){
            if (this.file_upload) {
                const formData = new FormData();
                formData.append('image', this.file_upload);
                await axios.post('https://api.imgur.com/3/image', formData, {
                    headers: {
                        Authorization: `Client-ID ${env.IMGUR_CLIENT_ID}`,
                    },
                })
                .then(response => {
                    this.category.CategoryImage =  response.data.data.link;
                    console.log('Image uploaded. Link:', this.category.CategoryImage);
                })
                .catch(error => {
                    console.error('Error uploading image:', error);
                });
            } 
            else 
            {
                console.warn('No file selected for upload.');
            }
        },
        handleFileChange(event) {
            this.file_upload = event.target.files[0];
        },
    }
};
</script>

<style>
.config-box > .col-12,
.config-box > .col-auto {
    margin-bottom: 1rem;
}
.dropstart.theloai {
    display: flex;
    justify-content: space-evenly;
}
</style>

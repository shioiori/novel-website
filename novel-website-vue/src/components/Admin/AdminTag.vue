<template>
    <div class="col-md-10">

        <div class="col-md-12 config-box" style="margin-bottom: 1rem">
            <div class="col-md-12">
                <h4>Thêm thẻ</h4>
            </div>
            
            <div class="col-md-6">
                <label for="inputTenTheLoai" class="form-label">Tên thẻ</label>
                <div class="row col-md-12">
                    <div class="col-md-9">
                        <input type="text" name="TagName" class="form-control" id="inputTenTheLoai" v-model="tag.TagName" />
                    </div>
                    <button type="submit" class="btn btn-primary col-md-3" @click="saveChange()">
                        Lưu thay đổi
                    </button>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <h4>Quản lý tag</h4>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead class="table-dark fw-semibold">
                                <tr class="align-middle">
                                    <th>STT</th>
                                    <th>Tên thẻ</th>
                                    <th>Đường dẫn</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="list-tags">
                                <tr class="align-middle" v-for="(item, index) in tags" :key="index">
                                    <td>
                                        <div>{{ index + 1 }}</div>
                                    </td>
                                    <td>
                                        <div>{{ item.TagName }}</div>
                                    </td>
                                    <td>
                                        <div>{{ item.Slug }}</div>
                                    </td>
                                    <td>
                                        <div class="dropstart">
                                            <button class="btn btn-danger" type="button" @click="deleteTag(item.TagName)">
                                                Delete
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="box-footer">
                        <div class="box-footer-clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const env = process.env;

export default {
    name: "admintag-layout",
    data() {
        return {
            tags: [],
            tag: {
                "TagId": 0,
                "TagName": "",
            },
        }
    },
    created() {
        this.getTags();
    },
    methods: {
        async getTags() {
            try {
                let url = `${env.VUE_APP_API_KEY}/tag/get-all?PageSize=20`;
                let res = (await axios.get(url)).data.Data;
                this.tags = res;
                console.log(this.tags)
            } catch (e) {
                console.log(e);
            }
        },
        // async editTag(id){
        //     this.tag_state = "Chỉnh sửa";
        //     try {
        //         let url = `${env.VUE_APP_API_KEY}/tag/get-by-id?id=` + id;
        //         let res = (await axios.get(url)).data;
        //         this.tag.TagId = res.TagId;
        //         this.tag.TagName = res.TagName;
        //         console.log(res)
        //     } catch (e) {
        //         console.log(e);
        //     }
        // },
        async deleteTag(tag) {
            try {
                let header = {
                    headers: {
                        Authorization: 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                let url = `${env.VUE_APP_API_KEY}/tag/delete?tag=` + tag;
                await axios.delete(url, header);
                this.getTags();
            } catch (e) {
                console.log(e);
            }
        },
        async saveChange() {
            try {
                let url = `${env.VUE_APP_API_KEY}/tag/${this.tag.tagId == null ? "add" : "update"}`;
                let header = {
                    headers: {
                        Authorization: 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                axios.post(url, this.tag, header);
                this.getTags();
            } catch (e) {
                console.log(e);
            }
        },
    }
};
</script>

<style>
.config-box>.col-12 {
    margin-bottom: 1rem;
}
</style>

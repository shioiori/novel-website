<template>
    <div class="row col-md-10">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <h4>Quản lý vai trò</h4>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead class="table-dark fw-semibold">
                                <tr class="align-middle">
                                    <th>STT</th>
                                    <th>Tên vai trò</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="align-middle" 
                                v-for="(item, index) in roles"
                                :key="index">
                                    <td>
                                        <div>{{ index + 1 }}</div>
                                    </td>
                                    <td>
                                        <div>{{ item.RoleName }}</div>
                                    </td>
                                    <td>
                                        <div class="dropstart">
                                            <button
                                                class="btn btn-danger"
                                                type="button"
                                                @click="deleteRole(item.RoleName)"
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
            </div>
        </div>
        <div class="col-md-4 config-box">
                <div class="col-md-12">
                    <h4>Thêm vai trò</h4>
                </div>
                <div class="col-12">
                    <label for="inputTenTheLoai" class="form-label"
                        >Tên vai trò</label
                    >
                    <input
                        type="text"
                        class="form-control"
                        id="inputTenTheLoai"
                        v-model="role.RoleName"
                    />
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
const env = process.env;

export default {
    name: "adminuser-layout",
    data(){
        return{
            roles: [],
            role: {
                "RoleId": null,
                "RoleName": "",
            },
        }
    },
    created() {
        this.getRoles();
    },
    methods: {
        async getRoles() {
            try {
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                let url = `${env.VUE_APP_API_KEY}/role/get-all`;
                let res = (await axios.get(url, header)).data;
                this.roles = res;
            } catch (e) {
                console.log(e);
            }
        },
        async deleteRole(name){
            try {
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                let url = `${env.VUE_APP_API_KEY}/role/delete?role=` + name;
                await axios.delete(url, header);
                this.getRoles();
            } catch (e) {
                console.log(e);
            }
        },
        async saveChange(){
            try {
                let url = `${env.VUE_APP_API_KEY}/role/add`;
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                axios.post(url, this.role, header);
                this.getRoles();
            } catch (e) {
                console.log(e);
            }
        },
    }
};
</script>

<style>
.config-box > .col-12 {
    margin-bottom: 1rem;
}
</style>

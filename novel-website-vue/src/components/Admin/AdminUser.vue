<template>
    <div class="col-md-10">
        <div class="row">
            <div class="col-md-12">
                <h4>Tìm kiếm người dùng</h4>
                <div class="search input-group float-md-start w-50 search-admin">
                    <input
                        type="text"
                        class="form-control shadow-none"
                        name="name"
                        placeholder="Nhập username hoặc email"
                        v-model="search"
                    />
                    <button
                        class="btn btn-success btn--search-color"
                        type="submit"
                        title="searchButton"
                        @click="searchUser()"
                    >
                        <i
                            class="fa-solid fa-magnifying-glass search__btn--icons"
                        ></i>
                    </button>
                </div>
            </div>
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12 title-flex">
                        <h4>Danh sách người dùng</h4>
                        <div class="btn-group">
                            <button
                                type="button"
                                class="btn btn-secondary dropdown-toggle"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                Lọc theo vai trò
                            </button>
                            <ul class="dropdown-menu">
                                <li>
                                    <a
                                        class="dropdown-item"
                                        @click="getUsers()"
                                        >All</a
                                    >
                                </li>
                                <div v-for="(item, index) in roles"
                                :key="index">
                                    <li>
                                        <a
                                            class="dropdown-item"
                                            @click="filterRole(item.RoleName)"
                                            >{{ item.RoleName }}</a
                                        >
                                    </li>
                                </div>
                            </ul>
                        </div>
                        <div class="btn-group">
                            <button
                                type="button"
                                class="btn btn-secondary dropdown-toggle"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                Lọc theo trạng thái
                            </button>
                            <ul class="dropdown-menu">
                                <li>
                                    <a
                                        class="dropdown-item"
                                        @click="getUsers()"
                                        >All</a
                                    >
                                </li>
                                <div v-for="(item, index) in account_status"
                                :key="index">
                                    <li>
                                        <a
                                            class="alert-danger dropdown-item"
                                            @click="filterStatus(item.id)"
                                            >{{ item.name }}</a
                                        >
                                    </li>
                                </div>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="table-responsive">
                    <table class="table border mb-0 table-striped">
                        <thead class="table-dark fw-semibold">
                            <tr class="align-middle">
                                <th>STT</th>
                                <th>Name</th>
                                <th>Username</th>
                                <th>Email</th>
                                <th>Status</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="align-middle"
                            v-for="(item, index) in users"
                            :key="index">
                                <td>
                                    <div>{{ index + 1 }}</div>
                                </td>
                                <td>
                                    <div>{{ item.Name }}</div>
                                </td>
                                <td>
                                    <div>{{ item.Username }}</div>
                                </td>
                                <td>
                                    <div>{{ item.Email }}</div>
                                </td>
                                <td>
                                    <span :class="'badge bg-' + item.StatusLabelColor">{{ item.StatusName }}</span>
                                </td>
                                <td>
                                    <div class="dropstart">
                                        <button
                                            class="btn btn-primary"
                                            type="button"
                                            id="dropdownMenuButton1"
                                            data-bs-toggle="dropdown"
                                            aria-expanded="false"
                                        >
                                            Thay đổi
                                        </button>
                                        <ul
                                            class="dropdown-menu"
                                            aria-labelledby="dropdownMenuButton1"
                                        >
                                            <li>
                                                <a
                                                    class="dropdown-item"
                                                    data-bs-toggle="modal"
                                                    data-bs-target="#roleModal"
                                                    @click="getUserRoles(item.Username)"
                                                    >Modify role</a
                                                >
                                            </li>
                                            <li>
                                                <a
                                                    class="dropdown-item"
                                                    href="#"
                                                    >Change user status</a
                                                >
                                            </li>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div
            class="modal fade"
            id="roleModal"
            tabindex="-1"
            aria-labelledby="exampleModalLabel"
            aria-hidden="true"
        >
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">
                            Chỉnh sửa Role
                        </h5>
                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal"
                            aria-label="Close"
                        ></button>
                    </div>
                    <div class="modal-body">
                        <div class="table-responsive">
                            <table class="table border mb-0 table-striped">
                                <thead class="table-dark fw-semibold">
                                    <tr class="align-middle">
                                        <th>STT</th>
                                        <th>Role</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="align-middle"
                                    v-for="(item, index) in user_roles"
                                    :key="index">
                                        <td>
                                            <div>{{ index + 1 }}</div>
                                        </td>
                                        <td>
                                            <div>{{ item.RoleName }}</div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <label class="form-label" for="specificSizeSelect"
                            >Role</label
                        >
                        <select v-model="selected_role" class="form-select">
                            <option
                                v-for="item in roles"
                                :key="item.RoleName"
                                :value="item.RoleName"
                            >
                                {{ item.RoleName }}
                            </option>
                        </select>
                    </div>
                    <div class="modal-footer">
                        <button
                            type="button"
                            class="btn btn-secondary"
                            data-bs-dismiss="modal"
                        >
                            Close
                        </button>
                        <button
                            type="submit"
                            class="btn btn-primary"
                            data-bs-dismiss="modal"
                            @click="setRole()"
                        >
                            Add
                        </button>
                        
                        <button
                            type="submit"
                            class="btn btn-danger"
                            data-bs-dismiss="modal"
                            @click="removeRole()"
                        >
                            Remove
                        </button>
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
    name: "adminuser-layout",
    data() {
        return {
            search: "",
            users: [],
            user_roles: [],
            roles: [],
            username: "",
            selected_role: "Please select a role",
            account_status: [
                {
                    id: 0,
                    name: "Verifying"
                },
                {
                    id: 1,
                    name: "Active"
                },
                {
                    id: 2,
                    name: "Banned"
                }
            ]
        }
    },
    created(){
        this.getUsers();
        this.getRoles();
    },
    methods: {
        async getUsers(){
            try {
                let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
                let url = `${env.VUE_APP_API_KEY}/user/get-all`;
                let res = (await axios.get(url, header)).data.Data;
                this.users = res;
                console.log(this.users)
            } catch (e) {
                console.log(e);
            }
        },
        async searchUser(){
            let header = {
                    headers: {
                        Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                    }
                }
            try {
                let url = `${env.VUE_APP_API_KEY}/user/search?name=${this.search}`;
                let res = (await axios.get(url, header)).data.Data;
                this.users = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getRoles(){
            let header = {
                headers: {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
            }
            try {
                let url = `${env.VUE_APP_API_KEY}/role/get-all`;
                let res = (await axios.get(url, header)).data;
                this.roles = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getUserRoles(username){
            this.username = username;
            let header = {
                headers: {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
            }
            try {
                let url = `${env.VUE_APP_API_KEY}/role/get-one-role?username=${username}`;
                let res = (await axios.get(url, header)).data;
                this.user_roles = res;
            } catch (e) {
                console.log(e);
            }
        },
        async setRole(){
            if (this.username == "" && this.selected_role == "Please select a role") return;
            let header = {
                headers: {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
            }
            try {
                let url = `${env.VUE_APP_API_KEY}/user/set-role?username=${this.username}&role=${this.selected_role}`;
                let res = (await axios.put(url, {}, header)).data;
                this.roles = res;
            } catch (e) {
                console.log(e);
            }
        },
        async removeRole(){
            if (this.username == "" && this.selected_role == "Please select a role") return;
            let header = {
                headers: {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
            }
            try {
                let url = `${env.VUE_APP_API_KEY}/user/remove-role?username=${this.username}&role=${this.selected_role}`;
                let res = (await axios.delete(url, header)).data;
                this.roles = res;
            } catch (e) {
                console.log(e);
            }
        },
        async filterRole(role){
            let header = {
                headers: {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
            }
            try {
                let url = `${env.VUE_APP_API_KEY}/user/get-by-role?role=${role}`;
                let res = (await axios.get(url, header)).data.Data;
                this.users = res;
            } catch (e) {
                console.log(e);
            }
        },
        async filterStatus(status){
            let header = {
                headers: {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
            }
            try {
                let url = `${env.VUE_APP_API_KEY}/user/get-by-status?status=${status}`;
                let res = (await axios.get(url, header)).data.Data;
                this.users = res;
            } catch (e) {
                console.log(e);
            }
        }
    }
};
</script>

<style>
.title-flex {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1rem;
}
</style>

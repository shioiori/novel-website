<template>
    <div class="modal fade" id="dangnhap">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Đăng nhập</h4>
                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal"
                    ></button>
                </div>
                <div class="needs-validation" id="login-form">
                    <div class="modal-body" id="modal-body-login">
                        <div class="form-floating mb-3 mt-3">
                            <input
                                type="text"
                                class="form-control"
                                name="AccountName"
                                placeholder="Tên đăng nhập"
                                required
                                v-model="username"
                            />
                            <label
                                ><i class="fa-solid fa-user modal--icon"></i>Tên
                                đăng nhập</label
                            >
                        </div>
                        <div class="form-floating mt-3 mb-3">
                            <input
                                type="password"
                                class="form-control"
                                name="Password"
                                placeholder="Mật khẩu"
                                required
                                v-model="password"
                            />
                            <label
                                ><i class="fa-solid fa-key modal--icon"></i>Mật
                                khẩu</label
                            >
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button
                            type="button"
                            class="btn btn-success"
                            @click="onLogin()"
                            data-modal-hide="dangnhap"
                        >
                            Đăng nhập
                        </button>
                        <button
                            type="button"
                            class="btn btn-warning"
                            data-bs-toggle="modal"
                            data-bs-target="#dangky"
                        >
                            Đăng ký
                        </button>
                        <button
                            type="button"
                            class="btn btn-danger"
                            data-bs-dismiss="modal"
                        >
                            Đóng
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
// import { bootstrap } from "bootstrap/dist/js/bootstrap.bundle.min.js";

export default {
    name: "login-modal",
    data() {
        return {
            username: "",
            password: "",
            // modalShow: true,
        };
    },
    methods: {
        async onLogin() {
            const headers = { "Content-Type": "application/json" };
            try {
                let url = `${apiPath}/login`;
                let res = await axios.post(
                    url,
                    {
                        Username: this.username,
                        Password: this.password,
                        LoginProvider: "Cookies",
                    },
                    {
                        headers: headers,
                    }
                );
                let userId = JSON.parse(res.data.context).UserId;
                console.log(JSON.parse(res.data.context), "res login");
                console.log(userId);
                if (res.data.success) {
                    let data = "tokenbimat";
                    if (data) {
                        this.$store.dispatch("setToken", { data, userId });
                        // this.$router.push("/")
                        
                    } else {
                        alert("Đăng nhập thất bại");
                    }
                    // let myModalEl = new bootstrap.Modal(document.getElementById('dangnhap'));
                    //     myModalEl.hide();
                    // this.modalShow = false
                } else {
                    console.log(res.message, "loi o login");
                }
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

<template>
    <div class="modal fade" id="dangky">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Đăng ký</h4>
                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal"
                    ></button>
                </div>
                <form class="needs-validation" id="signup-form">
                    <div class="modal-body" id="modal-body-signup">
                        <div class="form-floating mb-3 mt-3">
                            <input
                                type="text"
                                class="form-control"
                                id="tendangnhap2"
                                placeholder="Tên đăng nhập"
                                name="AccountName"
                                required
                                v-model="username"
                            />
                            <label for="tdn"
                                ><i class="fa-solid fa-user modal--icon"></i>Tên
                                đăng nhập</label
                            >
                        </div>
                        <div class="form-floating mb-3 mt-3">
                            <input
                                type="email"
                                class="form-control"
                                id="email2"
                                placeholder="Email"
                                name="Email"
                                required
                                v-model="email"
                            />
                            <label for="eml"
                                ><i class="fa-solid fa-envelope modal--icon"></i
                                >Email</label
                            >
                        </div>
                        <div class="form-floating mt-3 mb-3">
                            <input
                                type="password"
                                class="form-control"
                                id="matkhau2"
                                placeholder="Mật khẩu"
                                name="Password"
                                required
                                v-model="password"
                            />
                            <label for="mk"
                                ><i class="fa-solid fa-key modal--icon"></i>Mật
                                khẩu</label
                            >
                        </div>

                        <div class="form-floating mt-3 mb-3">
                            <input
                                type="password"
                                class="form-control"
                                id="nlmatkhau2"
                                placeholder="Nhập lại mật khẩu"
                                name="PasswordAgain"
                                required
                                v-model="re_password"
                            />
                            <label for="rmk"
                                ><i class="fa-solid fa-key modal--icon"></i>Nhập
                                lại mật khẩu</label
                            >
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button
                            type="button"
                            class="btn btn-success"
                            :click="onRegister()"
                        >
                            Đăng ký
                        </button>
                        <button
                            type="button"
                            class="btn btn-warning"
                            data-bs-toggle="modal"
                            data-bs-target="#dangnhap"
                        >
                            Đăng nhập
                        </button>
                        <button
                            type="button"
                            class="btn btn-danger"
                            data-bs-dismiss="modal"
                        >
                            Đóng
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "register-modal",
    data() {
        return {
            username: "",
            password: "",
            email: "",
            re_password: "",
        }
    },
    methods: {
        async onRegister() {
            try {
                const url = `${apiPath}/register`
                if(this.password == this.re_password && (this.password != null || this.password != "")) {
                    let res = (await axios.post(url, {
                        Username: this.username,
                        Password: this.password,
                        Email: this.email
                    })).data;
                    console.log(res)
                }

            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

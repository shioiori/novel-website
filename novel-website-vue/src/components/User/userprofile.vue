<template>
    <div class="row-right col-md-9">
        <div id="profile-upper">
            <div id="profile-banner-image">
                <div id="profile-d">
                    <img
                        class="rounded-circle"
                        :src="userAvatar"
                        id="change-avatar"
                    />
                    <div id="u-name">{{ name }}</div>
                    <div class="tb" id="m-btns">
                        <div class="m-btn" id="change-cover-photo">
                            <i class="fas fa-cog"></i>
                        </div>
                        <input type="file" name="fileUpload" hidden />
                    </div>
                </div>
            </div>
        </div>

        <div class="container-1" v-if="userFlag">
            <div class="container-sub">
                <!-- <input
                    name="userid"
                    type="text"
                    :value="userId"
                    readonly
                    hidden
                /><br /> -->
                <label for="name">Tên người dùng:</label>
                <input
                    id="name"
                    name="username"
                    type="text"
                    v-model="userName"
                /><br />
            </div>

            <div class="container-sub">
                <label for="email">Email:</label>
                <input
                    type="email"
                    name="email"
                    id="email"
                    placeholder="Nhập email"
                    v-model="userEmail"
                />
            </div>

            <div class="container-sub">
                <label for="email">Mật khẩu:</label>
                <input
                    type="password"
                    name="password"
                    id="password"
                    placeholder="Nhập mật khẩu"
                    v-model="userPassword"
                />
            </div>

            <button
                class="btn btn-primary submit-btn user-profile-submit-btn"
                type="submit"
                @click="updateUser()"
            >
                Lưu
            </button>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "user-profile",
    props: {
        // userName: String,
        // userId: Number,
        // userAvatar: String,
        // userEmail: String,
        // userCoverPhoto: String,
        userFlag: Boolean,
    },
    data() {
        return {
            userName: "",
            userId: null,
            userAvatar: "",
            userEmail: "",
            userCoverPhoto: "",
            userPassword: "",
            // userFlag: false,
            name: "",
        };
    },
    mounted() {
        this.fetchUser()
    },
    methods: {
        async updateUser() {
            try {
                let url = `${apiPath}/user/update`;
                let header = {
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("JWT"),
                    },
                }
                let res = (
                    await axios.post(url, {
                        UserId: this.userId,
                        Username: this.userName,
                        Password: this.userPassword,
                        Email: this.userEmail,
                    }, header)
                ).data;
                console.log(res, 'da thay doi ne');
                alert("thành công")
            } catch (e) {
                console.log(e);
            }
        },
        async fetchUser() {
            try {
                let url = `${apiPath}/user/get-by-id?userId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(res, 'day là fetch user');
                this.name = res.Name;
                this.userName = res.Username;
                this.userAvatar = res.Avatar;
                this.userCoverPhoto = res.CoverPhoto;
                this.userEmail = res.Email;
                this.userId = res.UserId;
                this.userPassword = res.Password;
                console.log(this.userFlag)
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style></style>

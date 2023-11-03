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
                    <div id="u-name">{{ userName }} (ID: {{ userId }})</div>
                    <div class="tb" id="m-btns">
                        <div class="m-btn" id="change-cover-photo">
                            <i class="fas fa-cog"></i>
                        </div>
                        <input type="file" name="fileUpload" hidden />
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <input
                name="userid"
                type="text"
                :value="userId"
                readonly
                hidden
            /><br />
            <label for="name">Tên người dùng:</label>
            <input
                id="name"
                name="username"
                type="text"
                v-model="userNameToChange"
            /><br />

            <label for="email">Email</label>
            <input
                type="email"
                name="email"
                id="email"
                placeholder="Nhập email"
                v-model="userEmailToChange"
            />
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
        userName: String,
        userId: Number,
        userAvatar: String,
        userEmail: String,
    },
    data() {
        return {
            userNameToChange: this.userName,
            userEmailToChange: this.userEmail,
            userIdToChange: this.userId,
        };
    },
    methods: {
        async updateUser() {
            try {
                let url = `${apiPath}/user/update`
                let res = (await axios.post(url, {
                    UserId: this.userId,
                    Username: this.userNameToChange,
                    Email: this.userEmailToChange,
                })).data
                console.log(res);
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style></style>

<template>
  <div class="row-right col-md-9">
        <div id="profile-upper">
            <div id="profile-banner-image">
                <div id="profile-d">
                    <img class="rounded-circle"
                         src="" id="change-avatar"/>
                    <div id="u-name">@Model.UserName (ID: @Model.UserId)</div>
                    <div class="tb" id="m-btns">
                        <div class="m-btn" id="change-cover-photo"><i class="fas fa-cog"></i></div>
                        <input type="file" name="fileUpload" hidden/>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <form action="/User/UpdateProfile" method="post">
                <input name="userid" type="text" value="@Model.UserId" readonly hidden/><br />
                <label for="name">Tên người dùng:</label>
                <input id="name" name="username" type="text" value="@Model.UserName" /><br />

                <label for="email">Email</label>
                <input type="email"
                       name="email"
                       id="email"
                       placeholder="Nhập email"
                       value="@Model.Email" />
                <button class="btn btn-primary submit-btn user-profile-submit-btn" type="submit">Lưu</button>
            </form>
        </div>
    </div>
</template>

<script>
export default {
    name: "user-profile",
}
</script>

<style>

</style>
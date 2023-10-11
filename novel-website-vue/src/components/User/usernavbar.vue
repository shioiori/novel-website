<template>
    <div class="row-left col-md-3">
        <ul class="row-lef-top">
            <li class="col-left" id="hoso">
                <a href="/ho-so/@Model.UserId"
                    ><i class="fa fa-user"></i>Hồ sơ</a
                >
            </li>

            <li class="col-left" id="tutruyen">
                <a href="/ho-so/@Model.UserId/tu-truyen">
                    <i class="fa fa-book"></i>Tủ truyện
                </a>
            </li>

            <li class="col-left" id="truyendang">
                <a href="/ho-so/@Model.UserId/truyen-da-dang"
                    ><i class="fa fa-bell"></i>Truyện đã đăng</a
                >
            </li>
            <li class="col-left">
                <a href="/dang-tai/@Model.UserId/truyen">
                    <i class="fa-solid fa-briefcase"></i>
                    Đăng truyện
                </a>
            </li>
        </ul>
        <ul class="row-lef-bottom">
            <li id="dangtruyen" class="col-left">
                <a href="/dang-tai/@Model.UserId/truyen">
                    <i class="fa-sharp fa-light fa-book-circle-arrow-up"></i>
                    Đăng truyện
                </a>
            </li>
            <li class="col-left">
                <a href="/ho-so/@Model.UserId/truyen-da-dang">
                    <i class="fa-solid fa-briefcase"></i>
                    Quản lí truyện
                </a>
            </li>
            <li class="col-left">
                <a href="/ho-so/@Model.UserId/bao-mat"
                    ><i class="fa-solid fa-shield-halved"></i>Bảo mật</a
                >
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "user-navbar"
};
</script>

<style></style>

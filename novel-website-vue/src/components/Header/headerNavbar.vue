<template>
    <div class="navbar__main">
        <ul class="nav navbar-nav">
            <li class="nav-item--trangchu">
                <a href="/">
                    <i class="fa-solid fa-list"></i>
                    Trang chủ
                </a>
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/bang-xep-hang"
                    >Bảng xếp hạng</a
                >
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/bo-loc">Bộ lọc</a>
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/review">Reviews</a>
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/tin-tuc">Tin tức</a>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "header-navbar",
};
</script>

<style></style>

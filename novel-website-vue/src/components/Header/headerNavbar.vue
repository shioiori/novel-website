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
                <a class="nav-link navlist--item" href="/billboard">Bảng xếp hạng</a>
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/filter">Bộ lọc</a>
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/review">Reviews</a>
            </li>
            <li class="nav-item navlist">
                <a class="nav-link navlist--item" href="/list-post">Tin tức</a>
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

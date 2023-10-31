<template>
    <nav
        id="sidebarMenu"
        class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse"
    >
        <div class="position-sticky pt-3">
            <ul class="nav flex-column">
                <li class="nav-item">
                    <a class="nav-link" aria-current="page" href="#">
                        <span data-feather="home"></span>
                        Dashboard
                    </a>
                </li>
                Quản lý
                <li class="nav-item">
                    <button
                        class="btn btn-toggle align-items-center rounded"
                        data-bs-toggle="collapse"
                        data-bs-target="#home-collapse"
                        aria-expanded="true"
                    >
                        Tin tức
                    </button>
                    <div class="collapse show" id="home-collapse" style="">
                        <ul
                            class="btn-toggle-nav list-unstyled fw-normal pb-1 small"
                        >
                            <li>
                                <a href="#" class="link-dark rounded"
                                    >Tất cả bài viết</a
                                >
                            </li>
                            <li>
                                <a href="#" class="link-dark rounded"
                                    >Viết bài mới</a
                                >
                            </li>
                        </ul>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">
                        <span data-feather="shopping-cart"></span>
                        Banner
                    </a>
                </li>
                <li class="nav-item">
                    <button
                        class="btn btn-toggle align-items-center rounded"
                        data-bs-toggle="collapse"
                        data-bs-target="#truyen-collapse"
                        aria-expanded="true"
                    >
                        Truyện
                    </button>
                    <div class="collapse show" id="truyen-collapse" style="">
                        <ul
                            class="btn-toggle-nav list-unstyled fw-normal pb-1 small"
                        >
                            <li>
                                <a href="#" class="link-dark rounded"
                                    >Tất cả truyện</a
                                >
                            </li>
                            <li>
                                <a href="#" class="link-dark rounded"
                                    >Thể loại</a
                                >
                            </li>
                            <li>
                                <a href="#" class="link-dark rounded">Thẻ</a>
                            </li>
                        </ul>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">
                        <span data-feather="bar-chart-2"></span>
                        Người dùng
                    </a>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
export default {
    name: "adminsidebar-layout"
};
</script>

<style></style>

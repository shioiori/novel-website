<template>
    <div>
        <AdminHeader></AdminHeader>
        <div class="container-fluid">
            <div class="row">
                <div
                    class="col-md-2 d-md-block bg-light sidebar collapse pt-3"
                >
                    <ul class="list-unstyled ps-0">
                        <li class="mb-1">
                            <button
                                class="btn btn-toggle align-items-center rounded collapsed"
                                data-bs-toggle="collapse"
                                data-bs-target="#home-collapse"
                                aria-expanded="false"
                                @click="changeTab(1)"
                            >
                                Home
                            </button>
                        </li>
                        <li class="border-top my-3"></li>
                        <li class="mb-1">
                            <button
                                class="btn btn-toggle align-items-center rounded collapsed"
                                data-bs-toggle="collapse"
                                data-bs-target="#quanly-collapse"
                                aria-expanded="false"
                            >
                                Quản lý
                            </button>
                            <div
                                class="collapse ps-4"
                                id="quanly-collapse"
                                style=""
                            >
                                <ul
                                    class="btn-toggle-nav list-unstyled fw-normal pb-1 small"
                                >
                                    <li>
                                        <button
                                            class="btn align-items-center rounded collapsed"
                                            data-bs-toggle="collapse"
                                            data-bs-target="#quanly-tintuc-collapse"
                                            aria-expanded="false"
                                        >
                                            Tin tức
                                        </button>
                                        <div
                                            class="collapse ps-3"
                                            id="quanly-tintuc-collapse"
                                            style=""
                                        >
                                            <ul
                                                class="btn-toggle-nav list-unstyled fw-normal pb-1 small"
                                            >
                                                <li>
                                                    <button
                                                        @click="changeTab(2)"
                                                        class="btn align-items-center rounded"
                                                    >
                                                        Tất cả bài viết
                                                    </button>
                                                </li>
                                                <li>
                                                    <button
                                                        @click="changeTab(3)"
                                                        class="btn align-items-center rounded"
                                                    >
                                                        Tạo bài viết mới
                                                    </button>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <li>
                                        <button
                                            @click="changeTab(4)"
                                            class="btn align-items-center rounded"
                                        >
                                            Banner
                                        </button>
                                    </li>
                                    <li>
                                        <button
                                            @click="changeTab(8)"
                                            class="btn align-items-center rounded"
                                        >
                                            Vai trò
                                        </button>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li class="border-top my-3"></li>
                        <li class="mb-1">
                            <button
                                class="btn btn-toggle align-items-center rounded collapsed"
                                data-bs-toggle="collapse"
                                data-bs-target="#truyen-collapse"
                                aria-expanded="false"
                            >
                                Truyện
                            </button>
                            <div
                                class="collapse ps-4"
                                id="truyen-collapse"
                                style=""
                            >
                                <ul
                                    class="btn-toggle-nav list-unstyled fw-normal pb-1 small"
                                >
                                    <li>
                                        <button
                                            class="btn align-items-center rounded collapsed"
                                            data-bs-toggle="collapse"
                                            data-bs-target="#truyen-truyen-collapse"
                                            aria-expanded="false"
                                        >
                                            Quản lý truyện
                                        </button>
                                        <div
                                            class="collapse ps-3"
                                            id="truyen-truyen-collapse"
                                            style=""
                                        >
                                            <ul
                                                class="btn-toggle-nav list-unstyled fw-normal pb-1 small"
                                            >
                                                <li>
                                                    <button
                                                        @click="changeTab(5)"
                                                        class="btn align-items-center rounded"
                                                    >
                                                        Tất cả truyện
                                                    </button>
                                                </li>
                                                <li>
                                                    <button
                                                        class="btn align-items-center rounded"
                                                    >
                                                        Tạo truyện mới
                                                    </button>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <li>
                                        <button
                                            @click="changeTab(6)"
                                            class="btn align-items-center rounded"
                                        >
                                            Thể loại
                                        </button>
                                    </li>
                                    <li>
                                        <button
                                            @click="changeTab(7)"
                                            class="btn align-items-center rounded"
                                        >
                                            Thẻ
                                        </button>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li class="border-top my-3"></li>
                        <li class="mb-1">
                            <button
                                class="btn btn-toggle align-items-center rounded collapsed"
                                data-bs-toggle="collapse"
                                data-bs-target="#account-collapse"
                                aria-expanded="false"
                                @click="changeTab(9)"
                            >
                                Người dùng
                            </button>
                        </li>
                    </ul>
                </div>
                <admin-dashboard v-if="flag == 1"></admin-dashboard>
                <admin-banner v-if="flag == 4"></admin-banner>
                <admin-category v-if="flag == 6"></admin-category>
                <admin-post v-if="flag == 3"></admin-post>
                <admin-post-list v-if="flag == 2"></admin-post-list>
                <admin-tag v-if="flag == 7"></admin-tag>
                <admin-truyen v-if="flag == 5"></admin-truyen>
                <admin-role v-if="flag == 8"></admin-role>
                <admin-user v-if="flag == 9"></admin-user>
            </div>
        </div>
    </div>
</template>

<script>
import AdminHeader from "./AdminHeader.vue";
import AdminBanner from "./AdminBanner.vue";
import AdminCategory from "./AdminCategory.vue";
import AdminPost from "./AdminPost.vue";
import AdminPostList from "./AdminPostList.vue";
import AdminTag from "./AdminTag.vue";
import AdminTruyen from "./AdminTruyen.vue";
import AdminRole from "./AdminRole.vue";
import AdminUser from "./AdminUser.vue";
import AdminDashboard from "./AdminDashboard.vue";

export default {
    name: "adminhome-layout",
    components: {
        AdminHeader,
        AdminBanner,
        AdminCategory,
        AdminPost,
        AdminPostList,
        AdminTag,
        AdminTruyen,
        AdminRole,
        AdminUser,
        AdminDashboard,
    },
    data() {
        return {
            flag: 1,
        };
    },
    methods: {
        changeTab(index) {
            this.flag = index;
        },
    },
};
</script>

<style>
.btn-toggle[aria-expanded="true"]::before {
    transform: rotate(90deg);
}
.btn-toggle::before {
    width: 1.25em;
    line-height: 0;
    content: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'%3e%3cpath fill='none' stroke='rgba%280,0,0,.5%29' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M5 14l6-6-6-6'/%3e%3c/svg%3e");
    transition: transform 0.35s ease;
    transform-origin: 0.5em 50%;
}
.row.col-md-10, .col-md-10 {
    padding: 1rem;
    margin: 0;
}
</style>

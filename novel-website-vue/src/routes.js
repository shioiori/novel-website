import Vue from "vue";
import VueRouter from "vue-router";
import Home from "./components/Home/Home.vue";
import Book from "./components/Book/Book.vue";
import Filter from "./components/Filter/Filter.vue";
import Chapter from "./components/Chapter/Chapter.vue";
import Error from "./components/Error/Error.vue";
import Billboard from "./components/Billboard/Billboard.vue";
import Author from "./components/Author/Author.vue";
import ListOfPost from "./components/Post/ListOfPost.vue";
import Review from "./components/Review/Review.vue";
import User from "./components/User/User.vue";

import AdminHome from "./components/Admin/AdminHome.vue";
import AdminTruyen from "./components/Admin/AdminTruyen.vue";
import AdminTheLoai from "./components/Admin/AdminTheLoai.vue";
import AdminTag from "./components/Admin/AdminTag.vue";
import AdminBanner from "./components/Admin/AdminBanner.vue";
import AdminPostList from "./components/Admin/AdminPostList.vue";
import AdminPost from "./components/Admin/AdminPost.vue";
import AdminRole from "./components/Admin/AdminRole.vue";

Vue.use(VueRouter);

const router = new VueRouter({
    mode: "history",
    routes: [
        {
            path: "/",
            component: Home,
            name: "home",
        },
        {
            path: "/book",
            component: Book,
            name: "book",
        },
        {
            path: "/filter",
            component: Filter,
            name: "filter",
        },
        {
            path: "/chapter",
            component: Chapter,
            name: "chapter",
        },
        {
            path: "/error",
            component: Error,
            name: "error",
        },
        {
            path: "/billboard",
            component: Billboard,
            name: "billboard",
        },
        {
            path: "/author",
            component: Author,
            name: "author",
        },
        {
            path: "/list-post",
            component: ListOfPost,
            name: "list-post",
        },
        {
            path: "/review",
            component: Review,
            name: "review",
        },
        {
            path: "/user",
            component: User,
            name: "user",
        },
        {
            path: "/dashboard",
            component: AdminHome,
            name: 'adminhome'
        },
        {
            path: "/admin/listbook",
            component: AdminTruyen,
            name: 'admintruyen'
        },
        {
            path: "/admin/theloai",
            component: AdminTheLoai,
            name: 'admintheloai'
        },
        {
            path: "/admin/tag",
            component: AdminTag,
            name: 'admintag'
        },
        {
            path: "/admin/banner",
            component: AdminBanner,
            name: 'adminbanner'
        },
        {
            path: "/admin/listpost",
            component: AdminPostList,
            name: 'adminpostlist'
        },
        {
            path: "/admin/post",
            component: AdminPost,
            name: 'adminPost'
        },
        {
            path: "/admin/role",
            component: AdminRole,
            name: 'adminRole'
        }
    ],
});

// router.replace("billboard")

export default router;

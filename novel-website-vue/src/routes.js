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
import AdminCategory from "./components/Admin/AdminCategory.vue";
import AdminTag from "./components/Admin/AdminTag.vue";
import AdminBanner from "./components/Admin/AdminBanner.vue";
import AdminPostList from "./components/Admin/AdminPostList.vue";
import AdminPost from "./components/Admin/AdminPost.vue";
import AdminRole from "./components/Admin/AdminRole.vue";
import Adminlogin from "./components/Admin/AdminLogin.vue";
import AdminTruyenChapter from "./components/Admin/AdminTruyenChapter.vue";

// import store from "./store/store";
// import axios from "axios";

Vue.use(VueRouter);

// // const apiPath = process.env.VUE_APP_API_KEY;

// const requireAuth = async (to, from, next) => {
//     const token = store.state.token; // Access the token from the store
//     console.log(token, 'token o route')
//     // const headers = {'Authorization': `Bearer ${token}`}
//     if (token) {
//       // Send the token to the server for validation
//     //   try {
//     //     let res = await axios.post(`${apiPath}/login`, {
//     //         headers: headers
//     //       });
//     //       if (res.status === 200) {
//     //         next();
//     //       } else {
//     //         console.log('error')
//     //       }
//     //   } catch (e) {
//     //     console.log(e, 'loi o route')
//     //   }
//     next()
//   }
// }

// const requireAuth = async (to, from, next) => {
//     const token = store.state.token; // Access the token from the store
//     console.log(token, 'token o route')
//     const headers = {'Authorization': `Bearer ${token}`}
//     if (token) {
//         try {
//             let res = await axios.get(`${apiPath}/role/get-role`, {
//                 headers: headers
//             });
//             if (res.status === 200) {
//                 next();
//             } else {
//                 console.log('error')
//             }
//         } catch (e) {
//             console.log(e, 'loi o route')
//         }
//     next()
//   }
// }

const router = new VueRouter({
    mode: "history",
    routes: [
        {
            path: "/",
            component: Home,
            name: "home",
        },
        {
            path: "/book/:slug/:id",
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
            path: "/author/:slug-:id",
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
            path: "/user/:slug-:id?auth=true",
            component: User,
            name: "user-auth",
            // beforeEnter: requireAuth
        },
        {
            path: "/user/:slug-:id",
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
            path: "/admin/category",
            component: AdminCategory,
            name: 'admincategory'
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
        },
        {
            path: "/admin/login",
            component: Adminlogin,
            name: 'adminLogin'
        },
        {
            path: "/admin/listchapter",
            component: AdminTruyenChapter,
            name: 'admintruyenlist'
        },
    ],
});

// router.replace("billboard")

export default router;

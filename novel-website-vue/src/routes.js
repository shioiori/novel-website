import Vue from "vue";
import VueRouter from "vue-router";
import Home from './components/Home/Home.vue'
import Book from './components/Book/Book.vue'
import Filter from './components/Filter/Filter.vue'
import Chapter from './components/Chapter/Chapter.vue'
import Error from './components/Error/Error.vue'
import Billboard from './components/Billboard/Billboard.vue'
import Author from './components/Author/Author.vue'
import ListOfPost from './components/Post/ListOfPost.vue'
import Review from './components/Review/Review.vue'

Vue.use(VueRouter)

const router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: '/',
            component: Home,
            name: 'home'
        },
        {
            path: '/book',
            component: Book,
            name: 'book'
        },
        {
            path: '/filter',
            component: Filter,
            name: 'filter'
        },
        {
            path: '/chapter',
            component: Chapter,
            name: 'chapter'
        },
        {
            path: '/error',
            component: Error,
            name: 'error'
        },
        {
            path: '/billboard',
            component: Billboard,
            name: 'billboard'
        },
        {
            path: '/author',
            component: Author,
            name: 'author'
        },
        {
            path: '/list-post',
            component: ListOfPost,
            name: 'list-post'
        },
        {
            path: '/review',
            component: Review,
            name: 'review'
        }
    ]
});

export default router;
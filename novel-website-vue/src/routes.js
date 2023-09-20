import Vue from "vue";
import VueRouter from "vue-router";
import Home from './components/Home/Home.vue'
import Book from './components/Book/Book.vue'
import Filter from './components/Filter/Filter.vue'

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
        }
    ]
});

export default router;
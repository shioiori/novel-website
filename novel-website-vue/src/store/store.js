import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        postArr: [],
        bookArr: [],
        reviewArr: [],
        token: localStorage.getItem('token') || null,
    },
    getters: {
        getPostArr(state) {
            return state.postArr;
        },
        getBookArr(state) {
            return state.bookArr;
        },
        getReviewArr(state) {
            return state.reviewArr;
        }
    },
    mutations: {
        SET_POST_ARR(state, postArr) {
            state.postArr = postArr;
        },
        SET_BOOK_ARR(state, bookArr) {
            state.bookArr = bookArr;
        },
        SET_REVIEW_ARR(state, reviewArr) {
            state.reviewArr = reviewArr;
        },
        SET_TOKEN(state, token) {
            state.token = token;
            localStorage.setItem('token', token);
        },
        CLEAR_TOKEN(state) {
            state.token = null;
            localStorage.removeItem('token');
        }
    },
    actions: {
        setPostArr(context, postArr) {
            context.commit('SET_POST_ARR', postArr);
        },
        setBookArr(context, bookArr) {
            context.commit('SET_BOOK_ARR', bookArr);
        },
        setReviewArr(context, reviewArr) {
            context.commit('SET_REVIEW_ARR', reviewArr);
        },
        setToken(context, token) {
            context.commit('SET_TOKEN', token);
        },
        clearToken(context) {
            context.commit('CLEAR_TOKEN')
        }
    },
})
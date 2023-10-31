import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        postArr: [],
        bookArr: [],
        reviewArr: [],
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
        }
    },
})
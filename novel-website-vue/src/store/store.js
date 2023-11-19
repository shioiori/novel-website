import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        postArr: [],
        bookArr: [],
        reviewArr: [],
        // token: localStorage.getItem("token") || null,
        // userId: localStorage.getItem("userId") || null,
        authenFlag: false,
        bookStore: null,
        chapStore: null,
        bookFixItem: null,
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
        },
        getBookStore(state) {
            return state.bookStore;
        },
        getChapStore(state) {
            return state.chapStore;
        },
        getAuthenFlag(state) {
            return state.authenFlag;
        },
        getBookFixItem(state) {
            return state.bookFixItem;
        },
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
        SET_BOOK_STORE(state, bookStore) {
            state.bookStore = bookStore
        },
        SET_CHAP_STORE(state, chapStore) {
            state.bookStore = chapStore
        },
        SET_AUTHEN_FLAG(state, authenFlag) {
            state.authenFlag = authenFlag
        },
        SET_BOOK_FIX_ITEM(state, bookFixItem) {
            state.bookFixItem = bookFixItem
        },
    },
    actions: {
        setPostArr(context, postArr) {
            context.commit("SET_POST_ARR", postArr);
        },
        setBookArr(context, bookArr) {
            context.commit("SET_BOOK_ARR", bookArr);
        },
        setReviewArr(context, reviewArr) {
            context.commit("SET_REVIEW_ARR", reviewArr);
        },
        setToken(context, payload) {
            context.commit("SET_TOKEN",  payload);
        },
        clearToken(context) {
            context.commit("CLEAR_TOKEN");
        },
        setBookStore(context, bookStore) {
            context.commit("SET_BOOK_STORE", bookStore)
        },
        setChapStore(context, chapStore) {
            context.commit("SET_CHAP_STORE", chapStore)
        },
        setAuthenFlag(context, authenFlag) {
            context.commit("SET_AUTHEN_FLAG", authenFlag)
        },
        setBookFixItem(context, bookFixItem) {
            context.commit("SET_BOOK_FIX_ITEM", bookFixItem)
        },
    },
});

<template>
    <div class="book--information">
        <div class="row">
            <div class="col-md-2">
                <div class="book--img">
                    <a href="javascript:void(0)">
                        <img :src="bookContent.Avatar" />
                    </a>
                </div>
            </div>
            <div class="col-md-10">
                <div class="book--info">
                    <h1>{{ bookContent.BookName }}</h1>
                    <p class="book--info-tag">
                        <a @click="$router.push(`/author/${bookContent.Author.Slug}/${bookContent.Author.AuthorId}`)"
                            >{{ bookContent.Author.AuthorName }}</a
                        >
                        <a href="javascript:void(0)"
                            >{{ bookContent.BookStatus }}</a
                        >
                        <a href="javascript:void(0)"
                            >{{ bookContent.Category.CategoryName }}</a
                        >
                    </p>
                    <p class="interaction-data">
                        <i class="dash">|</i>
                        <span class="like">{{ bookContent.Likes }}</span>
                        <i class="no-italic">Yêu thích</i>
                        <i class="dash">|</i>

                        <span class="view">{{ bookContent.Views }}</span>
                        <i class="no-italic">Lượt xem</i>
                        <i class="dash">|</i>

                        <span class="nominate">{{ bookContent.Recommends }}</span>
                        <i class="no-italic">Đề cử</i>
                        <i class="dash">|</i>

                        <span class="nominate">{{ bookContent.TotalChapters }}</span>
                        <i class="no-italic">Chương</i>
                        <i class="dash">|</i>
                    </p>
                    <div class="book--info-buttons book-info-page">
                        <a
                            class="btn"
                            @click="$router.push(`/book/${bookContent.Slug}/${bookContent.BookId}/chap-1`)"
                            >Đọc truyện</a
                        >
                        <a
                            class="btn"
                            id="btn-fav"
                            href="javascript:void(0)"
                            @click="getAction('like')"
                            >Yêu thích</a
                        >
                        <a
                            class="btn"
                            id="btn-follow"
                            href="javascript:void(0)"
                            @click="getAction('follow')"
                            >Theo dõi</a
                        >
                        <a
                            class="btn"
                            id="btn-rec"
                            href="javascript:void(0)"
                            @click="getAction('recommend')"
                            >Đề cử</a
                        >
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "bookInfo-layout",
    props: {
        bookCover: String,
        bookName: String,
        bookAuthor: String,
        bookAuthorId: Number,
        bookAuthorSlug: String,
        bookStatus: String,
        bookCategory: String,
        likes: Number,
        views: Number,
        recommend: Number,
        totalChapters: Number,
        bookSlug: String,
        bookId: String,
    },
    data() {
        return {
            bookContent: this.$store.state.bookStore,
            chapStart: null,
        }
    },
    mounted() {
        this.getChapStart();
    },
    methods: {
        async getAction(action) {
            try {
                let url = `${apiPath}/interact/book/set-status-${action}?bookId=${this.$route.params.id}`
                let res = (await axios.get(url)).data
                console.log(res);
            } catch (e) {
                console.log(e)
            }
        },
        async getChapStart() {
            try {
                let url = `${apiPath}/chapter/get-all?bookId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(res, 'res info')
                this.chapStart = res.ChapterId;
            } catch (e) {
                console.log(e);
            }
        }
    }
};
</script>

<style>
.book--info-buttons.book-info-page {
    width: initial;
}
.book--info a {
    font-size: initial !important;
    font-weight: initial !important;
}
.book--img img {
    object-fit: contain;
    width: 100%;
    height: 100%;
}
.interaction-data span {
    margin-right: .5rem;
}
.dash {
    margin: 0 .5rem;
}
.book--info-tag a:first-child:hover {
    color: #df1c1c !important;
    cursor: pointer;
}
</style>

<template>
    <div class="book--information">
        <div class="row">
            <div class="col-md-2">
                <div class="book--img">
                    <a href="javascript:void(0)">
                        <img :src="bookCover" />
                    </a>
                </div>
            </div>
            <div class="col-md-10">
                <div class="book--info">
                    <h1>{{ bookName }}</h1>
                    <p class="book--info-tag">
                        <a href="/tac-gia/@Model.AuthorId/@Model.Author.Slug"
                            >{{ bookAuthor }}</a
                        >
                        <a href="javascript:void(0)"
                            >{{ bookStatus }}</a
                        >
                        <a href="javascript:void(0)"
                            >{{ bookCategory }}</a
                        >
                    </p>
                    <p>
                        <span class="like">{{ likes }}</span>
                        <i class="no-italic">Yêu thích</i>
                        <i>|</i>

                        <span class="view">{{ views }}</span>
                        <i class="no-italic">Lượt xem</i>
                        <i>|</i>

                        <span class="nominate">{{ recommend }}</span>
                        <i class="no-italic">Đề cử</i>
                    </p>
                    <div class="book--info-buttons">
                        <a
                            class="btn"
                            href="/truyen/@Model.Slug-@Model.BookId/@firstChapterUrl"
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
        bookStatus: String,
        bookCategory: String,
        likes: Number,
        views: Number,
        recommend: Number,
    },
    methods: {
        async getAction(action) {
            try {
                let url = `${apiPath}/interact/book/set-status-${action}?bookId=${this.$route.params.bookId}`
                let res = (await axios.get(url)).data
                console.log(res);
            } catch (e) {
                console.log(e)
            }
        }
    }
};
</script>

<style>
.book--info-buttons {
    width: initial;
}
.book--info a {
    font-size: initial !important;
    font-weight: initial !important;
}
</style>

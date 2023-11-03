<template>
    <div>
        <Header></Header>
        <div class="rank-box box-center row">
            <div class="rank-box-main-header">
                <h4>Tác giả - {{ authorName }}</h4>
            </div>
            <div class="rank-box-main col-12">
                <div class="rank-box-main-body">
                    <div class="rank-view-list">
                        <div class="rank-view-list-item">
                            <ul class="list-group">
                                <li
                                    class="list-group-item"
                                    v-for="book in bookArray"
                                    :key="book.id"
                                >
                                    <div class="book--img">
                                        <a
                                            href="/truyen/@book.Slug-@book.BookId"
                                        >
                                            <img
                                                :src="book.avatar"
                                                class="book--imgcss"
                                            />
                                        </a>
                                    </div>
                                    <div class="book--info">
                                        <h3>
                                            <a
                                                href="/truyen/@book.Slug-@book.BookId"
                                                >{{ book.bookName }}</a
                                            >
                                        </h3>
                                        <div class="book-state">
                                            <a
                                                href="/tac-gia/@book.AuthorId/@book.Author.Slug"
                                                >{{ book.authorName }}</a
                                            >
                                            <i>|</i>
                                            <p>
                                                {{ book.bookStatus }}
                                            </p>
                                            <i>|</i>
                                            <p>
                                                {{ book.numberOfChapter }}
                                                chương
                                            </p>
                                        </div>
                                        <div class="describe">
                                            {{ book.describe }}
                                        </div>
                                    </div>
                                    <div class="book--info-buttons">
                                        <p>
                                            <a
                                                class="btn"
                                                href="/truyen/@book.Slug-@book.BookId"
                                                >Đọc truyện</a
                                            >
                                        </p>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import "../../assets/css/boloc.css";
// import "../../assets/css/author.css";
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "author-layout",
    components: {
        Header,
        Footer,
    },
    data() {
        return {
            authorName: "",
            bookArray: [],
        };
    },
    methods: {
        async getBookArray() {
            try {
                let url = `${apiPath}/book/get-by-author?authorId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.bookArray = res.data;
            } catch (e) {
                console.log(e);
            }
        },
    },
};
</script>

<style>
.rank-box-main {
    width: 100%;
}
.rank-box-main-header,
.rank-box-main-body {
    margin-bottom: 15px;
}

.rank-box-main-header h4 {
    font-size: 2rem;
}

.book--info {
    width: 100% !important;
}

.rank-view-list-item div.describe {
    margin-top: 5px;
    display: -webkit-box;
    -webkit-box-orient: vertical;
    -webkit-line-clamp: 3;
    overflow: hidden;
}

.rank-view-list-item li {
    padding: 10px;
    border: 1px solid;
    border-left: none;
    border-right: none;
    border-radius: 0 !important;
}

.book--info-buttons {
    width: 260px;
    display: flex;
}

.book--info-buttons p {
    position: relative;
    display: flex;
    justify-content: flex-end;
    width: 100%;
    margin: auto 0;
}

.book--info-buttons p > a:first-child {
    margin: 0;
}
</style>

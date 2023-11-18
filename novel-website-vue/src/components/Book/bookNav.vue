<template>
    <div>
        <div class="content--nav">
            <div class="content--nav-wrap">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <button
                            class="nav-link active"
                            id="book--content-tab"
                            data-bs-toggle="tab"
                            data-bs-target="#book--content-id"
                            type="button"
                            role="tab"
                            aria-controls="book--content-id"
                            aria-selected="true"
                        >
                            Thông tin chi tiết
                        </button>
                    </li>
                    <li class="nav-item">
                        <button
                            class="nav-link"
                            id="book--chapter-tab"
                            data-bs-toggle="tab"
                            data-bs-target="#book--chapter-id"
                            type="button"
                            role="tab"
                            aria-controls="book--chapter-id"
                            aria-selected="true"
                        >
                            Danh sách chương
                        </button>
                    </li>
                    <li class="nav-item">
                        <button
                            class="nav-link"
                            id="book--rate-tab"
                            data-bs-toggle="tab"
                            data-bs-target="#book--rate-id"
                            type="button"
                            role="tab"
                            aria-controls="book--rate-id"
                            aria-selected="true"
                        >
                            Đánh giá
                        </button>
                    </li>
                </ul>
            </div>
        </div>
        <div class="tab-content">
            <bookNavContent
                
            ></bookNavContent>
            <bookNavChapter></bookNavChapter>
            <bookNavRate></bookNavRate>
        </div>
    </div>
</template>

<script>
import bookNavContent from "./bookNavContent.vue";
import bookNavChapter from "./bookNavChapter.vue";
import bookNavRate from "./bookNavRate.vue";

export default {
    name: "bookNav-layout",
    components: {
        bookNavChapter,
        bookNavContent,
        bookNavRate,
    },
    computed: {
        bookUserNav() {
            return this.bookUser;
        },
        bookUserIdNav() {
            return this.bookUserId;
        },
        bookIntroduceNav() {
            return this.bookIntroduce;
        },
        bookIdNav() {
            return this.bookId;
        },
        bookAuthorNav() {
            return this.bookAuthor;
        },
        bookAuthorIdNav() {
            return this.bookAuthorId;
        },
        bookSlugNav() {
            return this.bookSlug;
        },
    },
    props: {
        bookUser: String,
        bookUserId: String,
        bookIntroduce: String,
        bookId: String,
        bookAuthor: String,
        bookAuthorId: Number,
        bookSlug: String,
    },
};
</script>

<style></style>

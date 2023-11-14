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
                :book-introduce="bookIntroduce"
                :book-uploader="bookUser"
                :book-uploader-id="bookUserId"
                :book-id="bookId"
                :book-author="bookAuthor"
                :book-author-id="bookAuthorId"
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
    props: {
        bookUser: String,
        bookUserId: Number,
        bookIntroduce: String,
        bookId: Number,
        bookAuthor: String,
        bookAuthorId: Number,
    },
};
</script>

<style></style>

<template>
    <div class="row">
        <div class="col-md-12 flex-title">
            <h4>Danh sách chương</h4>
            <button
                type="button"
                class="btn btn-secondary"
                @click="$emit('changeToList')"
            >
                Back
            </button>
        </div>
        <div class="col-md-12">
            <div class="table-responsive">
                <table class="table border mb-0 table-striped">
                    <thead class="table-dark fw-semibold">
                        <tr class="align-middle">
                            <th>Số chương</th>
                            <th>Tên chương</th>
                            <th>Lượt xem</th>
                            <th>Yêu thích</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr
                            class="align-middle"
                            v-for="(item, index) in chapterArr"
                            :key="index"
                        >
                            <td>
                                <div>{{ item.ChapterNumber }}</div>
                            </td>
                            <td>
                                <div>{{ item.ChapterName }}</div>
                            </td>
                            <td>
                                <div>{{ item.Views }}</div>
                            </td>
                            <td>
                                <div>{{ item.Likes }}</div>
                            </td>
                            <td>
                                <div class="dropstart">
                                    <button
                                        class="btn btn-primary"
                                        type="button"
                                        id="dropdownMenuButton1"
                                        data-bs-toggle="dropdown"
                                        aria-expanded="false"
                                    >
                                        Thêm
                                    </button>
                                    <ul
                                        class="dropdown-menu"
                                        aria-labelledby="dropdownMenuButton1"
                                    >
                                        <li>
                                            <a class="dropdown-item" @click="directToChap(item.BookId, item.ChapterNumber)"
                                                >Thông tin chương</a
                                            >
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#"
                                                >Duyệt</a
                                            >
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#"
                                                >Xóa</a
                                            >
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
export default {
    name: "admintruyenchapter-layout",
    props: {
        chapterArr: Array,
    },
    methods: {
        async directToChap(bookid, chapternumber) {
            try {
                let url = `${apiPath}/book/get-by-book-id?bookId=${bookid}`;
                let res = (await axios.get(url)).data;
                this.$router.push(`/book/${res.Slug}/${res.BookId}/chap-${chapternumber}`)
            } catch (e) {
                console.log(e);
            }
        }
    }
};
</script>

<style>
.flex-title {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1rem;
}
</style>

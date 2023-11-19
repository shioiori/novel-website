<template>
    <div class="row col-md-10">
        <div class="col-md-12">
            <h4>Truyện chưa duyệt</h4>
        </div>
        <div class="col-md-12">
            <h4>Danh sách truyện</h4>
        </div>
        <div class="col-md-12">
            <div class="table-responsive">
                <table class="table border mb-0 table-striped">
                    <thead class="table-dark fw-semibold">
                        <tr class="align-middle">
                            <th>STT</th>
                            <th>Tên truyện</th>
                            <th>Tác giả</th>
                            <th>Thể loại</th>
                            <th>Số chương</th>
                            <th>Tình trạng</th>
                            <th>Thời gian đăng</th>
                            <th>Cập nhật gần nhất</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle"
                        v-for="(item, index) in books"
                        :key="index">
                            <td>
                                <div>{{index + 1}}</div>
                            </td>
                            <td>
                                <div>{{item.BookName}}</div>
                            </td>
                            <td>
                                <div>{{item.Author.AuthorName}}</div>
                            </td>
                            <td>
                                <div>{{item.Category.CategoryName}}</div>
                            </td>
                            <td>
                                <div>{{item.TotalChapters}}</div>
                            </td>
                            <td>
                                <div>{{item.BookStatus}}</div>
                            </td>
                            <td>
                                <div>
                                    {{ new Date(item.CreatedDate).toLocaleString() }}
                                </div>
                            </td>
                            <td>
                                <div>
                                    {{ new Date(item.UpdatedDate).toLocaleString() }}
                                </div>
                            </td>
                            
                            <td>
                                <div class="dropstart">
                                    <button
                                        class="btn btn-success"
                                        type="button"
                                        @click="changeStatus(item.BookId, 2)"
                                    >
                                    <i class="fa-solid fa-check" style="color: #ffffff;"></i>
                                    </button>
                                    <button
                                        class="btn btn-danger"
                                        type="button"
                                        @click="changeStatus(item.BookId, 3)"
                                    >
                                    <i class="fa-solid fa-xmark" style="color: #ffffff;"></i>
                                    </button>
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
const env = process.env;

export default {
    name: "admintruyen-layout",
    data() {
        return {
            search: "",
            books: []
        }
    },
    created(){
        this.getBooks();
    },
    methods: {
        async getBooks(){
            try {
                let url = `${env.VUE_APP_API_KEY}/book/get-by-status?status=1`;
                let res = (await axios.get(url)).data.Data;
                this.books = res;
            } catch (e) {
                console.log(e);
            }
        },
        async changeStatus(id, status){
            try {
                let header = {
                    Authorization : 'Bearer ' + localStorage.getItem(env.JWT_API_KEY)
                }
                let url = `${env.VUE_APP_API_KEY}/book/set-status?bookId=${id}&status=${status}`;
                await axios.put(url, header);
                this.getBooks();
            } catch (e) {
                console.log(e);
            }
        }
    }
};
</script>

<style></style>

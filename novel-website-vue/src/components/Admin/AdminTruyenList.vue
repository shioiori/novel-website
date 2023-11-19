<template>
    <div class="row">
        <div class="col-md-12">
            <h4>Tìm kiếm truyện</h4>
            <div class="search input-group float-md-start w-50 search-admin">
                <input
                    type="text"
                    class="form-control shadow-none"
                    name="name"
                    placeholder="Nhập tên truyện"
                    v-model="search"
                />
                <button
                    class="btn btn-success btn--search-color"
                    type="submit"
                    title="searchButton"
                    @click="searchBook()"
                >
                    <i
                        class="fa-solid fa-magnifying-glass search__btn--icons"
                    ></i>
                </button>
            </div>
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
                            <th>Trạng thái</th>
                            <th></th>
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
                                    {{ formatDate(item.CreatedDate) }}
                                </div>
                            </td>
                            <td>
                                <div>
                                    {{ formatDate(item.UpdatedDate) }}
                                </div>
                            </td>
                            <th>
                               <div>
                                    <span :class="'badge bg-' + item.StatusLabelColor">{{ item.StatusName }}</span>
                                </div> 
                            </th>
                            <td>
                                <div class="dropstart">
                                    <ul
                                        class="dropdown-menu"
                                        aria-labelledby="dropdownMenuButton1"
                                    >
                                        <li>
                                            <a class="dropdown-item" href="#"
                                                >Thông tin truyện</a
                                            >
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#" @click="$emit('changeToChapter', item.BookId)"
                                                >Danh sách chương</a
                                            >
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#"
                                                >Sửa trạng thái</a
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
                let url = `${env.VUE_APP_API_KEY}/book/get-all`;
                let res = (await axios.get(url)).data.Data;
                this.books = res;
            } catch (e) {
                console.log(e);
            }
        },
        async searchBook(){
            if (this.search == "") return;
            try {
                let url = `${env.VUE_APP_API_KEY}/book/get-by-name?name=${this.search}`;
                let res = (await axios.get(url)).data.Data;
                this.books = res;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        },
        formatDate(datetime) {
            var date = new Date(datetime);
            return ((date.getMonth() > 8) ? (date.getMonth() + 1) : ('0' + (date.getMonth() + 1))) + '/' + ((date.getDate() > 9) ? date.getDate() : ('0' + date.getDate())) + '/' + date.getFullYear();
        }
    }
};
</script>

<style></style>

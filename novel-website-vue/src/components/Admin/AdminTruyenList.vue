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
                />
                <button
                    class="btn btn-success btn--search-color"
                    type="submit"
                    title="searchButton"
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
                            <th>Lượt xem</th>
                            <th>Yêu thích</th>
                            <th>Đề cử</th>
                            <th>Tình trạng</th>
                            <th>Cập nhật mới</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle">
                            <td>
                                <div>@i</div>
                            </td>
                            <td>
                                <div>@item.BookName</div>
                            </td>
                            <td>
                                <div>@item.Author.AuthorName</div>
                            </td>
                            <td>
                                <div>@item.Category.CategoryName</div>
                            </td>
                            <td>
                                <div>@item.NumberOfChapters</div>
                            </td>
                            <td>
                                <div>@item.Views</div>
                            </td>
                            <td>
                                <div>@item.Likes</div>
                            </td>
                            <td>
                                <div>@item.Recommends</div>
                            </td>
                            <td>
                                <div>@item.BookStatus.BookStatusName</div>
                            </td>
                            <td>
                                <div>
                                    @DateTimeExtension.TimeSpan(item.UpdatedDate)
                                </div>
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
                                            <a class="dropdown-item" href="#"
                                                >Thông tin truyện</a
                                            >
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#" @click="$emit('changeToChapter', bookId)"
                                                >Danh sách chương</a
                                            >
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#"
                                                >Sửa</a
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
export default {
    name: "admintruyen-layout",
    data() {
        return {
            bookId: 123
        }
    }
};
</script>

<style></style>

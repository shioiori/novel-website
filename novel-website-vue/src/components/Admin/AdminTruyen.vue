<template>
    <div>
        <AdminHeader></AdminHeader>
        <div class="body flex-grow-1 px-3">
            <div class="container-lg">
                <div class="row">
                    <div class="col-md-12">
                        <h4>Tìm kiếm truyện</h4>
                        <form action="/Admin/Book/ListOfBooks" method="get">
                            <div
                                class="search input-group float-md-start w-50 search-admin"
                            >
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
                        </form>
                    </div>
                    <div class="col-md-12">
                        <h4>Danh sách truyện</h4>
                    </div>
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table border mb-0 table-striped">
                                <thead class="table-dark fw-semibold">
                                    <tr class="align-middle">
                                        <th class="text-center">
                                            <svg class="icon">
                                                <use
                                                    xlink:href="vendors/@@coreui/icons/svg/free.svg#cil-people"
                                                ></use>
                                            </svg>
                                        </th>
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
                                            <div>
                                                @item.Category.CategoryName
                                            </div>
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
                                            <div>
                                                @item.BookStatus.BookStatusName
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                @DateTimeExtension.TimeSpan(item.UpdatedDate)
                                            </div>
                                        </td>
                                        <td>
                                            <div class="dropdown">
                                                <button
                                                    class="btn btn-transparent p-0"
                                                    type="button"
                                                    data-coreui-toggle="dropdown"
                                                    aria-haspopup="true"
                                                    aria-expanded="false"
                                                >
                                                    <svg class="icon">
                                                        <use
                                                            xlink:href="vendors/@@coreui/icons/svg/free.svg#cil-options"
                                                        ></use>
                                                    </svg>
                                                </button>
                                                <div
                                                    class="dropdown-menu dropdown-menu-end"
                                                >
                                                    <a
                                                        class="dropdown-item"
                                                        href="/truyen/@item.Slug-@item.BookId"
                                                        >Thông tin truyện</a
                                                    >
                                                    <a
                                                        class="dropdown-item"
                                                        href="/dang-tai/@item.UserId/truyen/@item.BookId"
                                                        >Chỉnh sửa</a
                                                    >
                                                    <a
                                                        class="dropdown-item"
                                                        href="/dang-tai/@item.UserId/truyen/@item.BookId/danh-sach-chuong"
                                                        >Danh sách chương</a
                                                    >
                                                    <a
                                                        class="dropdown-item text-danger"
                                                        href="/Admin/Book/DeleteBook/@item.BookId"
                                                        >Xoá</a
                                                    >
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="align-middle">
                                        <td>
                                            <div>Đây là tên truyện 1</div>
                                        </td>
                                        <td>
                                            <div>Yiorgos Avraamu</div>
                                        </td>
                                        <td>
                                            <div>Thể loại Vjp</div>
                                        </td>
                                        <td>
                                            <div>xxx Chương</div>
                                        </td>
                                        <td>
                                            <div>xxx Lượt xem</div>
                                        </td>
                                        <td>
                                            <div>xxx Yêu thích</div>
                                        </td>
                                        <td>
                                            <div>xxx Đề cử</div>
                                        </td>
                                        <td>
                                            <div>Đang tiến hành</div>
                                        </td>
                                        <td>
                                            <div class="fw-semibold">
                                                10 sec ago
                                            </div>
                                        </td>
                                        <td>
                                            <div class="dropdown">
                                                <button
                                                    class="btn btn-transparent p-0"
                                                    type="button"
                                                    data-coreui-toggle="dropdown"
                                                    aria-haspopup="true"
                                                    aria-expanded="false"
                                                >
                                                    <svg class="icon">
                                                        <use
                                                            xlink:href="vendors/@@coreui/icons/svg/free.svg#cil-options"
                                                        ></use>
                                                    </svg>
                                                </button>
                                                <div
                                                    class="dropdown-menu dropdown-menu-end"
                                                >
                                                    <a
                                                        class="dropdown-item"
                                                        href="#"
                                                        >Duyệt</a
                                                    ><a
                                                        class="dropdown-item"
                                                        href="#"
                                                        >Chỉnh sửa</a
                                                    ><a
                                                        class="dropdown-item text-danger"
                                                        href="#"
                                                        >Xóa</a
                                                    >
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="box-footer">
                            <div class="box-footer-clearfix">
                                <ul class="pagination justify-content-end"></ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import AdminHeader from "./AdminHeader.vue";
export default {
    name: "adminsidebar-layout",
    components: {
        AdminHeader,
    },
};
</script>

<style></style>

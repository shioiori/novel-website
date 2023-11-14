<template>
    <div class="row col-md-10">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <h4>Tìm kiếm thể loại</h4>
                    <div
                        class="search input-group float-md-start w-50 search-admin"
                    >
                        <input
                            type="text"
                            class="form-control shadow-none"
                            name="name"
                            placeholder="Nhập tên tag"
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
                    <h4>Quản lý thể loại</h4>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead class="table-dark fw-semibold">
                                <tr class="align-middle">
                                    <th>Mã thể loại</th>
                                    <th>Tên thể loại</th>
                                    <th>Số tác phẩm</th>
                                    <th>Slug</th>
                                    <th>Ảnh đại diện</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="align-middle">
                                    <td>
                                        <div>@item.CategoryId</div>
                                    </td>
                                    <td>
                                        <div>@item.CategoryName</div>
                                    </td>
                                    <td>
                                        <div>@item.Quantity</div>
                                    </td>
                                    <td>
                                        <div>@item.Slug</div>
                                    </td>
                                    <td>
                                        <div class="category-img">
                                            <img src="" />
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
                                                Thay đổi
                                            </button>
                                            <ul
                                                class="dropdown-menu"
                                                aria-labelledby="dropdownMenuButton1"
                                            >
                                                <li>
                                                    <a
                                                        class="dropdown-item"
                                                        href="#"
                                                        >Sửa</a
                                                    >
                                                </li>
                                                <li>
                                                    <a
                                                        class="dropdown-item"
                                                        href="#"
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
                <!-- <div class="col-md-12">
                    <div class="box-footer">
                        <div class="box-footer-clearfix">
                            <ul
                                class="pagination pagination-sm no-margin pull-right"
                            >
                                <li><a href="">&laquo;</a></li>
                                <li><a href=""></a></li>
                                <li><a href="">&raquo;</a></li>
                            </ul>
                            <ul class="pagination justify-content-end">
                                <li class="page-item">
                                    <a class="page-link" href="">
                                        <span aria-hidden="true">&laquo;</span>
                                    </a>
                                </li>

                                <li class="page-item">
                                    <a
                                        class="page-link"
                                        href="/Admin/Category/Index?pageNumber=@i"
                                        >@i</a
                                    >
                                </li>

                                <li class="page-item">
                                    <a
                                        class="page-link"
                                        href="/Admin/Category/Index?pageNumber=@Math.Min(pageNumber + 1, pageCount)"
                                    >
                                        <span aria-hidden="true">&raquo;</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div> -->
            </div>
        </div>
        <div class="col-md-4 config-box">
            <div class="col-md-12">
                <h4>Chỉnh sửa thể loại</h4>
            </div>
            <div class="col-12">
                <label for="inputMaTheLoai" class="form-label"
                    >Mã thể loại</label
                >
                <input
                    type="text"
                    name="CategoryId"
                    class="form-control"
                    id="inputMaTheLoai"
                    placeholder="Id autogenerated"
                    readonly
                />
            </div>
            <div class="col-12">
                <label for="inputTenTheLoai" class="form-label"
                    >Tên thể loại</label
                >
                <input
                    type="text"
                    name="CategoryName"
                    class="form-control"
                    id="inputTenTheLoai"
                />
            </div>
            <div class="col-12">
                <label class="form-labal">Ảnh đại diện</label>
            </div>
            <div class="col-auto">
                <div class="category-select-picture">
                    <div class="category-img-container">
                        <img src="/image/test.jpg" class="input-img" />
                    </div>
                </div>
            </div>
            <input type="text" name="CategoryImage" hidden />
            <div class="col-auto">
                <input type="file" name="fileUpload" />
            </div>
            <div class="col-12">
                <button type="submit" class="btn btn-primary">
                    Lưu thay đổi
                </button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "admintheloai-layout",
};
</script>

<style>
.config-box > .col-12,
.config-box > .col-auto {
    margin-bottom: 1rem;
}
</style>

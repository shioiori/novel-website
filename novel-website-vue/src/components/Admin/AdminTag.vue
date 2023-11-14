<template>
    <div class="row col-md-10">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <h4>Tìm kiếm tag</h4>
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
                    <h4>Quản lý tag</h4>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead class="table-dark fw-semibold">
                                <tr class="align-middle">
                                    <th>Mã thẻ</th>
                                    <th>Tên thẻ</th>
                                    <th>Đường dẫn</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="list-tags">
                                <tr class="align-middle">
                                    <td>
                                        <div>@item.TagId</div>
                                    </td>
                                    <td>
                                        <div>@item.TagName</div>
                                    </td>
                                    <td>
                                        <div>@item.Slug</div>
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
                <div class="col-md-12">
                    <div class="box-footer">
                        <div class="box-footer-clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4 config-box">

                <div class="col-md-12">
                    <h4>Chỉnh sửa tag</h4>
                </div>
                <div class="col-12">
                    <label for="inputMaTheLoai" class="form-label"
                        >Mã tag</label
                    >
                    <input
                        type="text"
                        name="TagId"
                        class="form-control"
                        id="inputMaTheLoai"
                        placeholder="Id autogenerated"
                        readonly
                    />
                </div>
                <div class="col-12">
                    <label for="inputTenTheLoai" class="form-label"
                        >Tên tag</label
                    >
                    <input
                        type="text"
                        name="TagName"
                        class="form-control"
                        id="inputTenTheLoai"
                    />
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
    name: "admintag-layout",
};
</script>

<style>
.config-box > .col-12 {
    margin-bottom: 1rem;
}
</style>

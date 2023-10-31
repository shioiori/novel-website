<template>
    <div>
        <AdminHeader></AdminHeader>
        <div class="container-fluid">
            <div class="row">
                <AdminSidebar></AdminSidebar>
                <div class="row col-md-9">
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-12">
                                <h4>Tìm kiếm tag</h4>
                                <form action="/Admin/Tag/Index" method="get">
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
                                </form>
                            </div>
                            <div class="col-md-12">
                                <h4>Quản lý tag</h4>
                            </div>
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table
                                        class="table border mb-0 table-striped"
                                    >
                                        <thead class="table-dark fw-semibold">
                                            <tr class="align-middle">
                                                <th class="text-center">
                                                    <svg class="icon">
                                                        <use
                                                            xlink:href="vendors/@@coreui/icons/svg/free.svg#cil-people"
                                                        ></use>
                                                    </svg>
                                                </th>
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
                                                                onclick="AddOrUpdateTag(@item.TagId)"
                                                                >Chỉnh sửa</a
                                                            >
                                                            <a
                                                                class="dropdown-item text-danger"
                                                                href="/Admin/Tag/DeleteTag?id=@item.TagId"
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
                                    <div class="box-footer-clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <form
                            class="row g-3"
                            method="post"
                            action="/Admin/Tag/AddOrUpdateTag"
                        >
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
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import AdminHeader from "./AdminHeader.vue";
import AdminSidebar from "./AdminSidebar.vue";

export default {
    name: "admintag-layout",
    components: {
        AdminHeader,
        AdminSidebar,
    },
};
</script>

<style></style>

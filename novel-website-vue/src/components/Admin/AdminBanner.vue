<template>
    <div class="row col-md-10">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <h4>Quản lý banner</h4>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead class="table-dark fw-semibold">
                                <tr class="align-middle">
                                    <th>Mã banner</th>
                                    <th>Banner</th>
                                    <th>Loại</th>
                                    <th>Thuộc sách</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="list-tags">
                                <tr class="align-middle">
                                    <td>
                                        <div>@item.BannerId</div>
                                    </td>
                                    <td>
                                        <div
                                            class="banner-img"
                                            data-coreui-toggle="modal"
                                            data-coreui-target=""
                                            role="button"
                                        >
                                            <img src="" />
                                        </div>
                                        <div
                                            class="modal fade"
                                            id="modal_@item.BannerId"
                                            tabindex="-1"
                                        >
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button
                                                            type="button"
                                                            class="btn-close"
                                                            data-coreui-dismiss="modal"
                                                            aria-label="Close"
                                                        ></button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <img src="" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div>@item.BannerSize</div>
                                    </td>
                                    <td>
                                        <div>
                                            <a
                                                href="/truyen/@item.Book.Slug-@item.Book.BookId"
                                                >@item.Book.BookName</a
                                            >
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
                <div class="col-md-12">
                    <div class="box-footer">
                        <div class="box-footer-clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4 config-box">
            <div class="col-md-12">
                <h4>Chỉnh sửa banner</h4>
            </div>
            <div class="col-12">
                <label for="inputMaTheLoai" class="form-label">Mã banner</label>
                <input
                    type="text"
                    name="BannerId"
                    class="form-control"
                    id="inputMaTheLoai"
                    placeholder="Id autogenerated"
                    readonly
                />
            </div>
            <div class="col-12">
                <label for="inputMaTheLoai" class="form-label"
                    >Loại banner</label
                >
                <select name="BannerSize">
                    <option value="L">L</option>
                    <option value="M">M</option>
                    <option value="S">S</option>
                </select>
            </div>
            <div class="col-12">
                <label class="form-labal">Ảnh</label>
            </div>
            <div class="col-auto">
                <div class="banner-select-picture">
                    <div class="banner-img-container">
                        <img src="/image/test.jpg" class="input-img" />
                    </div>
                </div>
                <input type="text" name="BannerImage" hidden />
            </div>
            <div class="col-auto">
                <input type="file" name="fileUpload" />
            </div>
            <div class="col-12">
                <label for="inputMaTheLoai" class="form-label"
                    >Thuộc sách</label
                >
                <select
                    class="form-select"
                    name="BookId"
                    asp-items="@ViewBag.Books"
                ></select>
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
    name: "adminbanner-layout",
};
</script>

<style>
.config-box > .col-12, .config-box > .col-auto {
    margin-bottom: 1rem;
}
</style>

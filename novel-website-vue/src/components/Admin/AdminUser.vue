<template>
    <div class="col-md-10">
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12 title-flex">
                        <h4>Danh sách người dùng</h4>
                        <div class="btn-group">
                            <button
                                type="button"
                                class="btn btn-secondary dropdown-toggle"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                Lọc theo
                            </button>
                            <ul class="dropdown-menu">
                                <li>
                                    <a
                                        href="/Admin/User/Index"
                                        class="dropdown-item"
                                        >Tất cả</a
                                    >
                                </li>
                                <li>
                                    <a
                                        href="/Admin/User/Index?roleId=1"
                                        class="dropdown-item"
                                        >Admin</a
                                    >
                                </li>
                                <li>
                                    <a
                                        href="/Admin/User/Index?roleId=2"
                                        class="dropdown-item"
                                        >Biên tập viên</a
                                    >
                                </li>
                                <li>
                                    <a
                                        href="/Admin/User/Index?roleId=3"
                                        class="dropdown-item"
                                        >Người dùng</a
                                    >
                                </li>
                                <li><hr class="dropdown-divider" /></li>
                                <li>
                                    <a
                                        href="/Admin/User/Index?status=1"
                                        class="alert-danger dropdown-item"
                                        >Banned</a
                                    >
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="table-responsive">
                    <table class="table border mb-0 table-striped">
                        <thead class="table-dark fw-semibold">
                            <tr class="align-middle">
                                <th>UserID</th>
                                <th>Avatar</th>
                                <th>Username</th>
                                <th>Account</th>
                                <th>Email</th>
                                <th>Role</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="align-middle">
                                <td>Id</td>
                                <td>
                                    <div>
                                        <img src="" class="rounded-circle" />
                                    </div>
                                </td>
                                <td>
                                    <div>@item.User.UserName</div>
                                </td>
                                <td>
                                    <div>@item.AccountName</div>
                                </td>
                                <td>
                                    <div>@item.User.Email</div>
                                </td>
                                <td>
                                    <div>@item.User.Role.RoleName</div>
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
                                                    data-bs-toggle="modal"
                                                    data-bs-target="#roleModal"
                                                    >Sửa role</a
                                                >
                                            </li>
                                            <li>
                                                <a
                                                    class="dropdown-item"
                                                    href="#"
                                                    >Xóa người dùng</a
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
        <div
            class="modal fade"
            id="roleModal"
            tabindex="-1"
            aria-labelledby="exampleModalLabel"
            aria-hidden="true"
        >
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">
                            Chỉnh sửa Role
                        </h5>
                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal"
                            aria-label="Close"
                        ></button>
                    </div>
                    <input type="text" name="UserId" hidden />
                    <div class="modal-body">
                        <label class="form-label" for="specificSizeSelect"
                            >Role</label
                        >
                        <select
                            class="form-select"
                            name="RoleId"
                            id="specificSizeSelect"
                        ></select>
                    </div>
                    <div class="modal-footer">
                        <button
                            type="button"
                            class="btn btn-secondary"
                            data-bs-dismiss="modal"
                        >
                            Close
                        </button>
                        <button
                            type="submit"
                            class="btn btn-primary"
                            data-bs-dismiss="modal"
                        >
                            Save changes
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "adminuser-layout",
};
</script>

<style>
.title-flex {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1rem;
}
</style>

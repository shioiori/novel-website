<template>
    <div class="row">
        <div class="col-md-12 flex-title">
            <h4>Danh sách chương - name</h4>
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
                            <th>Lần sửa đổi gần nhất</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="align-middle">
                            <td>
                                <div>@item.ChapterNumber</div>
                            </td>
                            <td>
                                <div>@item.ChapterName</div>
                            </td>
                            <td>
                                <div>@item.Views</div>
                            </td>
                            <td>
                                <div>@item.Likes</div>
                            </td>
                            <td>
                                <div>@item.UpdatedDate</div>
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
                                                >Thông tin chương</a
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
    name: "admintruyenchapter-layout",
};
</script>

<style>
.flex-title {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1rem;
}
</style>

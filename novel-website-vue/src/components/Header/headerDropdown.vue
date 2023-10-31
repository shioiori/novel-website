<template>
    <div class="dropdown col-md-1 category-dropdown">
        <button
            type="button"
            class="btn btn-primary dropdown-toggle"
            data-bs-toggle="dropdown"
        >
            Thể loại
        </button>
        <div class="dropdown-menu mutli-column">
            <div class="row" id="chapter-category">
                <ul class="col-md-4">
                    <li>
                        <a href="javascript:void(0)">Tiên hiệp</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Huyền huyễn</a>
                    </li>
                    <li><a href="javascript:void(0)">Đô thị</a></li>
                    <li>
                        <a href="javascript:void(0)">Khoa huyễn</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Kỳ huyễn</a>
                    </li>
                </ul>
                <ul class="col-md-4">
                    <li>
                        <a href="javascript:void(0)">Lịch sử</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Đồng nhân</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Quân sự</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Võ hiệp</a>
                    </li>
                </ul>
                <ul class="col-md-4">
                    <li>
                        <a href="javascript:void(0)">Cạnh ký</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Linh dị</a>
                    </li>
                    <li>
                        <a href="javascript:void(0)">Ngôn tình</a>
                    </li>
                    <li><a href="javascript:void(0)">Du hí</a></li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "header-dropdown",
};
</script>

<style></style>

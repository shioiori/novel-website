<template>
    <div class="sort-box float-wrapper d-flex">
        <a
            type="button"
            id="dropdown1"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            >Thể loại<i
                class="fa fa-sort-desc"
                aria-hidden="true"
                style="
                    font-size: 1.6rem;
                    margin: 0 0.4rem;
                    vertical-align: top;
                    line-height: 1.2rem;
                "
            ></i
        ></a>
        <ul aria-labelledby="dropdown1" class="dropdown-menu">
            <li>
                <a
                    href="/bang-xep-hang?category_id=@item.CategoryId"
                    class="dropdown-item"
                    >@item.CategoryName</a
                >
            </li>
        </ul>
        <a
            type="button"
            id="dropdown2"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            >Xếp theo<i
                class="fa fa-sort-desc"
                aria-hidden="true"
                style="
                    font-size: 1.6rem;
                    margin: 0 0.4rem;
                    vertical-align: top;
                    line-height: 1.2rem;
                "
            ></i
        ></a>
        <ul aria-labelledby="dropdown2" class="dropdown-menu">
            <li>
                <a href="/bang-xep-hang?sort_by=like" class="dropdown-item"
                    >Lượt yêu thích</a
                >
            </li>
            <li>
                <a href="/bang-xep-hang?sort_by=recommend" class="dropdown-item"
                    >Lượt đề cử</a
                >
            </li>
            <li>
                <a href="/bang-xep-hang?sort_by=follow" class="dropdown-item"
                    >Lượt theo dõi</a
                >
            </li>
            <li>
                <a href="/bang-xep-hang?sort_by=view" class="dropdown-item"
                    >Lượt đọc</a
                >
            </li>
        </ul>
        <a
            class="ms-auto"
            type="button"
            id="dropdown3"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            >Lọc theo<i
                class="fa fa-sort-desc"
                aria-hidden="true"
                style="
                    font-size: 1.6rem;
                    margin: 0 0.4rem;
                    vertical-align: top;
                    line-height: 1.2rem;
                "
            ></i
        ></a>
        <ul aria-labelledby="dropdown3" class="dropdown-menu">
            <li>
                <a href="/bang-xep-hang?order=down" class="dropdown-item"
                    >Mới nhất</a
                >
            </li>
            <li>
                <a href="/bang-xep-hang?order=up" class="dropdown-item"
                    >Cũ nhất</a
                >
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "billboard-nav",
};
</script>

<style>
.sort-box {
    margin: auto;
    border-bottom: 1px solid #bbb;
    padding-bottom: .5rem;
}

.sort-box a {
    font-size: 1.2rem;
}

.sort-box a:first-child {
    margin-right: .5rem;
}
</style>

<template>
    <div class="sort-box float-wrapper d-flex lop-nav">
        <a
            type="button"
            id="dropdown1"
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
        <ul aria-labelledby="dropdown1" class="dropdown-menu">
            <li>
                <a
                    href="/bang-xep-hang?category_id=@item.CategoryId"
                    class="dropdown-item"
                    >Mới nhất</a
                >
            </li>
            <li>
                <a
                    href="/bang-xep-hang?category_id=@item.CategoryId"
                    class="dropdown-item"
                    >Cũ nhất</a
                >
            </li>
        </ul>
        <form action="/tin-tuc" method="get">
            <div class="right search input-group">
                <input
                    type="text"
                    class="form-control shadow-none"
                    name="name"
                    placeholder="Nhập tiêu đề bài viết"
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
</template>

<script>
export default {
    name: "lopnav-layout"
};
</script>

<style>
.lop-nav {
    justify-content: space-between;
}
</style>

<template>
    <div class="sort-box d-flex review-nav">
        <div class="me-auto">
            <i
                class="fa fa-commenting"
                aria-hidden="true"
                style="font-size: 2rem; margin-right: 0.7rem; color: #343434"
            ></i
            ><span style="font-size: 1.37rem; font-weight: bold; color: #555555"
                >Review</span
            >
        </div>
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
        <a
            type="button"
            id="dropdown2"
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
        <ul aria-labelledby="dropdown2" class="dropdown-menu">
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
    </div>
</template>

<script>
export default {
    name: "reviewnav-layout",
};
</script>

<style>
.review-nav {
    align-items: center;
    margin-top: 2rem;
}
.review-nav a:nth-child(2) {
    margin-right: 1rem;
}
</style>

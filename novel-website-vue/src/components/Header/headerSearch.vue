<template>
    <div class="col search input-group">
        <form>
            <input
                type="text"
                class="form-control shadow-none no-border-radius"
                name="searchName"
                placeholder="Nhập tên truyện"
            />
            <button
                class="btn btn-success btn--search-color no-border-radius"
                type="submit"
                title="searchButton"
            >
                <i class="fa-solid fa-magnifying-glass search__btn--icons"></i>
            </button>
        </form>
    </div>
</template>

<script>
export default {
    name: "header-search",
};
</script>

<style></style>

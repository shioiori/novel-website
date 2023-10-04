<template>
    <div
        id="demo"
        class="index__slider carousel slide col-md-6"
        data-bs-ride="carousel"
    >
        <div class="carousel-indicators">
            <button
                type="button"
                data-bs-target="#demo"
                data-bs-slide-to="0"
                class="active"
            ></button>
            <button
                type="button"
                data-bs-target="#demo"
                data-bs-slide-to="1"
            ></button>
            <button
                type="button"
                data-bs-target="#demo"
                data-bs-slide-to="2"
            ></button>
        </div>
        <div class="carousel-inner" id="banner-carousel"></div>
        <button
            class="carousel-control-prev"
            type="button"
            data-bs-target="#demo"
            data-bs-slide="prev"
        >
            <span class="carousel-control-prev-icon"></span>
        </button>
        <button
            class="carousel-control-next"
            type="button"
            data-bs-target="#demo"
            data-bs-slide="next"
        >
            <span class="carousel-control-next-icon"></span>
        </button>
    </div>
</template>

<script>
export default {
    name: "carousel-layout",
};
</script>

<style></style>

<template>
    <div class="index__right-wrap col-md-9" id="newbook">
        <div class="index__right-wrap--list row">
            <truyenItem></truyenItem>
            <truyenItem></truyenItem>
            <truyenItem></truyenItem>
            <truyenItem></truyenItem>
            <truyenItem></truyenItem>
            <truyenItem></truyenItem>
            <truyenItem></truyenItem>
        </div>
    </div>
</template>

<script>
import truyenItem from "./truyenItem.vue";

export default {
    name: "truyenMoi-layout",
    components: {
        truyenItem,
    },
};
</script>

<style></style>

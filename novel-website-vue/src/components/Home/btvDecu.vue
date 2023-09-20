<template>
    <div class="index__btv col-md-9">
        <h4>Biên tập viên đề cử</h4>
        <div id="editor-recommend">
            <div class="index__right-wrap--list row">
                <truyenItem></truyenItem>
                <truyenItem></truyenItem>
                <truyenItem></truyenItem>
                <truyenItem></truyenItem>
                <truyenItem></truyenItem>
                <truyenItem></truyenItem>
            </div>
        </div>
    </div>
</template>

<script>
import truyenItem from './truyenItem.vue';

export default {
    name: "btv-layout",
    components: {
        truyenItem
    }
};
</script>

<style></style>

<template>
    <div class="chapter">
        <div class="chapter-content">
            <chapterToolbar></chapterToolbar>
            <boxChapter></boxChapter>
            <div class="quangcaotruyen">
                <a href="javascript:void(0)"
                    ><img src="/image/test.jpg" class="banner-sm"
                /></a>
            </div>
            <chapterComment></chapterComment>
        </div>
    </div>
</template>

<script>
import chapterToolbar from './chapterToolbar.vue';
import boxChapter from './boxChapter.vue';
import chapterComment from './chapterComment.vue';

export default {
    name: 'chapterContent',
    components: {
        chapterToolbar,
        boxChapter,
        chapterComment,
    }
};
</script>

<style></style>

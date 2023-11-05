<template>
    <li class="list-group-item">
        <div class="row user--comment-section">
            <div class="user--photo col-md-auto">
                <a href="javascript:void(0)">
                    <img src="/image/test3.jpg" />
                </a>
            </div>
            <div class="user--discussion-main col">
                <div class="user--discussion">
                    <p class="users">
                        <a href="javascript:void(0)">kfc group</a>
                        <span>bá tánh bình dân</span>
                    </p>
                    <p class="comments">
                        truyện hay truyện hay truyện hay truyện hay truyện hay
                        truyện hay
                    </p>
                    <p class="info--wrap">
                        <span>2 hrs</span>
                        <!-- <a href="javascript:void(0)">
                            <i class="fa-regular fa-comment-dots info-icon"></i>
                            0 trả lời
                        </a> -->
                        <a href="javascript:void(0)">
                            <i class="fa-regular fa-thumbs-up info-icon"></i>
                            0
                        </a>
                    </p>
                </div>
            </div>
        </div>
    </li>
</template>

<script>
export default {
    name: "nested-comment",
};
</script>

<style></style>

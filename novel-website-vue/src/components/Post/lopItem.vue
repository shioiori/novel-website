<template>
    <div class="post-item col-sm-12">
        <div class="avatar pull-left" title="@item.User.UserName">
            <a href="" class="pull-left">
                <img
                    :src="avatar"
                    class="user-img"
                />
            </a>
        </div>
        <h2 class="post-title">
            <!-- <i
                component="topic/pinned"
                class="fa fa-thumb-tack hide"
                title="Pinned"
            ></i>
            <i
                component="topic/locked"
                class="fa fa-lock hide"
                title="Khóa"
            ></i> -->
            <div class="card-title">
                <a @click="$router.push(`/post/${postId}`)" itemprop="url"
                    >{{ title }}</a
                ><br />
            </div>
            <div href="">{{ userName }} &bull; {{ createdDate }}</div>
            <div>
                <span>{{ description }}</span>
            </div>
        </h2>
    </div>
</template>

<script>
export default {
    name: "lopitem-layout",
    props: {
        avatar: String,
        title: String,
        userName: String,
        createdDate: Date,
        description: String,
        postId: String,
    }
};
</script>

<style>
.user-img {
    width: 46px;
    height: 46px;
    border-radius: 100%;
}
.post-item {
    display: flex;
    margin-top: 1rem;
}
.post-title {
    margin-left: 1rem;
}
</style>

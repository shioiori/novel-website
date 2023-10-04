<template>
    <div class="post-item col-sm-12">
        <div class="avatar pull-left" title="@item.User.UserName">
            <a href="" class="pull-left">
                <img
                    src="../../assets/img/logo1.png"
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
                <a href="/tin-tuc/@item.Slug-@item.PostId" itemprop="url"
                    >@item.Title</a
                ><br />
            </div>
            <div href="">@item.User.UserName &bull; @item.CreatedDate</div>
            <div>
                <span> @item.Description </span>
            </div>
        </h2>
    </div>
</template>

<script>
export default {
    name: "lopitem-layout",
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

<template>
    <div class="col-md-10">
        <div class="row">
            <div class="col-md-12">
            <h4>Tìm kiếm bài viết</h4>
                <div
                    class="search input-group float-md-start w-50 search-admin"
                >
                    <input
                        type="text"
                        class="form-control shadow-none"
                        name="name"
                        placeholder="Nhập tiêu đề..."
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
        </div>
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h4 class="box-title">Tất cả bài viết</h4>
                </div>
                <div class="tab-content" style="margin: 1.5rem">
                    <div class="post row">
                        <div class="user-block">
                            <img
                                class="img-circle img-bordered-sm"
                                src=""
                                alt="user image"
                            />
                            <span class="username">
                                <span class="mailbox-read-time pull-right">
                                    <a
                                        href="/Admin/Blog/AddOrUpdate?id=@item.Id"
                                        class="link-primary"
                                    >
                                        <i class="fa fa-edit"></i>Edit
                                    </a>
                                    |
                                    <a href="/Admin/Blog/Delete?id=@item.Id">
                                        <i class="fa fa-close"></i>Delete
                                    </a>
                                </span>

                                <a href="/Admin/Blog/Post?id=@item.Id"
                                    >@item.Title</a
                                >
                                <a href="#" class="pull-right btn-box-tool"></a>
                            </span>
                            <span class="description"
                                >Written by @item.AuthorName - Shared public -
                                @item.CreatedDate.ToString("MMM d, yyyy")</span
                            >
                        </div>
                        <p>@item.Description</p>
                    </div>

                    <!-- <div class="post row">
                        <div class="useravatar col-md-auto">
                            <a href="#"
                                ><img
                                    class="img-circle img-bordered-sm col"
                                    src=""
                                    alt="user image"
                            /></a>
                        </div>
                        <div class="user-post col row">
                            <span class="user-post-title col-md-10">
                                <a href="/tin-tuc/@item.Slug-@item.PostId"
                                    >@item.Title</a
                                >
                            </span>
                            <span class="float-end col-md-2">
                                <span class="control-button">
                                    <i class="fa fa-edit"></i>
                                    <a
                                        href="/Admin/Post/AddOrUpdatePost?id=@item.PostId"
                                        >Edit</a
                                    >
                                    |
                                    <i class="fa fa-close"></i>
                                    <a
                                        href="/Admin/Post/DeletePost?id=@item.PostId"
                                        >Delete</a
                                    >
                                </span>
                            </span>
                            <span class="user-post-name col-md-12">
                                Written by @item.User.UserName -
                                @item.CreatedDate
                            </span>
                            <span class="user-post-content col-md-12">
                                @item.Description
                            </span>
                        </div>
                    </div> -->
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="box-footer">
                <div class="box-footer clearfix"></div>
            </div>
        </div>
        </div>
        
    </div>
</template>

<script>
export default {
    name: "adminpostlist-layout",
};
</script>

<style></style>

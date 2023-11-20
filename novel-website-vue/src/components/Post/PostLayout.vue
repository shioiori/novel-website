<template>
    <div>
        <Header></Header>
        <div class="container body-container">
            <div class="content">
                <h1 class="truyen-title">@Model.Title</h1>
                <p class="truyen-author">
                    Người đăng:
                    <a href="javascript:void(0)">@Model.User.UserName</a>
                </p>
                <p class="truyen-time">Ngày đăng: @Model.CreatedDate</p>
            </div>

            <div class="chapter">
                <div class="chapter-content">
                    <div class="control-area-wrap"></div>

                    <div class="box-chapters">
                        <div class="box-chap">
                            @Html.Raw(HttpUtility.HtmlDecode(Model.Content))
                        </div>

                        <div class="box-ads">
                            <div class="box-icon-section">
                                <div class="box-icon-section-left">
                                    <a
                                        href="javascript:void(0)"
                                        id="post-like-btn"
                                        onclick="onClickBtnLikePost(this)"
                                    >
                                        <i class="fa-regular fa-thumbs-up"></i>
                                        @Model.Likes
                                    </a>
                                </div>

                                <div class="box-icon-section-right">
                                    <a href="javascript:void(0)">
                                        <i
                                            class="fa-solid fa-triangle-exclamation"
                                        ></i>
                                        Báo lỗi
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="comment-section">
                <div class="user--comment-discuss-wrap">
                    <div class="user--comment-discuss-list">
                        <div class="user--comment-discuss-list-title">
                            Bình luận
                        </div>
                        <ul
                            class="list-group list-group-flush"
                            id="list-comment-chapter"
                        >
                            <CommentArea></CommentArea>
                            <Comment></Comment>
                        </ul>
                        <p class="go--discuss">
                            <a href="javascript:void(0)">Thêm bình luận</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <Footer></Footer>
    </div>
</template>

<script>
import "../../assets/css/truyen.css";
import "../../assets/css/doctruyen.css";
import Header from "../Header/Header.vue";
import Footer from "../Footer/Footer.vue";
import CommentArea from "../Comment/CommentArea.vue";
import Comment from "../Comment/Comment.vue";

export default {
    name: "post-layout",
    components: {
        Header,
        Footer,
        CommentArea,
        Comment,
    },
};
</script>

<style></style>

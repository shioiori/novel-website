<template>
    <div class="book--content tab-pane container active" id="book--content-id">
        <div class="row">
            <div class="col-md-9">
                <div class="book--content-detail">
                    <div class="book--content-detail-intro">
                        @Html.Raw(HttpUtility.HtmlDecode(Model.Introduce))
                    </div>
                    <div class="book--content-detail-state">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <b>Người đăng</b>
                                <div class="detail">
                                    <p class="tag-wrap">
                                        <a href="javascript:void(0)"
                                            >@Model.User.UserName</a
                                        >
                                    </p>
                                </div>
                            </li>
                            <li class="list-group-item">
                                <b>Tags</b>
                                <div class="detail">
                                    <p class="tag-wrap" id="book-tag">
                                        <a href="javascript:void(0)"
                                            >thục sơn</a
                                        >
                                        <a href="javascript:void(0)">lệ chi</a>
                                        <a href="javascript:void(0)"
                                            >chủng điền văn</a
                                        >
                                        <a href="javascript:void(0)"
                                            >tu chân văn minh</a
                                        >
                                    </p>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="quangcao">
                    <a href="javascript:void(0)"
                        ><img src="/image/test.jpg" class="banner-sm"
                    /></a>
                </div>
                <div class="user--comment">
                    <div class="user--comment-discuss-wrap">
                        <div class="user--comment-discuss-list">
                            <div class="user--comment-discuss-list-title">
                                Viết bình luận
                            </div>

                            <ul
                                class="list-group list-group-flush"
                                id="list-comment"
                            >
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="input-comment col">
                                            <div id="toolbar-container"></div>
                                            <div id="editor"></div>
                                        </div>

                                        <div class="submit-btn col-md-12">
                                            <div class="submit-btn-wrap">
                                                <button
                                                    type="button"
                                                    class="btn btn-primary"
                                                    onclick="AddBookComment()"
                                                >
                                                    Đăng
                                                </button>
                                            </div>
                                        </div>
                                        <!-- <form class="form-horizontal">
                                            <input type="hidden" name="" value="testing" />
                                            <button class="btn btn-primary submit-btn" type="submit">Đăng</button>
                                        </form> -->
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)"
                                                        >kfc group</a
                                                    >
                                                    <span
                                                        >bá tánh bình dân</span
                                                    >
                                                </p>
                                                <p class="comments">
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                </p>
                                                <p class="info--wrap">
                                                    <span>2 hrs</span>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-comment-dots info-icon"
                                                        ></i>
                                                        0 trả lời
                                                    </a>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-thumbs-up info-icon"
                                                        ></i>
                                                        0
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="user--discussion-child">
                                                <ul
                                                    class="list-group list-group-flush"
                                                >
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="user--discussion-main col"
                                                            >
                                                                <div
                                                                    class="user--discussion"
                                                                >
                                                                    <p
                                                                        class="users"
                                                                    >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                            >kfc
                                                                            group</a
                                                                        >
                                                                        <span
                                                                            >bá
                                                                            tánh
                                                                            bình
                                                                            dân</span
                                                                        >
                                                                    </p>
                                                                    <p
                                                                        class="comments"
                                                                    >
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                    </p>
                                                                    <p
                                                                        class="info--wrap"
                                                                    >
                                                                        <span
                                                                            >2
                                                                            hrs</span
                                                                        >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-comment-dots info-icon"
                                                                            ></i>
                                                                            0
                                                                            trả
                                                                            lời
                                                                        </a>
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-thumbs-up info-icon"
                                                                            ></i>
                                                                            0
                                                                        </a>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="input-comment col"
                                                            >
                                                                <textarea></textarea>
                                                            </div>
                                                            <div
                                                                class="submit-btn col-md-12"
                                                            >
                                                                <div
                                                                    class="submit-btn-wrap"
                                                                >
                                                                    <button
                                                                        class="btn btn-primary"
                                                                    >
                                                                        Đăng
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            <!-- <form class="form-horizontal">
                                                                <input type="hidden" name="" value="testing" />
                                                                <button class="btn btn-primary submit-btn" type="submit">Đăng</button>
                                                            </form> -->
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)"
                                                        >kfc group</a
                                                    >
                                                    <span
                                                        >bá tánh bình dân</span
                                                    >
                                                </p>
                                                <p class="comments">
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                </p>
                                                <p class="info--wrap">
                                                    <span>2 hrs</span>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-comment-dots info-icon"
                                                        ></i>
                                                        0 trả lời
                                                    </a>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-thumbs-up info-icon"
                                                        ></i>
                                                        0
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="user--discussion-child">
                                                <ul
                                                    class="list-group list-group-flush"
                                                >
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="user--discussion-main col"
                                                            >
                                                                <div
                                                                    class="user--discussion"
                                                                >
                                                                    <p
                                                                        class="users"
                                                                    >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                            >kfc
                                                                            group</a
                                                                        >
                                                                        <span
                                                                            >bá
                                                                            tánh
                                                                            bình
                                                                            dân</span
                                                                        >
                                                                    </p>
                                                                    <p
                                                                        class="comments"
                                                                    >
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                    </p>
                                                                    <p
                                                                        class="info--wrap"
                                                                    >
                                                                        <span
                                                                            >2
                                                                            hrs</span
                                                                        >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-comment-dots info-icon"
                                                                            ></i>
                                                                            0
                                                                            trả
                                                                            lời
                                                                        </a>
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-thumbs-up info-icon"
                                                                            ></i>
                                                                            0
                                                                        </a>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="input-comment col"
                                                            >
                                                                <textarea></textarea>
                                                            </div>
                                                            <div
                                                                class="submit-btn col-md-12"
                                                            >
                                                                <div
                                                                    class="submit-btn-wrap"
                                                                >
                                                                    <button
                                                                        class="btn btn-primary"
                                                                    >
                                                                        Đăng
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            <!-- <form class="form-horizontal">
                                                                <input type="hidden" name="" value="testing" />
                                                                <button class="btn btn-primary submit-btn" type="submit">Đăng</button>
                                                            </form> -->
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="row user--comment-section">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg" />
                                            </a>
                                        </div>
                                        <div class="col user--discussion-main">
                                            <div class="user--discussion">
                                                <p class="users">
                                                    <a href="javascript:void(0)"
                                                        >kfc group</a
                                                    >
                                                    <span
                                                        >bá tánh bình dân</span
                                                    >
                                                </p>
                                                <p class="comments">
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                    truyện hay truyện hay truyện
                                                    hay truyện hay truyện hay
                                                </p>
                                                <p class="info--wrap">
                                                    <span>2 hrs</span>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-comment-dots info-icon"
                                                        ></i>
                                                        0 trả lời
                                                    </a>
                                                    <a
                                                        href="javascript:void(0)"
                                                    >
                                                        <i
                                                            class="fa-regular fa-thumbs-up info-icon"
                                                        ></i>
                                                        0
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="user--discussion-child">
                                                <ul
                                                    class="list-group list-group-flush"
                                                >
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="user--discussion-main col"
                                                            >
                                                                <div
                                                                    class="user--discussion"
                                                                >
                                                                    <p
                                                                        class="users"
                                                                    >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                            >kfc
                                                                            group</a
                                                                        >
                                                                        <span
                                                                            >bá
                                                                            tánh
                                                                            bình
                                                                            dân</span
                                                                        >
                                                                    </p>
                                                                    <p
                                                                        class="comments"
                                                                    >
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                        truyện
                                                                        hay
                                                                    </p>
                                                                    <p
                                                                        class="info--wrap"
                                                                    >
                                                                        <span
                                                                            >2
                                                                            hrs</span
                                                                        >
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-comment-dots info-icon"
                                                                            ></i>
                                                                            0
                                                                            trả
                                                                            lời
                                                                        </a>
                                                                        <a
                                                                            href="javascript:void(0)"
                                                                        >
                                                                            <i
                                                                                class="fa-regular fa-thumbs-up info-icon"
                                                                            ></i>
                                                                            0
                                                                        </a>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item">
                                                        <div
                                                            class="row user--comment-section"
                                                        >
                                                            <div
                                                                class="user--photo col-md-auto"
                                                            >
                                                                <a
                                                                    href="javascript:void(0)"
                                                                >
                                                                    <img
                                                                        src="/image/test3.jpg"
                                                                    />
                                                                </a>
                                                            </div>
                                                            <div
                                                                class="input-comment col"
                                                            >
                                                                <textarea></textarea>
                                                            </div>
                                                            <div
                                                                class="submit-btn col-md-12"
                                                            >
                                                                <div
                                                                    class="submit-btn-wrap"
                                                                >
                                                                    <button
                                                                        class="btn btn-primary"
                                                                    >
                                                                        Đăng
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            <!-- <form class="form-horizontal">
                                                                <input type="hidden" name="" value="testing" />
                                                                <button class="btn btn-primary submit-btn" type="submit">Đăng</button>
                                                            </form> -->
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            @*
                            <p class="go--discuss">
                                <a href="javascript:void(0)">Thêm bình luận</a>
                            </p>
                            *@
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card author">
                    <div class="card-body">
                        <h4 class="card-title">@Model.Author.AuthorName</h4>
                        <ul class="list-group" id="book-same-author">
                            <li class="list-group-item">
                                <h5>Truyện cùng tác giả</h5>
                            </li>
                            <li class="list-group-item">
                                <a href="javascript:void(0)"
                                    >Nhất phù phong tiên</a
                                >
                            </li>
                            <li class="list-group-item">
                                <a href="javascript:void(0)"
                                    >Nhất phù phong tiên</a
                                >
                            </li>
                        </ul>
                    </div>
                </div>

                <div class="card author">
                    <div class="card-body">
                        <h4 class="card-title">@Model.User.UserName</h4>
                        <ul class="list-group" id="book-same-user">
                            <li class="list-group-item">
                                <h5>Truyện cùng người đăng</h5>
                            </li>
                            <li class="list-group-item">
                                <a href="javascript:void(0)"
                                    >Nhất phù phong tiên</a
                                >
                            </li>
                            <li class="list-group-item">
                                <a href="javascript:void(0)"
                                    >Nhất phù phong tiên</a
                                >
                            </li>
                        </ul>
                    </div>
                </div>

                <div class="like-more">
                    <h4>Có thể bạn sẽ thích</h4>
                    <div class="like-more-list">
                        <ul
                            class="list-group list-group-flush"
                            id="book-same-like"
                        >
                            <li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test2.jpg" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/html/truyen.html"
                                        >Tu chân thế giới</a
                                    >
                                    <p>Phương tưởng</p>
                                    <a
                                        href="/html/truyen.html"
                                        class="btn index__left-wrap--cardbtn truyen-btn"
                                    >
                                        Đọc truyện
                                        <i
                                            class="fa-solid fa-chevron-right"
                                        ></i>
                                    </a>
                                </h4>
                            </li>
                            <li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/html/truyen.html">Đại Kiếp Chú</a>
                                    <p>Hắc Sơn Lão Quỷ</p>
                                    <a
                                        href="/html/truyen.html"
                                        class="btn index__truyenmoito--cardbtn truyen-btn"
                                    >
                                        Đọc truyện
                                        <i
                                            class="fa-solid fa-chevron-right"
                                        ></i>
                                    </a>
                                </h4>
                            </li>
                            <li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test.jpg" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/html/truyen.html">Đạo Quân</a>
                                    <p>Dược Thiên Sầu</p>
                                    <a
                                        href="/html/truyen.html"
                                        class="btn index__truyenmoito--cardbtn truyen-btn"
                                    >
                                        Đọc truyện
                                        <i
                                            class="fa-solid fa-chevron-right"
                                        ></i>
                                    </a>
                                </h4>
                            </li>
                            <li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test2.jpg" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/html/truyen.html"
                                        >Tạo Hóa Chi Môn</a
                                    >
                                    <p>Nga Thị Lão Ngũ</p>
                                    <a
                                        href="/html/truyen.html"
                                        class="btn index__truyenmoito--cardbtn truyen-btn"
                                    >
                                        Đọc truyện
                                        <i
                                            class="fa-solid fa-chevron-right"
                                        ></i>
                                    </a>
                                </h4>
                            </li>
                            <li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/html/truyen.html">Vũ Mộ</a>
                                    <p>Cô Độc Phiêu Lưu</p>
                                    <a
                                        href="/html/truyen.html"
                                        class="btn index__truyenmoito--cardbtn truyen-btn"
                                    >
                                        Đọc truyện
                                        <i
                                            class="fa-solid fa-chevron-right"
                                        ></i>
                                    </a>
                                </h4>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'bookNavContent'
};
</script>

<style></style>

<template>
    <div class="comment-section">
        <div class="user--comment-discuss-wrap">
            <div class="user--comment-discuss-list">
                <div class="user--comment-discuss-list-title">Bình luận</div>
                <ul
                    class="list-group list-group-flush"
                    id="list-comment-chapter"
                >
                    <li class="list-group-item">
                        <div class="row user--comment-section">
                            <div class="user--photo col-md-auto">
                                <a href="javascript:void(0)">
                                    <img src="/image/test3.jpg" />
                                </a>
                            </div>
                            <div class="input-comment col">
                                <div id="postcomment-container"></div>
                                <div id="postcomment-editor"></div>
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
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-regular fa-comment-dots info-icon"
                                            ></i>
                                            0 trả lời
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-regular fa-thumbs-up info-icon"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                                <div class="user--discussion-child">
                                    <ul class="list-group list-group-flush">
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
                                                        <p class="users">
                                                            <a
                                                                href="javascript:void(0)"
                                                                >kfc group</a
                                                            >
                                                            <span
                                                                >bá tánh bình
                                                                dân</span
                                                            >
                                                        </p>
                                                        <p class="comments">
                                                            truyện hay truyện
                                                            hay truyện hay
                                                            truyện hay truyện
                                                            hay truyện hay
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
                                                <div class="input-comment col">
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
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-regular fa-comment-dots info-icon"
                                            ></i>
                                            0 trả lời
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-regular fa-thumbs-up info-icon"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                                <div class="user--discussion-child">
                                    <ul class="list-group list-group-flush">
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
                                                        <p class="users">
                                                            <a
                                                                href="javascript:void(0)"
                                                                >kfc group</a
                                                            >
                                                            <span
                                                                >bá tánh bình
                                                                dân</span
                                                            >
                                                        </p>
                                                        <p class="comments">
                                                            truyện hay truyện
                                                            hay truyện hay
                                                            truyện hay truyện
                                                            hay truyện hay
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
                                                <div class="input-comment col">
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
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay truyện hay
                                        truyện hay truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-regular fa-comment-dots info-icon"
                                            ></i>
                                            0 trả lời
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-regular fa-thumbs-up info-icon"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                                <div class="user--discussion-child">
                                    <ul class="list-group list-group-flush">
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
                                                        <p class="users">
                                                            <a
                                                                href="javascript:void(0)"
                                                                >kfc group</a
                                                            >
                                                            <span
                                                                >bá tánh bình
                                                                dân</span
                                                            >
                                                        </p>
                                                        <p class="comments">
                                                            truyện hay truyện
                                                            hay truyện hay
                                                            truyện hay truyện
                                                            hay truyện hay
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
                                                <div class="input-comment col">
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
</template>

<script>
export default {
    name: "chapterComment",
};
</script>

<style></style>

<template>
    <div class="book--rate tab-pane container fade" id="book--rate-id">
        <div class="user--rate">
            <div class="user--comment-discuss-wrap">
                <div class="user--comment-discuss-list">
                    <div class="user--comment-discuss-list-title">
                        Viết đánh giá
                    </div>

                    <ul class="list-group list-group-flush" id="list-review">
                        <li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <div class="input-comment col"></div>
                                <div class="submit-btn col-md-12">
                                    <div class="submit-btn-wrap">
                                        <button
                                            type="button"
                                            class="btn btn-primary"
                                            onclick="AddReview(@Model.BookId)"
                                        >
                                            Đăng
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <div class="user--discussion col">
                                    <p class="users">
                                        <a href="javascript:void(0)"
                                            >kfc group</a
                                        >
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay ruyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hayruyện hay truyện hay truyện hay
                                        truyện hay truyện hayruyện hay truyện h
                                        ay truyện hay truyện hay truyện hayruyện
                                        hay tru yện hay truyện hay truyện hay
                                        truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-up info-icon rate-up"
                                            ></i>
                                            0
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-down info-icon rate-down"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <div class="user--discussion col">
                                    <p class="users">
                                        <a href="javascript:void(0)"
                                            >kfc group</a
                                        >
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay ruyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hayruyện hay truyện hay truyện hay
                                        truyện hay truyện hayruyện hay truyện h
                                        ay truyện hay truyện hay truyện hayruyện
                                        hay tru yện hay truyện hay truyện hay
                                        truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-up info-icon rate-up"
                                            ></i>
                                            0
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-down info-icon rate-down"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <div class="user--discussion col">
                                    <p class="users">
                                        <a href="javascript:void(0)"
                                            >kfc group</a
                                        >
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay ruyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hayruyện hay truyện hay truyện hay
                                        truyện hay truyện hayruyện hay truyện h
                                        ay truyện hay truyện hay truyện hayruyện
                                        hay tru yện hay truyện hay truyện hay
                                        truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-up info-icon rate-up"
                                            ></i>
                                            0
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-down info-icon rate-down"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg" />
                                    </a>
                                </div>
                                <div class="user--discussion col">
                                    <p class="users">
                                        <a href="javascript:void(0)"
                                            >kfc group</a
                                        >
                                        <span>bá tánh bình dân</span>
                                    </p>
                                    <p class="comments">
                                        truyện hay truyện hay truyện hay truyện
                                        hay truyện hay truyện hay ruyện hay
                                        truyện hay truyện hay truyện hay truyện
                                        hayruyện hay truyện hay truyện hay
                                        truyện hay truyện hayruyện hay truyện h
                                        ay truyện hay truyện hay truyện hayruyện
                                        hay tru yện hay truyện hay truyện hay
                                        truyện hay
                                    </p>
                                    <p class="info--wrap">
                                        <span>2 hrs</span>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-up info-icon rate-up"
                                            ></i>
                                            0
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i
                                                class="fa-solid fa-square-caret-down info-icon rate-down"
                                            ></i>
                                            0
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </li>
                    </ul>

                    @*
                    <p class="go--discuss">
                        <a href="javascript:void(0)">Thêm đánh giá</a>
                    </p>
                    *@
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "bookNavRate",
};
</script>

<style></style>

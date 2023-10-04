<template>
    <div class="control-area-wrap">
        <ul class="list-group control-area">
            <li class="list-group-item control-title">
                <a href="javascript:void(0)" onclick="openTool(this)">
                    <i class="fa-solid fa-list-ul"></i>
                </a>
                <div class="panel-catalog hidden d-none">
                    <a
                        href="javascript:void(0)"
                        onclick="closeTool(this)"
                        class="closemark"
                    >
                        <i class="fa-solid fa-xmark"></i>
                    </a>
                    <div class="catalog-direct">
                        <a href="" type="button" class="btn">
                            <i class="fa-solid fa-arrow-left"></i>
                            <span>Chương trước</span>
                        </a>
                        <a href="" type="button" class="btn">
                            <span>Chương sau</span>
                            <i class="fa-solid fa-arrow-right"></i>
                        </a>
                    </div>

                    <div class="catalog-chapter">
                        <ul
                            class="list-group list-group-horizontal row"
                            id="list-chapter-box"
                        >
                            <li class="list-group-item col-6">
                                <a href="/html/doctruyen.html"
                                    >Chương 1: Vương trường sinh</a
                                >
                            </li>
                            <li class="list-group-item col-6">
                                <a href="/html/doctruyen.html"
                                    >Chương 1: Vương trường sinh</a
                                >
                            </li>
                            <li class="list-group-item col-6">
                                <a href="/html/doctruyen.html"
                                    >Chương 1: Vương trường sinh</a
                                >
                            </li>
                            <li class="list-group-item col-6">
                                <a href="/html/doctruyen.html"
                                    >Chương 1: Vương trường sinh</a
                                >
                            </li>
                            <li class="list-group-item col-6">
                                <a href="/html/doctruyen.html"
                                    >Chương 1: Vương trường sinh</a
                                >
                            </li>
                            <li class="list-group-item col-6">
                                <a href="/html/doctruyen.html"
                                    >Chương 1: Vương trường sinh</a
                                >
                            </li>
                        </ul>
                    </div>
                </div>
            </li>
            <li class="list-group-item control-title">
                <a href="javascript:void(0)" onclick="openTool(this)">
                    <i class="fa-solid fa-gear"></i>
                </a>
                <div class="panel-catalog hidden d-none setting-box-wrap">
                    <a
                        href="javascript:void(0)"
                        onclick="closeTool(this)"
                        class="closemark"
                    >
                        <i class="fa-solid fa-xmark"></i>
                    </a>
                    <h4>Tùy chỉnh</h4>
                    <div class="setting-box row">
                        <div class="col-2 setting-box-title">
                            <h5>Theme</h5>
                        </div>
                        <div class="col-10 setting-box-option">
                            <span
                                class="theme-value value-01 active"
                                onclick="changeTheme('01')"
                            >
                                <i
                                    class="fa-solid fa-check"
                                    aria-hidden="true"
                                ></i>
                            </span>
                            <span
                                class="theme-value value-02"
                                onclick="changeTheme('02')"
                            >
                                <i
                                    class="fa-solid fa-check"
                                    aria-hidden="true"
                                ></i>
                            </span>
                            <span
                                class="theme-value value-03"
                                onclick="changeTheme('03')"
                            >
                                <i
                                    class="fa-solid fa-check"
                                    aria-hidden="true"
                                ></i>
                            </span>
                            <span
                                class="theme-value value-04"
                                onclick="changeTheme('04')"
                            >
                                <i
                                    class="fa-solid fa-check"
                                    aria-hidden="true"
                                ></i>
                            </span>
                            <span
                                class="theme-value value-05"
                                onclick="changeTheme('05')"
                            >
                                <i
                                    class="fa-solid fa-check"
                                    aria-hidden="true"
                                ></i>
                            </span>
                            <span
                                class="theme-value value-06"
                                onclick="changeTheme('06')"
                            >
                                <i
                                    class="fa-solid fa-check"
                                    aria-hidden="true"
                                ></i>
                            </span>
                            <span
                                class="theme-value value-07"
                                onclick="changeTheme('07')"
                            >
                                <i class="fa-regular fa-moon"></i>
                            </span>
                        </div>
                    </div>
                    <div class="setting-box row">
                        <div class="col-2 setting-box-title">
                            <h5>Font chữ</h5>
                        </div>
                        <div class="col-10 setting-box-option">
                            <span
                                class="font-value font-01 active"
                                onclick="changeFont('01')"
                                ><span class="font-name">Roboto</span></span
                            >
                            <span
                                class="font-value font-02"
                                onclick="changeFont('02')"
                                ><span class="font-name">Times</span></span
                            >
                            <span
                                class="font-value font-03"
                                onclick="changeFont('03')"
                                ><span class="font-name">Arial</span></span
                            >
                            <span
                                class="font-value font-04"
                                onclick="changeFont('04')"
                                ><span class="font-name">Cambria</span></span
                            >
                        </div>
                    </div>
                    <div class="setting-box row">
                        <div class="col-2 setting-box-title">
                            <h5>Cỡ chữ</h5>
                        </div>
                        <div
                            class="col-10 setting-box-option no-justify box-size"
                        >
                            <span class="prev" onclick="changeSize(false)">
                                <em class="iconfont">A-</em>
                            </span>
                            <span class="lang">20</span>
                            <span class="next" onclick="changeSize(true)">
                                <em class="iconfont">A+</em>
                            </span>
                        </div>
                    </div>
                </div>
            </li>
            <li class="list-group-item control-title">
                <a href="/index.html" id="popover-btn3" class="btn"
                    ><i class="fa-regular fa-comment-dots"></i
                ></a>
            </li>
            <li class="list-group-item control-title">
                <a href="javascript:void(0)" id="popover-btn" class="btn"
                    ><i class="fa-solid fa-flag"></i
                ></a>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "chapterToolbar",
};
</script>

<style></style>

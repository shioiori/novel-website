<template>
    <div>
        <div class="control-area-wrap">
            <ul class="list-group control-area">
                <li
                    class="list-group-item control-title"
                    @click="toggleTool('catalog')"
                >
                    <a href="javascript:void(0)">
                        <i class="fa-solid fa-list-ul"></i>
                    </a>
                    <div
                        class="panel-catalog"
                        :class="{ 'hidden d-none': !showCatalog }"
                    >
                        <a href="javascript:void(0)" class="closemark">
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
                                <li
                                    class="list-group-item col-6"
                                    v-for="(item, index) in chapterArray"
                                    :key="index"
                                >
                                    <a href="/html/doctruyen.html"
                                        >Chương {{ item.chapNumb }}:
                                        {{ item.chapName }}</a
                                    >
                                </li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li
                    class="list-group-item control-title"
                    @click="toggleTool('settings')"
                >
                    <a href="javascript:void(0)">
                        <i class="fa-solid fa-gear"></i>
                    </a>
                    <div
                        class="panel-catalog setting-box-wrap"
                        :class="{ 'hidden d-none': !showSettings }"
                    >
                        <a href="javascript:void(0)" class="closemark">
                            <i class="fa-solid fa-xmark"></i>
                        </a>
                        <h4>Tùy chỉnh</h4>
                        <div class="setting-box row">
                            <div class="col-2 setting-box-title">
                                <h5>Theme</h5>
                            </div>
                            <div class="col-10 setting-box-option">
                                <span
                                    @click="changeTheme(theme.id)"
                                    v-for="theme in themes"
                                    :key="theme.id"
                                    :class="[
                                        'theme-value',
                                        `value-${theme.id}`,
                                        { active: theme.active },
                                    ]"
                                >
                                    <i
                                        v-if="theme.active"
                                        class="fa-solid fa-check"
                                        aria-hidden="true"
                                    ></i>
                                    <i
                                        v-else
                                        class="fa-regular fa-moon"
                                        aria-hidden="true"
                                    ></i>
                                </span>
                            </div>
                        </div>
                        <div class="setting-box row">
                            <div class="col-2 setting-box-title">
                                <h5>Font chữ</h5>
                            </div>
                            <div class="col-10 setting-box-option">
                                <span
                                    @click="changeFont(font.id)"
                                    v-for="font in fonts"
                                    :key="font.id"
                                    :class="[
                                        'font-value',
                                        `font-${font.id}`,
                                        { active: font.active },
                                    ]"
                                    ><span class="font-name">{{
                                        font.name
                                    }}</span></span
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
        <div class="box-chapters">
            <div class="box-chap">
                {{ chapterContent }}
            </div>

            <div class="box-ads">
                <p>Hãy nhấn like ở mỗi chương để ủng hộ dịch giả nhé</p>
                <div class="box-icon-section">
                    <div class="box-icon-section-left">
                        <a
                            href="javascript:void(0)"
                            @click="setChapterLike()"
                            id="chapter-like-btn"
                        >
                            <i class="fa-regular fa-thumbs-up"></i>
                            {{ chapterLikes }}
                        </a>
                        <a href="javascript:void(0)">
                            <i class="fa-solid fa-circle-dollar-to-slot"></i>
                            Donate
                        </a>
                    </div>
                    <div class="box-icon-section-right">
                        <a href="javascript:void(0)">
                            <i class="fa-solid fa-triangle-exclamation"></i>
                            Báo lỗi
                        </a>
                    </div>
                </div>
            </div>
            <div class="control-box">
                <div class="control-box-content">
                    <a href="">
                        <i class="fa-solid fa-angle-left"></i>
                        Chương trước
                    </a>

                    <a href="">
                        Chương sau
                        <i class="fa-solid fa-angle-right"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "boxChapter",
    data() {
        return {
            valueTheme: "",
            valueFlag: false,
            showCatalog: false,
            showSettings: false,
            chapterArray: [],
            themes: [
                { id: "01", active: true },
                { id: "02", active: false },
                { id: "03", active: false },
                { id: "04", active: false },
                { id: "05", active: false },
                { id: "06", active: false },
                { id: "07", active: false },
            ],
            fonts: [
                { id: "01", name: "Roboto", active: true },
                { id: "02", name: "Times", active: false },
                { id: "03", name: "Arial", active: false },
                { id: "04", name: "Cambria", active: false },
            ],
        };
    },
    props: {
        chapterContent: String,
        chapterLikes: Number,
    },
    methods: {
        async setChapterLike() {
            try {
                let url = `${apiPath}/interact/chapter/is-liked?chapterId=${this.$route.params.id}`;
                let res = (await axios.get(url)).data;
                console.log(res);
            } catch (e) {
                console.log(e);
            }
        },
        toggleTool(type) {
            if (type === "catalog") {
                this.showCatalog = !this.showCatalog;
                this.showSettings = false; // Close settings
            } else if (type === "settings") {
                this.showSettings = !this.showSettings;
                this.showCatalog = false; // Close catalog
            }
        },
        async fetchChapter() {
            try {
                let url = `${apiPath}/chapter/get-by-book-id?bookId=${this.bookId}`;
                let res = (await axios.get(url)).data;
                console.log(res);
                this.chapterArr = res.data;
            } catch (e) {
                console.log(e);
            }
        },
        changeTheme(name) {
            if (this.themes.find((theme) => theme.id === name).active) {
                return;
            }

            // Deactivate all themes
            this.themes.forEach((theme) => {
                theme.active = false;
            });

            // Activate the selected theme
            const selectedTheme = this.themes.find(
                (theme) => theme.id === name
            );
            selectedTheme.active = true;

            // Update the class for the box-chapters
            const boxChapters = document.querySelector(".box-chapters");
            boxChapters.classList.remove(
                "value-01",
                "value-02",
                "value-03",
                "value-04",
                "value-05",
                "value-06",
                "value-07"
            );
            boxChapters.classList.add(`value-${name}`);

            // Update other elements as needed
            if (name === "07") {
                const elementsToChange = document.querySelectorAll(
                    ".box-chap, .box-ads > p, .box-icon-section-left > a, .box-icon-section-right > a, .control-box-content a, .control-box-content a i"
                );
                elementsToChange.forEach((element) => {
                    element.classList.add("body-07");
                });
            } else {
                const elementsToChange = document.querySelectorAll(
                    ".box-chap, .box-ads > p, .box-icon-section-left > a, .box-icon-section-right > a, .control-box-content a, .control-box-content a i"
                );
                elementsToChange.forEach((element) => {
                    element.classList.remove("body-07");
                });
            }
        },
        changeFont(name) {
            if (
                this.$el
                    .querySelector(".font-" + name)
                    .classList.contains("active")
            ) {
                return;
            }

            // Deactivate all font styles
            const fontValues = this.$el.querySelectorAll(".font-value");
            fontValues.forEach((fontValue) => {
                fontValue.classList.remove("active");
            });

            // Activate the selected font style
            const selectedFont = this.$el.querySelector(".font-" + name);
            selectedFont.classList.add("active");

            // Update the class for box-chap
            const elementsToChange = this.$el.querySelectorAll(
                ".box-chap, .box-ads > p, .box-icon-section-left > a, .box-icon-section-right > a, .control-box-content a, .control-box-content a i"
            );
            elementsToChange.forEach((element) => {
                element.classList.remove(
                    "font-01",
                    "font-02",
                    "font-03",
                    "font-04"
                );
                element.classList.add("font-" + name);
            });
        },
    },
    created() {
        this.fetchChapter();
    },
};
</script>

<style>
.control-box-content a i {
    color: inherit !important;
}
</style>

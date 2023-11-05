<template>
    <div class="rank-box-list col-3">
        <div class="rank-box-item-box">
            <h4>Tình trạng</h4>
            <ul class="nav nav-pills" id="filter-status">
                <li
                    class="nav-item"
                    data-temp-value="view"
                    v-for="(item, index) in criteria1"
                    :key="index"
                    :class="{ selected: bookStatuses.includes(item[1]) }"
                >
                    <a @click="toggleBookStatuses(item[1])">{{ item[0] }}</a>
                </li>
            </ul>
        </div>

        <div class="rank-box-item-box">
            <h4>Xếp hạng</h4>
            <ul class="nav nav-pills" id="filter-rank">
                <li
                    class="nav-item"
                    data-temp-value="view"
                    v-for="(item, index) in criteria2"
                    :key="index"
                    :class="{ selected: item[1] === InteractionType }"
                >
                    <a @click="toggleInteractionType(item[1])">{{ item[0] }}</a>
                </li>
            </ul>
        </div>

        <div class="rank-box-item-box">
            <h4>Số chương</h4>
            <ul class="nav nav-pills" id="filter-chapter">
                <li
                    class="nav-item"
                    data-temp-value="view"
                    v-for="(item, index) in criteria3"
                    :key="index"
                    :class="{ selected: ChapterRange.includes(item[1]) }"
                >
                    <a @click="toggleChapterRange(item[1])">{{ item[0] }}</a>
                </li>
            </ul>
        </div>

        <div class="rank-box-item-box">
            <h4>Sắp xếp theo</h4>
            <ul class="nav nav-pills" id="filter-sortby">
                <li
                    class="nav-item"
                    data-temp-value="view"
                    v-for="(item, index) in criteria4"
                    :key="index"
                    :class="{ selected: item[1] === OrderBy }"
                >
                    <a @click="toggleOrderBy(item[1])">{{ item[0] }}</a>
                </li>
            </ul>
        </div>

        <div class="rank-box-item-box">
            <h4>Tags</h4>
            <ul class="nav nav-pills" id="filter-tags">
                <li
                    class="nav-item"
                    data-temp-value="view"
                    v-for="(item, index) in tagID"
                    :key="index"
                    :class="{ selected: TagIds.includes(item.tagId) }"
                >
                    <a @click="toggleTagIds(item.tagId)">{{ item.tagName }}</a>
                </li>
            </ul>
        </div>

        <button
            type="submit"
            class="btn btn-primary btn-filter"
            @click="getBookByFilter()"
        >
            Lọc truyện
            <i class="fa-solid fa-chevron-right"></i>
        </button>
    </div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;

export default {
    name: "filterRanklist",
    data() {
        return {
            criteria1: [
                ["Toàn bộ", ""],
                ["Đang ra", "contiep"],
                ["Hoàn thành", "hoanthanh"],
                ["Tạm ngưng", "tamngung"],
            ],
            criteria2: [
                ["Xem nhiều", 1],
                ["Đề cử", 2],
                ["Theo dõi", 3],
                ["Yêu thích", 4],
                ["Bình luận", 5],
            ],
            criteria3: [
                ["< 300", 299],
                ["300 - 1000", 999],
                ["1000 - 2000", 1999],
                ["> 2000", 9999],
            ],
            criteria4: [
                ["Mới nhất", 1],
                ["Cũ nhất", 2],
            ],
            tagID: [],
            bookStatuses: [],
            uploadStatus: [],
            CategoryIds: [],
            ChapterRange: [],
            AuthorIds: [],
            TagIds: [],
            InteractionType: "",
            OrderBy: "",
        };
    },
    created() {
        this.fetchTagId();
    },
    methods: {
        async fetchTagId() {
            try {
                let url = `${apiPath}/tag/get-all`;
                let res = (await axios.get(url)).data;
                console.log(res, "lay tag");
                this.tagID = res;
            } catch (e) {
                console.log(e);
            }
        },
        async getBookByFilter() {
            try {
                let url = `${apiPath}/book/get-by-filter`;
                let requestData = {
                    BookStatuses: this.bookStatuses,
                    UploadStatuses: this.uploadStatus,
                    CategoryIds: this.CategoryIds,
                    ChapterRange: this.chapterRange,
                    AuthorIds: this.AuthorIds,
                    TagIds: this.TagIds,
                    InteractionType: this.InteractionType,
                    OrderBy: this.OrderBy,
                };
                let requestDataJSON = JSON.stringify(requestData);
                console.log(requestDataJSON)
                let res = (
                    await axios.request({
                        url: url,
                        method: "GET",
                        data: requestDataJSON,
                        headers: {
                            "Content-Type": "application/json",
                        },
                    })
                ).data;
                console.log(res);
                this.$store.dispatch("setBookArr", res);
            } catch (e) {
                console.log(e);
            }
        },
        toggleBookStatuses(bookStatus) {
            if (this.bookStatuses.includes(bookStatus)) {
                this.bookStatuses = this.bookStatuses.filter(
                    (i) => i !== bookStatus
                );
            } else {
                this.bookStatuses.push(bookStatus);
            }
        },
        toggleChapterRange(chapterRange) {
            if (this.ChapterRange.includes(chapterRange)) {
                this.ChapterRange = this.ChapterRange.filter(
                    (i) => i !== chapterRange
                );
            } else {
                this.ChapterRange.push(chapterRange);
            }
        },
        toggleInteractionType(interaction) {
            if (interaction == this.InteractionType) {
                this.InteractionType = "";
            } else {
                this.InteractionType = interaction;
            }
        },
        toggleOrderBy(date) {
            if (date == this.OrderBy) {
                this.OrderBy = "";
            } else {
                this.OrderBy = date;
            }
        },
        toggleTagIds(tagid) {
            if (this.TagIds.includes(tagid)) {
                this.TagIds = this.TagIds.filter((i) => i !== tagid);
            } else {
                this.TagIds.push(tagid);
            }
        },
    },
};
</script>

<style>
.nav-item:hover {
    cursor: pointer;
}

.selected {
    background: #0a58ca;
    color: #fff;
}
</style>

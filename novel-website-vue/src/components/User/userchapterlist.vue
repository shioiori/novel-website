<template>
    <div>
        <div class="col-md-12" v-if="tabIndex == 1">
            <div class="row" style="padding: 0 10px">
                <div class="reading col-md-6">
                    <span>Danh sách chương</span>
                </div>
                <div class="col-md-6">
                    <div class="userchapterlist float-end">
                        <a @click="$emit('tabChange')" class="btn btn-secondary"
                            >Quay lại</a
                        >
                        <a
                            @click="handleTabChange(2)"
                            class="btn btn-secondary"
                            >Thêm chương</a
                        >
                    </div>
                </div>

                <div class="col-md-12" style="padding-top: 10px">
                    <div class="table-responsive">
                        <table class="table border mb-0 table-striped">
                            <thead>
                                <tr class="align-middle table-dark">
                                    <th>STT</th>
                                    <th>Tên chương</th>
                                    <th>Lượt xem</th>
                                    <th>Yêu thích</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr
                                    class="align-middle"
                                    v-for="(item, index) in chapterArr"
                                    :key="index"
                                >
                                    <td>
                                        <div>{{ index }}</div>
                                    </td>
                                    <td>
                                        <div>{{ item.ChapterName }}</div>
                                    </td>
                                    <td>
                                        <div>{{ item.Views }}</div>
                                    </td>
                                    <td>
                                        <div>{{ item.Likes }}</div>
                                    </td>
                                    <td>
                                        <div class="float-end userchapterlist">
                                            <a
                                                @click="handleTabChangeFix(3, item)"
                                                class="btn btn-secondary"
                                                >Sửa</a
                                            >
                                            <a
                                                href=""
                                                onclick="DeleteChapter(@item.ChapterId)"
                                                class="btn btn-secondary"
                                                >Xóa</a
                                            >
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <Usercreatechapter v-if="tabIndex == 2" @tabChange="handleTabChange(1)"></Usercreatechapter>
        <Userfixchapter v-if="tabIndex == 3" :receiveData="itemToSend" @tabChange="handleTabChange(1)"></Userfixchapter>
    </div>
</template>

<script>
import Usercreatechapter from "./usercreatechapter.vue";
import Userfixchapter from "./userfixchapter.vue";

export default {
    name: "userchapter-list",
    data() {
        return {
            tabIndex: 1,
            chapterArray: this.chapterArr,
            itemToSend: null,
        }
    },
    props: {
        chapterArr: Array,
    },
    components: { Usercreatechapter, Userfixchapter },
    methods: {
        handleTabChange(index) {
            this.tabIndex = index;
            window.scrollTo(0, 0)
        },
        handleTabChangeFix(index, item) {
            this.tabIndex = index;
            this.itemToSend = item;
            window.scrollTo(0, 0)
        },
    }
};
</script>

<style>
.userchapterlist.float-end a:first-child {
    margin-right: 0.5rem;
}
</style>

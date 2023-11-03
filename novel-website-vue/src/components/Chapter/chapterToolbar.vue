<template>
    <div></div>
</template>

<script>
import axios from "axios";
const apiPath = process.env.VUE_APP_API_KEY;
import { EventBus } from "../../main"; 

export default {
    name: "chapterToolbar",
    data() {
        return {
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
        };
    },
    created() {
        this.fetchChapter();
    },
    methods: {
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
            let activeTheme = this.themes.find((theme) => theme.active);
            if (activeTheme.id !== name) {
                activeTheme.active = false;
                let selectedTheme = this.themes.find(
                    (theme) => theme.id === name
                );
                selectedTheme.active = true;

                if (name === "07") {
                    // Add your logic for theme 07 here
                    // You can modify the class or apply CSS styles as needed
                } else {
                    EventBus.$emit('updateTheme', 'value-'+ activeTheme.id, true)
                }
            }
        },
    },
};
</script>

<style></style>

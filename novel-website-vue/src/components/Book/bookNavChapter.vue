<template>
    <div class="book--chapter tab-pane container fade" id="book--chapter-id">
        <div class="book--chapter-wrap">
            <div class="volume">
                <h4>Danh sách chương</h4>
                <ul
                    class="list-group list-group-horizontal row"
                    id="list-chuong"
                >
                    <li class="list-group-item col-4">
                        <a href="/html/doctruyen.html"
                            >Chương 1: Vương trường sinh</a
                        >
                    </li>
                </ul>
            </div>
            <div class="book--pagination">
                <ul class="pagination justify-content-end">
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">1</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">2</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">3</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">4</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">5</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">571</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">572</a>
                    </li>
                    <li class="page-item">
                        <a class="page-link" href="javascript:void(0)">
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "bookNavChapter",
};
</script>

<style></style>

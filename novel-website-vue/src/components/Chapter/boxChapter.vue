<template>
  <div class="box-chapters">
                <div class="box-chap">
                    @Html.Raw(HttpUtility.HtmlDecode(Model.Content))
                </div>

                <div class="box-ads">
                    <p>Hãy nhấn like ở mỗi chương để ủng hộ dịch giả nhé</p>
                    <div class="box-icon-section">
                        <div class="box-icon-section-left">
                            <a
                                href="javascript:void(0)"
                                onclick="onClickBtnLikeChapter(this)"
                                id="chapter-like-btn"
                            >
                                <i class="fa-regular fa-thumbs-up"></i>
                                @Model.Likes
                            </a>
                            @*
                            <a href="javascript:void(0)">
                                <i
                                    class="fa-solid fa-circle-dollar-to-slot"
                                ></i>
                                Donate </a
                            >*@
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
</template>

<script>
export default {
    name: 'boxChapter'
}
</script>

<style>

</style>
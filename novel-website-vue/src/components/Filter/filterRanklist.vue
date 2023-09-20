<template>
  <div class="rank-box-list col-3">
                <form method="post" action="/Filter/Index">
                    <div class="rank-box-item-box">
                        <h4>Tình trạng</h4>
                        <ul class="nav nav-pills" id="filter-status">
                            <li class="nav-item">
                                <a href="javascript:void(0)">Toàn bộ</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đang ra</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Hoàn thành</a>
                            </li>
                        </ul>
                    </div>

                    <div class="rank-box-item-box">
                        <h4>Xếp hạng</h4>
                        <ul class="nav nav-pills" id="filter-rank">
                            <li class="nav-item" data-temp-value="view">
                                <a href="javascript:void(0)">Xem nhiều</a>
                            </li>
                            <li class="nav-item" data-temp-value="recommend">
                                <a href="javascript:void(0)">Đề cử</a>
                            </li>
                            <li class="nav-item" data-temp-value="like">
                                <a href="javascript:void(0)">Yêu thích</a>
                            </li>
                            <li class="nav-item" data-temp-value="follow">
                                <a href="javascript:void(0)">Theo dõi</a>
                            </li>
                            <li class="nav-item" data-temp-value="comment">
                                <a href="javascript:void(0)">Bình luận</a>
                            </li>
                        </ul>
                    </div>

                    <div class="rank-box-item-box">
                        <h4>Số chương</h4>
                        <ul class="nav nav-pills" id="filter-chapter">
                            <li class="nav-item" data-temp-value="299">
                                <a href="javascript:void(0)">&lt; 300</a>
                            </li>
                            <li class="nav-item" data-temp-value="999">
                                <a href="javascript:void(0)">300 - 1000</a>
                            </li>
                            <li class="nav-item" data-temp-value="1999">
                                <a href="javascript:void(0)">1000 - 2000</a>
                            </li>
                            <li class="nav-item" data-temp-value="99999">
                                <a href="javascript:void(0)">&gt; 2000</a>
                            </li>
                        </ul>
                    </div>

                    <div class="rank-box-item-box">
                        <h4>Sắp xếp theo</h4>
                        <ul class="nav nav-pills" id="filter-sortby">
                            <li class="nav-item" data-temp-value="new">
                                <a href="javascript:void(0)">Mới nhất</a>
                            </li>
                            <li class="nav-item" data-temp-value="old">
                                <a href="javascript:void(0)">Cũ nhất</a>
                            </li>
                        </ul>
                    </div>

                    <div class="rank-box-item-box">
                        <h4>Tags</h4>
                        <ul class="nav nav-pills" id="filter-tags">
                            <li class="nav-item">
                                <a href="javascript:void(0)">Cô nhi</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đạo tặc</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đặc công</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Cô nhi</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đạo tặc</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đặc công</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Cô nhi</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đạo tặc</a>
                            </li>
                            <li class="nav-item">
                                <a href="javascript:void(0)">Đặc công</a>
                            </li>
                        </ul>
                    </div>

                    <button type="submit" class="btn btn-primary btn-filter">
                        Lọc truyện
                        <i class="fa-solid fa-chevron-right"></i>
                    </button>
                </form>
            </div>
</template>

<script>
export default {
    name: 'filterRanklist'
}
</script>

<style>

</style>
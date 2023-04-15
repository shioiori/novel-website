$.ajax({
    url: "/Banner/GetMainBanner",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        // k xài empty html với carousel k nó sẽ lỗi
        //$('#categories').html('');
        data.forEach(function (item, index) {
            var link = "";
            if (item.book != null) {
                link = `/truyen/${item.book.slug}-${item.bookId}`;
            }
            let row = `<div class="carousel-item active">
                            <img src="${item.bannerImage}" alt="Los Angeles" class="d-block w-100"><a href="${link}"></a></img>
                        </div>`;
            $('#banner-carousel').append(row);
            //$('#categories').append(row);
        });
        $('#banner-carousel').trigger('refresh.owl.carousel');
    },
    error: function () { },
    complete: function () { }
});


$.ajax({
    url: "/Home/GetAllCategories",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('.index__theloai--wrap').html('');
        let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });
        data.forEach((item, index) => {
            row.append(`<div class="index__theloai--chitiet-cot col-md-6">
                                    <a href="/bo-loc?categoryId=${item.categoryId}">
                                        <img src="${item.categoryImage}"/>
                                        <span>
                                            <p class="tentruyen">${item.categoryName}</p>
                                            <p class="soluongtruyen">${item.quantity}</p>
                                        </span>
                                    </a>
                                </div>`);
            if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetPosts?number=9",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#new-posts').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item ${index % 2 ? " odd" : ""}">
            <i class="fa-solid fa-share"></i>
            <a href="/tin-tuc/${item.slug}-${item.postId}">${item.title}</a>
                                </li>`;
            $('#new-posts').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetChapterUpdated",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#new-chapters').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-book-open"></i>
                            <a href="/truyen/${item.book.slug}-${item.book.bookId}">${item.book.bookName}</a>
                            <span class="index__truyenmoi--chuong">Chapter ${item.chapterNumber}</span>
                        </li>`;
            $('#new-chapters').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetEditorRecommends",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#editor-recommend').html('');
        let row = jQuery('<div>', {
            class: 'index__right-wrap--list row',
        });
        data.forEach((item, index) => {
            var introduce = $('<textarea />').html(item.introduce).text();
            row.append(`<div class="index__right-wrap--listitem col-md-6">
                    <div class="book--img">
                        <a href="/truyen/${item.slug}-${item.bookId}">
                            <img src="${item.avatar}" class="book--imgcss">
                        </a>
                    </div>
                    <div class="book--info">
                        <div class="book-name">
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                        </div>
                        <div class="book-state">
                            <a href="/tac-gia/${item.author.authorId}/${item.author.slug}">${item.author.authorName}</a >
                        </div>
                        <p class="book-status">
                            <em>
                                <span class="chapters">${item.numberOfChapters}</span >
                            </em>
                            <cite>Chương</cite>
                            <i>|</i>
                            <em>
                                <span class="views">${item.views}</span >
                            </em>
                            <cite>Lượt xem</cite>
                        </p>
                        <div class="category">
                            <p>Thể loại:</p>
                            <p class="category-wrap">
                                <a href="/bo-loc?categoryId=${item.categoryId}">${item.category.categoryName}</a >
                            </p>
                        </div>
                        <div class="describe">
                            <i class="fa-solid fa-quote-left"></i>
                            ${introduce.replace(/<\/?[^>]+(>|$)/g, "").replace(/<\/?[^>]+(>|$)/g, "")}
                        </div>
                    </div>
                </div>`);
            if (index % 2 == 1) {
                $('#editor-recommend').append(row);
                row = jQuery('<div>', {
                    class: 'index__right-wrap--list row',
                });;
            }
        });
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Home/GetMostRecommends",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-recommends').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-recommends').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetMostViews",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-views').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-views').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetMostLikes",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-likes').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-likes').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetMostFollows",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-follows').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-follows').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetNewBooks",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#newbook-avatar').html('');
        $('#newbook').html('');
        let row = jQuery('<div>', {
            class: 'index__right-wrap--list row',
        });
        data.forEach((item, index) => {
            var introduce = $('<textarea />').html(item.introduce).text();
            if (index == 0) {
                $('#newbook-avatar').append(`<div class="index__left-wrap-detail card">
                                <img class="card-img-top" src="${item.avatar}" alt="Card image">
                                <div class="card-body">
                                    <h4 class="card-title">
                                        <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                    </h4>
                                    <p class="card-text index__left-wrap--theloai">${item.category.categoryName}</p >
                                    <p class="card-text index__left-wrap--sochuong">${item.numberOfChapters} Chương</p >
                                    <p class="card-text index__left-wrap--gioithieu">
                                        <i>
                                            ${introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0,255)}
                                        </i>
                                    </p>
                                    <a href="/truyen/${item.slug}-${item.bookId}" class="btn btn-primary index__left-wrap--cardbtn">
                                        Đọc truyện
                                        <i class="fa-solid fa-chevron-right"></i>
                                    </a>
                                </div>
                            </div>`);
            }
            else {
                row.append(`<div class="index__right-wrap--listitem col-md-4">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="/tac-gia/${item.author.authorId}/${item.author.slug}">${item.author.authorName}</a >
                                </div>
                                <p class="book-status">
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="/bo-loc?categoryId=${item.categoryId}">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                        ${introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0, 100)}
                                </div>
                            </div>
                        </div>`);
                if (index % 3 == 0) {
                    $('#newbook').append(row);
                    row = jQuery('<div>', {
                        class: 'index__right-wrap--list row',
                    });
                }
            }
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetFinishedBooks",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#finishbook-avatar').html('');
        $('#finishbook').html('');
        let row = jQuery('<div>', {
            class: 'index__right-wrap--list row',
        });
        data.forEach((item, index) => {
            var introduce = $('<textarea />').html(item.introduce).text();
            if (index == 0) {
                $('#finishbook-avatar').append(`<div class="index__left-wrap-detail card">
                                <img class="card-img-top" src="${item.avatar}" alt="Card image">
                                <div class="card-body">
                                    <h4 class="card-title">
                                        <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                    </h4>
                                    <p class="card-text index__left-wrap--theloai">${item.category.categoryName}</p >
                                    <p class="card-text index__left-wrap--sochuong">${item.numberOfChapters} chương</p >
                                    <p class="card-text index__left-wrap--gioithieu">
                                        <i>
                                            ${introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0, 255)}
                                        </i>
                                    </p>
                                    <a href="/truyen/${item.slug}-${item.bookId}" class="btn btn-primary index__left-wrap--cardbtn">
                                        Đọc truyện
                                        <i class="fa-solid fa-chevron-right"></i>
                                    </a>
                                </div>
                            </div>`);
            }
            else {
                row.append(`<div class="index__right-wrap--listitem col-md-4">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="/tac-gia/${item.author.authorId}/${item.author.slug}">${item.author.authorName}</a >
                                </div>
                                <p class="book-status">
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="/bo-loc?categoryId=${item.categoryId}">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                        ${introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0, 100)}
                                </div>
                            </div>
                        </div>`);
                if (index % 3 == 0) {
                    $('#finishbook').append(row);
                    row = jQuery('<div>', {
                        class: 'index__right-wrap--list row',
                    });
                }
            }
        });
    },
    error: function () { },
    complete: function () { }
})

/* Mobile */

$.ajax({
    url: "/Home/GetEditorRecommends",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        data.forEach((item, index) => {
            var introduce = $('<textarea />').html(item.introduce).text();
            $('#editor-recommend-mobile').append(`
                <div class="carousel-item">
                    <div class="index__right-wrap--list row">
                        <div class="index__right-wrap--listitem">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="/tac-gia/${item.author.authorId}/${item.author.slug}">${item.author.authorName}</a >
                                </div>
                                <p class="book-status">
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="/bo-loc?categoryId=${item.categoryId}">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                    ${introduce.replace(/<\/?[^>]+(>|$)/g, "").replace(/<\/?[^>]+(>|$)/g, "")}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`);
        });
        $("#editor-recommend-mobile .carousel-item").first().addClass("active");
        $('#editor-recommend-mobile').trigger('refresh.owl.carousel');
        
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetNewBooks",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        data.forEach((item, index) => {
            var introduce = $('<textarea />').html(item.introduce).text();
            $('#new-book-mobile').append(`
                <div class="carousel-item">
                    <div class="index__right-wrap--list row">
                        <div class="index__right-wrap--listitem">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="/tac-gia/${item.author.authorId}/${item.author.slug}">${item.author.authorName}</a >
                                </div>
                                <p class="book-status">
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="/bo-loc?categoryId=${item.categoryId}">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                    ${introduce.replace(/<\/?[^>]+(>|$)/g, "").replace(/<\/?[^>]+(>|$)/g, "")}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`);
        });
        $("#new-book-mobile .carousel-item").first().addClass("active");
        $('#new-book-mobile').trigger('refresh.owl.carousel');

    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetFinishedBooks",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        data.forEach((item, index) => {
            var introduce = $('<textarea />').html(item.introduce).text();
            $('#finish-book-mobile').append(`
                <div class="carousel-item">
                    <div class="index__right-wrap--list row">
                        <div class="index__right-wrap--listitem">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="/tac-gia/${item.author.authorId}/${item.author.slug}">${item.author.authorName}</a >
                                </div>
                                <p class="book-status">
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="/bo-loc?categoryId=${item.categoryId}">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                    ${introduce.replace(/<\/?[^>]+(>|$)/g, "").replace(/<\/?[^>]+(>|$)/g, "")}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`);
        });
        $("#finish-book-mobile .carousel-item").first().addClass("active");
        $('#finish-book-mobile').trigger('refresh.owl.carousel');

    },
    error: function () { },
    complete: function () { }
})
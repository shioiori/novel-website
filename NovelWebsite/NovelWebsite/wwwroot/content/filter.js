$.ajax({
    url: "/Filter/GetAllTags",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    context: this,
    success: function (data) {
        $('#filter-tags').html("");
        data.forEach((item, index) => {
            let row = ` <li class="nav-item" data-temp-value="${item.tagId}">
                            <a href="javascript:void(0)">${item.tagName}</a>
                        </li>`;
            $('#filter-tags').append(row);
        });
    },
    error: function () { },
    complete: function () { }
});

$.ajax({
    url: "/Filter/GetBookStatuses",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    context: this,
    success: function (data) {
        $('#filter-status').html("");
        data.forEach((item, index) => {
            let row = `<li class="nav-item" data-temp-value="${item.bookStatusId}">
                            <a href="javascript:void(0)">${item.bookStatusName}</a>
                        </li>`;
            $('#filter-status').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetAllCategories",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#type-list').html(`<i>·</i>`);
        data.forEach((item, index) => {
            let row = `<a href="/bo-loc?categoryId=${item.categoryId}" onclick="typeListClick(this)">${item.categoryName}</a><i>·</i>`;
            $('#type-list').append(row);
        });
    },
    error: function () { },
    complete: function () { }
});



function getDataTempValue(domList) {
    var list = [];
    for (var i = 0; i < domList.length; i++) {
        list.push(domList[i].getAttribute('data-temp-value'));
    }
    return list;
}


$('.btn-filter').on('click', function (e) {
    e.preventDefault();
    var bookStatus = getDataTempValue(document.getElementById("filter-status").getElementsByClassName("box-active"));
    var rank = getDataTempValue(document.getElementById("filter-rank").getElementsByClassName("box-active"));
    var chapter = getDataTempValue(document.getElementById("filter-chapter").getElementsByClassName("box-active"));
    var sort_by = getDataTempValue(document.getElementById("filter-sortby").getElementsByClassName("box-active"));
    var tag = getDataTempValue(document.getElementById("filter-tags").getElementsByClassName("box-active"));
    console.log(bookStatus);
    console.log(rank);
    console.log(chapter);
    console.log(sort_by);
    console.log(tag);

    var data = {
        Category: categoryId,
        BookStatus: bookStatus,
        Rank: rank[0],
        ChapterRange: chapter,
        OrderBy: sort_by[0],
        Tag: tag
    };

    var form = $('<form>').attr('action', '/bo-loc')
        .attr('method', 'post');

    $('<input>').attr('type', 'hidden')
        .attr('name', 'Category')
        .attr('value', data.Category)
        .appendTo(form);

    bookStatus.forEach(function (item, index) {
        $('<input>').attr('type', 'hidden')
            .attr('name', 'BookStatus')
            .attr('value', item)
            .appendTo(form);
    });

    $('<input>').attr('type', 'hidden')
        .attr('name', 'Rank')
        .attr('value', data.Rank)
        .appendTo(form);

    chapter.forEach(function (item, index) {
        $('<input>').attr('type', 'hidden')
            .attr('name', 'ChapterRange')
            .attr('value', item)
            .appendTo(form);
    });

    $('<input>').attr('type', 'hidden')
        .attr('name', 'OrderBy')
        .attr('value', data.OrderBy)
        .appendTo(form);

    tag.forEach(function (item, index) {
        $('<input>').attr('type', 'hidden')
            .attr('name', 'Tag')
            .attr('value', item)
            .appendTo(form);
    });

    form.appendTo('body').submit();


    /*$.ajax({
        url: "/Filter/Index",
        type: "POST",
        data: {
            Category: categoryId,
            BookStatus: bookStatus,
            Rank: rank[0],
            ChapterRange: chapter,
            OrderBy: sort_by[0],
            Tag: tag
        },
        dataType: "html",
        beforeSend: function () { },
        success: function (data) {
            $('html').html(data);*/
          /*  $('#filter-book').html('');
            data.forEach((item, index) => {
                var introduce = $('<textarea />').html(item.introduce).text();
                let row = `<li class="list-group-item">
                                    <div class="book--img">
                                        <a href="/truyen/${item.slug}-${item.bookId}">
                                            <img src="${item.avatar}" class="book--imgcss">
                                        </a>
                                    </div>
                                    <div class="book--info">
                                        <h3>
                                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                                        </h3>
                                        <div class="book-state">
                                            <a href="/tac-gia/${item.authorId}/${item.author.slug}">${item.author.authorName}</a>
                                            <i>|</i>
                                            <p>${item.bookStatus.bookStatusName}</p>
                                            <i>|</i>
                                            <p>${item.numberOfChapters} chương</p>
                                        </div>
                                        <div class="describe">
                                            ${introduce}
                                        </div>
                                    </div>
                                    <div class="book--info-buttons">
                                        <p>
                                            <a class="btn" href="/truyen/${item.slug}-${item.bookId}">Đọc truyện</a>
                                        </p>
                                    </div>
                                </li>`;
                $('#filter-book').append(row);
            });*/
       /* },
        error: function () { },
        complete: function () { }
    });*/
})

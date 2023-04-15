var isBookFav = false;
var isBookFollow = false;
var isBookRec = false;


function GetBookFav() {
    $.ajax({
        url: "/interact/get-book-fav/" + bookId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isBookFav = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function GetBookRec() {
    $.ajax({
        url: "/interact/get-book-rec/" + bookId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isBookRec = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function GetBookFollow() {
    $.ajax({
        url: "/interact/get-book-follow/" + bookId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isBookFollow = data;
        },
        error: function () { },
        complete: function () { }
    })
}


function UpdateBookFav() {
    $.ajax({
        url: "/interact/update-book-fav/" + bookId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateBookRec() {
    $.ajax({
        url: "/interact/update-book-rec/" + bookId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateBookFollow() {
    $.ajax({
        url: "/interact/update-book-follow/" + bookId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}


function onClickInfoBtn(el, index) {
    if (index == 1) {
        UpdateBookFav();
        if ($(el).hasClass("selected")) {
            $(el).removeClass("selected");
            $(el).text("Yêu thích");
        } else {
            $(el).addClass("selected");
            $(el).text("Bỏ yêu thích")
        }
    }
    if (index == 2) {
        UpdateBookFollow();
        if ($(el).hasClass("selected")) {
            $(el).removeClass("selected");
            $(el).text("Theo dõi");
        } else {
            $(el).addClass("selected");
            $(el).text("Bỏ theo dõi")
        }
    }
    if (index == 3) {
        UpdateBookRec();
        if ($(el).hasClass("selected")) {
            $(el).removeClass("selected");
            $(el).text("Đề cử");
        } else {
            $(el).addClass("selected");
            $(el).text("Bỏ đề cử")
        }
    }
    location.reload();
}
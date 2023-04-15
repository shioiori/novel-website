$.ajax({
    url: "/Banner/GetAdsBanner",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        var randomBanner = data[Math.floor(Math.random() * data.length)];
        $('.banner-sm').attr('src', randomBanner.bannerImage);
    },
    error: function () { },
    complete: function () { }
});

$.ajax({
    url: "/Account/GetAccount",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        if (data == "") return;
        $('div.col.login').html('');
        let user = GetUserInfo();
        let bar = `<div class="dropdown">
                        <button class="btn btn-secondary" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img src="${user.user.avatar}" class="user-home-img">
                            <div class="user-home-name"><p>${user.user.userName}</p></div>
                        </button>
                        <ul class="dropdown-menu user-function dropdown-menu-end" aria-labelledby="dropdownMenuButton1">
                            <li><a class="dropdown-item" href="/ho-so/${user.userId}">Hồ sơ</a></li>
                            <li><a class="dropdown-item" href="/ho-so/${user.userId}/tu-truyen">Tủ truyện</a></li>
                            <li><a class="dropdown-item" href="/ho-so/${user.userId}/truyen-da-dang">Truyện đã đăng</a></li>
                            <li><a class="dropdown-item" href="/dang-tai/${user.userId}/truyen">Đăng tải</a></li>
                        </ul>
                    </div>`;
        $('div.col.login').append(bar);
        if (data.role != 'Người dùng') {
            $('.user-function').append(`<li><a class="dropdown-item" href="/Admin">Quản trị</a></li>`);
        }
        $('.user-function').append(`<div class="dropdown-divider"></div>`);
        $('.user-function').append(`<li><a class="dropdown-item" href="/Account/Signout">Đăng xuất</a></li>`);
    },
    error: function () { },
    complete: function () { }
});

$.ajax({
    url: "/Chapter/GetAllCategories",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#chapter-category').html('');
        let row = jQuery('<ul>', {
            class: 'col-md-4',
        });
        let maxitem = Math.ceil(data.length / 3);
        data.forEach((item, index) => {
            row.append(`<li><a href="/bo-loc?categoryId=${item.categoryId}">${item.categoryName}</a></li>`);
            if ((index != 0 && index % maxitem == (maxitem - 1)) || index == data.length - 1) {
                $('#chapter-category').append(row);
                row = jQuery('<ul>', {
                    class: 'col-md-4',
                });
            }
        });
    },
    error: function () { },
    complete: function () { }
})

function GetUserInfo() {
    var user = "";
    $.ajax({
        url: "/Account/GetUser",
        async: false,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            user = data;
        },
        error: function () { },
        complete: function () { }
    });
    return user;
}

function Login() {
    $.ajax({
        url: "/Account/Login",
        type: "POST",
        dataType: "json",
        data: {
            AccountName: $('input[name="AccountName"]').val(),
            Password: $('input[name="Password"]').val()
        },
        beforeSend: function () { },
        success: function (data) {
            $('#modal-body-login').find('.alert-danger').first().remove();
            if (data == "") {
                location.reload();
            }
            else {
                $('#modal-body-login').prepend(`<div class="form-floating mb-3 mt-3 alert alert-danger" role="alert" id="login-alert">
                                            ${data}
                                            </div>`);
            }
        },
        error: function () { },
        complete: function () { }
    })
}


function Signup() {
    $.ajax({
        url: "/Account/Signup",
        type: "POST",
        dataType: "json",
        data: {
            AccountName: $('#signup-form input[name="AccountName"]').val(),
            Password: $('#signup-form input[name="Password"]').val(),
            Email: $('#signup-form input[name="Email"]').val()
        },
        beforeSend: function () { },
        success: function (data) {
            $('#modal-body-signup').find('.alert-danger').first().remove();
            if (data == "") {
                alert("Đăng ký thành công!");
                location.reload();
            }
            else {
                $('#modal-body-signup').prepend(`<div class="form-floating mb-3 mt-3 alert alert-danger" role="alert" id="login-alert">
                                            ${data}
                                            </div>`);
            }
        },
        error: function () { },
        complete: function () { }
    })
}

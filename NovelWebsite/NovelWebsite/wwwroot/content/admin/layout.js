function GetUserInfo() {
    var user = "";
    $.ajax({
        url: "/Account/GetUser",
        async: false,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            console.log(data);
            user = data;
        },
        error: function () { },
        complete: function () { }
    });
    return user;
}

$.ajax({
    url: "/Account/GetAccount",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        let user = GetUserInfo();
        $('.avatar-img').attr('src', user.user.avatar);
    },
    error: function () { },
    complete: function () { }
});
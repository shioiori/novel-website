/*function UpdateNotification(fromUserId, toUserId, typeId) {
    $.ajax({
        url: "/Notification/AddNotification",
        type: "POST",
        data: {
            FromUserId: fromUserId,
            ToUserId: toUserId,
            TypeId: typeId
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            GetListComment();
            var el = "#btn-reply-cmt-" + id;
            console.log(123);
            $(el).click();
        },
        error: function () { },
        complete: function () { }
    })
}*/
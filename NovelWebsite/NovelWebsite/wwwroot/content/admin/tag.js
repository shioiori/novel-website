
function AddOrUpdateTag(id) {
    $.ajax({
        url: "/Admin/Tag/AddOrUpdateTag?id=" + id,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            $('input[name="TagId"]').val(data.tagId);
            $('input[name="TagName"]').val(data.tagName);
        },
        error: function () { },
        complete: function () { }
    })
}
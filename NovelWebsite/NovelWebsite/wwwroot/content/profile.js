var imgPath = "";
var flag = "";


$("#profile-banner-image").css("background-image", 'url(' + coverPhoto + ')');

$(document).on('change', 'input[name="fileUpload"]', function () {
    let formData = new FormData();
    formData.append("file", $(this).prop("files")[0]);
    formData.append("folder", folder);
    $.ajax({
        url: "/Image/UploadFile",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        beforeSend: () => {

        },
        success: res => {
            imgPath = res;
            console.log(imgPath);
            if (flag == "avatar") {
                ChangeAvatar();
            }
            else {
                ChangeCoverPhoto();
            }
        },
        error: error => {
            console.log(error);
        }
    })
});


$('#change-cover-photo').on('click', function () {
    flag = "cover-photo";
    $('input[name="fileUpload"]').trigger('click');
})


$('#change-avatar').on('click', function () {
    flag = "avatar";
    $('input[name="fileUpload"]').trigger('click');
})

function ChangeAvatar() {
    $.ajax({
        url: "/User/UpdateAvatar",
        type: "GET",
        data: {
            userId: userId,
            avatar: imgPath
        },
        beforeSend: () => {

        },
        success: res => {
            $('#change-avatar').attr("src", res);
        },
        error: error => {
            console.log(error);
        }
    })
}

function ChangeCoverPhoto() {
    $.ajax({
        url: "/User/UpdateCoverPhoto",
        type: "GET",
        data: {
            userId: userId,
            coverPhoto: imgPath
        },
        beforeSend: () => {

        },
        success: res => {
            console.log(res);
            $("#profile-banner-image").css("background-image", 'url(' + res + ')');
        },
        error: error => {
            console.log(error);
        }
    })
}
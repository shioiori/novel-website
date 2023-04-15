var imgPath = "";

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
            $('img.input-img').attr("src", res);
            imgPath = res;
        },
        error: error => {
            console.log(error);
        }
    })
});
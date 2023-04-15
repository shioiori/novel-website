function onLoginByGoogle() {
    $.ajax({
        url: "/login-google",
        type: "GET",
        dataType: "json",
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
    });
}

function onSignUpByGoogle() {
    $.ajax({
        url: "/signup-google",
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            $('#modal-body-signup').find('.alert-danger').first().remove();
            if (data == "") {
                alert("Đăng ký thành công!");
                location.reload();
            else {
                $('#modal-body-signup').prepend(`<div class="form-floating mb-3 mt-3 alert alert-danger" role="alert" id="login-alert">
                                            ${data}
                                            </div>`);
            }
        },
        error: function () { },
        complete: function () { }
    });
}

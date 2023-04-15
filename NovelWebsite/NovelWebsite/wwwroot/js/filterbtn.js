/*$(document).ready(function () {
    $(".rank-box-item-box ul li").click(function () {
        var ele = $(this);
        ele.toggleClass("box-active");
        console.log(12314);
    });

    // $(".btn-filter").click(function(){
    //   $(".rank-box-item-box li").removeClass("box-active");
    // });
});*/

$(document).on("click", ".rank-box-item-box ul li", function () {
    var ele = $(this);
    ele.toggleClass("box-active");
    console.log(12314);
});

function typeListClick(el) {
    if ($(el).hasClass('active--type-list')) { }
    else {
        $(el).addClass('active--type-list');
        $('.type-list a').not($(el)).removeClass("active--type-list");
    }
};
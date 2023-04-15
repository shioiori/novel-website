function onClickSua(el) {
    if($(el).parent().parent().hasClass('d-none')) {}
    else {
        $(el).parent().parent().addClass('d-none');
        $(el).parent().parent().next().removeClass('d-none');
    }
}

function onClickLuu(el, index) {
    if(index == 1) {
        $(el).parent().addClass('d-none');
        $(el).parent().prev().removeClass('d-none');
        $('.editbook--chapter-title-content').text($('.editbook--chapter-title-fix').val());
    }
    if(index == 2) {
        $(el).parent().addClass('d-none');
        $(el).parent().prev().removeClass('d-none');
        $('.editbook--catagory-title-content').text($('.editbook--catagory-title-fix').val());
    }
    
}
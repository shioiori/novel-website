function changeTheme(name) {
    if($('.value-'+name).hasClass('active')){}
    else {
        $('.theme-value').removeClass('active');
        $('.box-chapters').removeClass('value-01');
        $('.box-chapters').removeClass('value-02');
        $('.box-chapters').removeClass('value-03');
        $('.box-chapters').removeClass('value-04');
        $('.box-chapters').removeClass('value-05');
        $('.box-chapters').removeClass('value-06');
        $('.box-chapters').removeClass('value-07');
        $('.box-chapters').addClass('value-'+name);
        $('span.value-'+name).addClass('active');
        if($('span.value-'+name).hasClass('value-07')){
            $('.box-chap, .box-ads>p, .box-icon-section-left>a, .box-icon-section-right>a').addClass('body-07')
        } else {
            $('.box-chap, .box-ads>p, .box-icon-section-left>a, .box-icon-section-right>a').removeClass('body-07')
        }
    }
}

function changeFont(name) {
    if($('.font-'+name).hasClass('active')){}
    else {
        $('.font-value').removeClass('active');
        $('.box-chap').removeClass('font-01');
        $('.box-chap').removeClass('font-02');
        $('.box-chap').removeClass('font-03');
        $('.box-chap').removeClass('font-04');
        $('.box-chap').addClass('font-'+name);
        $('span.font-'+name).addClass('active');
    }
}

function changeSize(flag) {
    var number = parseInt($('.box-size .lang').text());
    if(flag) {
        if(number < 48) {
            number = number + 2;
        } 
    } else {
        if(number > 12) {
            number = number -2;
        }
    }
    $('.box-size .lang').text(number);
    $('.box-chap p').css('font-size',number + 'px');
}
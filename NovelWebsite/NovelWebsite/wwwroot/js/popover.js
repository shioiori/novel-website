// var popcontent1 = $('.panel-catalog1').html();

// const popover1 = new bootstrap.Popover($('#popover-btn1'), {
//     content: popcontent1,
//     html: true
// });

// var popcontent2 = $('.panel-catalog2').html();

// const popover2 = new bootstrap.Popover($('#popover-btn2'), {
//     content: popcontent2,
//     html: true
// });

// $(document).ready(function(){
//     $('#popover-btn1').popover({
//         html: true,
//         content: function () {
//             $('.popover-title').remove();
//             return $('.panel-catalog1').html();
//         }
//     });
//     $('#popover-btn2').popover({
//         html: true,
//         content: function () {
//             $('.popover-title').remove();
//             return $('.panel-catalog2').html();
//         }
//     });
// });

function openTool(el) {
    if($(el).parent().hasClass('show-sub')) {
        $(el).next().addClass('hidden d-none');
        $(el).parent().removeClass('show-sub');
    } else {
        $(el).parent().addClass('show-sub');
        $(el).next().removeClass('hidden d-none');
        $('.control-title').not($(el).parent()).removeClass('show-sub');
        $('.panel-catalog').not($(el).next()).addClass('hidden d-none');
    }
}

function closeTool(el) {
    $('.control-title').removeClass('show-sub');
    $(el).parent().addClass('hidden d-none');    
}




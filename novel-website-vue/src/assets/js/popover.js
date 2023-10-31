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
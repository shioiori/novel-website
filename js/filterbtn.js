$(document).ready(function(){
  $(".rank-box-item-box li a").click(function(){
    $(this).parent().toggleClass("box-active");
  });

  // $(".btn-filter").click(function(){
  //   $(".rank-box-item-box li").removeClass("box-active");
  // });
});

function typeListClick(el) {
  if($(el).hasClass('active--type-list')){}
  else {
    $(el).addClass('active--type-list');
    $('.type-list a').not($(el)).removeClass("active--type-list");
  }
};


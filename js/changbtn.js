// function onClickInfoBtn(el) {
//     if($(el).hasClass("selected")){
//         $(el).removeClass("selected");
//     } else {
//         $(el).addClass("selected");
//     }
// }

// function showMore(el) {
//     if($(el).hasClass("collapser")){
//         $(el).prev().collapse("toggle");
//     }
// }

function onClickInfoBtn(el, index) {
  if (index == 1) {
    if ($(el).hasClass("selected")) {
      $(el).removeClass("selected");
      $(el).text("Yêu thích");
    } else {
      $(el).addClass("selected");
      $(el).text("Bỏ yêu thích");
    }
  }
  if (index == 2) {
    if ($(el).hasClass("selected")) {
      $(el).removeClass("selected");
      $(el).text("Theo dõi");
    } else {
      $(el).addClass("selected");
      $(el).text("Bỏ theo dõi");
    }
  }
  if (index == 3) {
    if ($(el).hasClass("selected")) {
      $(el).removeClass("selected");
      $(el).text("Đề cử");
    } else {
      $(el).addClass("selected");
      $(el).text("Bỏ đề cử");
    }
  }
}

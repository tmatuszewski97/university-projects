$(".menu-left a").click(function () {
  var thisA = $(this);
  $(".article-section").load(thisA.attr("href"), function () {
    $(".article-section").fadeIn(1000);
  });
  return false;
});

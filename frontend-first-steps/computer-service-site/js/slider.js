function slider() {
  prev = $(".prev");
  next = $(".next");
  slide = $(".slade");
  actual = 0;
  slideNumber = slide.length;

  next.click(function () {
    //policz aktualny
    if (actual === slideNumber - 1) actual = 0;
    else actual++;
    showSlide(actual);
  });

  prev.click(function () {
    //policz aktualny
    if (actual === 0) actual = slideNumber - 1;
    else actual--;
    showSlide(actual);
  });
}

function showSlide(actualSlide) {
  sliderCo = $("#slider #slades");
  sliderCo.fadeOut(200, function () {
    slide.removeClass("active");
    slide.eq(actualSlide).addClass("active");
    sliderCo.fadeIn();
  });
}

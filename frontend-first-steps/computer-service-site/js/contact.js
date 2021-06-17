$("#hideFields").click(function () {
  $(".select-gender").css("display", "none");
  $(".select-is-client").css("display", "none");
  $(".select-attachment").css("display", "none");
});

$("#showFields").click(function () {
  $(".select-gender").css("display", "block");
  $(".select-is-client").css("display", "inline-block");
  $(".select-attachment").css("display", "block");
});

$(".logo").rollingBorder({
  padding: 0,
  margin: 0,
  color: "#41a782",
});

function getFormattedDate(format) {
  var date = new Date(Date.now()),
    formattedDate;

  formattedDate =
    date.getFullYear() +
    "-" +
    handleSingleDigit(date.getMonth() + 1) +
    "-" +
    handleSingleDigit(date.getDate()) +
    " " +
    handleSingleDigit(handleHours(date.getHours())) +
    ":" +
    handleSingleDigit(date.getMinutes()) +
    ":" +
    handleSingleDigit(date.getSeconds()) +
    " " +
    (date.getHours() < 12 ? "AM" : "PM");

  return formattedDate;
}

function handleSingleDigit(num) {
  return num.toString().length === 1 ? "0" + num : num;
}

function handleHours(hours) {
  hours = hours > 12 ? hours - 12 : hours;
  if (hours.toString() === "0") hours = "12";
  return hours;
}

function updateClock() {
  document.getElementById("clock").innerHTML = getFormattedDate();
}

updateClock();
setInterval(updateClock, 1000);

slider();

$(window).resize(function () {
  location.reload();
});

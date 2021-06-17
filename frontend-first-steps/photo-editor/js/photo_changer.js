button1 = document.getElementById('button1');
button2 = document.getElementById('button2');
button3 = document.getElementById('button3');
button4 = document.getElementById('button4');
var image = new Image();
var ctx;
var canvas;

$(document).ready(function () {
    colorChanger();
    download()
});

function colorChanger() {
    ctx.globalAlpha = parseFloat(document.getElementById("opacity").value);
    var blurValue = parseInt(document.getElementById("blur").value, 10);
    ctx.filter = "blur(" + (blurValue) + "px)";
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(image, 0, 0);
    changeBrightness();
    filter();
    colorChange();
    changeGrey();
    colorNegative();
    blur();
}

function download() {
    var download = document.getElementById("download");
    var img = document.getElementById("canvas").toDataURL("image/png")
        .replace("image/png", "image/octet-stream");
    download.setAttribute("href", img);
}

document.getElementById('img-input').onchange = function(e) {
    image.onload = draw;
    image.src = URL.createObjectURL(this.files[0]);
};

function draw() {
    canvas = document.getElementById('canvas');
    canvas.width = this.width;
    canvas.height = this.height;
    ctx = canvas.getContext('2d');
    ctx.drawImage(this, 0,0);
}

function changeBrightness() {
    var brightnessMul = parseFloat(document.getElementById("brightness").value);
    var imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
    var image_data = imageData.data;
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    for (var i = 0; i < image_data.length; i += 4) {
        var red = image_data[i];
        var green = image_data[i + 1];
        var blue = image_data[i + 2];

        image_data[i] = (red * brightnessMul);
        image_data[i + 1] = (green * brightnessMul);
        image_data[i + 2]= (blue * brightnessMul);
    }
    ctx.putImageData(imageData, 0, 0);
}

function changeGrey() {
    if (document.getElementById('grey').checked) {
        var imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
        var image_data = imageData.data;
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        for (var i = 0; i < image_data.length; i += 4) {
            var red = image_data[i];
            var green = image_data[i + 1];
            var blue = image_data[i + 2];
            var alpha = image_data[i + 3];
            var gray = (red + green + blue) / 3;

            image_data[i] = gray;
            image_data[i + 1] = gray;
            image_data[i + 2] = gray;
            image_data[i + 3] = alpha;
        }
        ctx.putImageData(imageData, 0, 0);
    }
}

function colorNegative() {
    if (document.getElementById('negativ').checked) {
        var imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
        var image_data = imageData.data;
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        for (var i = 0; i < image_data.length; i += 4) {
            image_data[i] = 255 - image_data[i];
            image_data[i + 1] = 255 - image_data[i + 1];
            image_data[i + 2] = 255 - image_data[i + 2];
        }
        ctx.putImageData(imageData, 0, 0);
    }
}

function colorChange() {
    var redValue = parseInt(document.getElementById("red").value, 10);
    var greenValue = parseInt(document.getElementById("green").value, 10);
    var blueValue = parseInt(document.getElementById("blue").value, 10);

    var imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
    var image_data = imageData.data;
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    for (var i = 0; i < image_data.length; i += 4) {
        image_data[i] += redValue;
        image_data[i + 1] += greenValue;
        image_data[i + 2] += blueValue;
    }
    ctx.putImageData(imageData, 0, 0);
}

function filter() {
    if (document.getElementById('filterUse').checked) {
        {
            var opt1 = document.getElementById("option1").value;
            var opt2 = document.getElementById("option2").value;
            var opt3 = document.getElementById("option3").value;
            var opt4 = document.getElementById("option4").value;
            ctx.fillStyle = document.getElementById("colorPicker").value;

            for (var i = 0; i < 1; i += 0.04) {
                ctx.globalAlpha = i;
                ctx.fillRect(opt1, i * opt2, opt3, opt4); }
        }
    }
}
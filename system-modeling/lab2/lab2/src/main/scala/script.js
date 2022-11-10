class BarChart {
    constructor(options) {
        this.options = options;
        this.canvas = options.canvas;
        this.ctx = options.ctx;
        this.colors = options.colors;
        this.titleOptions = options.titleOptions;
        this.maxValue = Math.max(...Object.values(this.options.data));
    }

    drawGridLines() {
        var canvasActualHeight = this.canvas.height - this.options.padding * 2;
        var canvasActualWidth = this.canvas.width - this.options.padding * 2;

        var gridValue = 0;
        while (gridValue <= this.maxValue) {
            var gridY =
                canvasActualHeight * (1 - gridValue / this.maxValue) +
                this.options.padding;
            drawLine(
                this.ctx,
                0,
                gridY,
                this.canvas.width,
                gridY,
                this.options.gridColor
            );

            drawLine(
                this.ctx,
                15,
                this.options.padding / 2,
                15,
                gridY + this.options.padding / 2,
                this.options.gridColor
            );

            // Writing grid markers
            this.ctx.save();
            this.ctx.fillStyle = this.options.gridColor;
            this.ctx.textBaseline = "bottom";
            this.ctx.font = "bold 10px Arial";
            this.ctx.fillText(gridValue, 0, gridY - 2);
            this.ctx.restore();

            gridValue += this.options.gridScale;
        }
    }

    drawBars() {
        var canvasActualHeight = this.canvas.height - this.options.padding * 2;
        var canvasActualWidth = this.canvas.width - this.options.padding * 2;

        var barIndex = 0;
        var numberOfBars = Object.keys(this.options.data).length;
        var barSize = canvasActualWidth / numberOfBars;

        var values = Object.values(this.options.data);

        for (let val of values) {
            var barHeight = Math.round((canvasActualHeight * val) / this.maxValue);

            drawBar(
                this.ctx,
                this.options.padding + barIndex * barSize,
                this.canvas.height - barHeight - this.options.padding,
                barSize,
                barHeight,
                this.colors[barIndex % this.colors.length]
            );

            barIndex++;
        }
    }

    draw() {
        this.drawGridLines();
        this.drawBars();
    }
}

function drawLine(ctx, startX, startY, endX, endY, color) {
    ctx.save();
    ctx.strokeStyle = color;
    ctx.beginPath();
    ctx.moveTo(startX, startY);
    ctx.lineTo(endX, endY);
    ctx.stroke();
    ctx.restore();
}

function drawBar(ctx, upperLeftCornerX, upperLeftCornerY, width, height, color) {
    ctx.save();
    ctx.fillStyle = color;
    ctx.fillRect(upperLeftCornerX, upperLeftCornerY, width, height);
    ctx.restore();
}

class LinearCongurentRandom {
    x0 = Date.now() * 1
    k = Date.now() * 1
    c = Date.now() * 1

    next(start, end) {
        this.x0 = (this.k * this.x0 + this.c) % (end + 1)
        let y = this.x0 / (end + 1)
        return (y * end) % (end - start) + start
    }
}

class NeimansRandom {
    x0 = Date.now() * 1;

    next(start, end) {
        let square = this.x0 * this.x0
        this.x0 = square.toString().substring(square.toString().length / 2 - 2, square.toString().length / 2 + 2)
        let y = this.x0 / 10000
        return (y * end) % (end - start) + start
    }
}

function getDefaultRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min); // The maximum is exclusive and the minimum is inclusive
}


//main
let defaultC = document.getElementById("default");
defaultC.width = 500;
defaultC.height = 500;

let neiman = document.getElementById("neiman");
neiman.width = 500;
neiman.height = 500;

let linear = document.getElementById("linear");
linear.width = 500;
linear.height = 500;


let contextD = defaultC.getContext("2d");
let contextN = neiman.getContext("2d");
let contextL = linear.getContext("2d");

let doMagic = () => {
    let neimansRandom = new NeimansRandom();
    let linearCongurentRandom = new LinearCongurentRandom();

    contextD.clearRect(0, 0, defaultC.width, defaultC.height);
    contextN.clearRect(0, 0, defaultC.width, defaultC.height);
    contextL.clearRect(0, 0, defaultC.width, defaultC.height);

    let iterations = document.getElementById("try").value || 10;
    let start = document.getElementById("from").value || 0;
    let end = document.getElementById("to").value || 100;
    let barNumber = document.getElementById("count").value || 5;
    let step = (end - start) / barNumber
    let gridScale = iterations / 10 === 0 ? 1 : iterations / 10;

    let defaultData = [];
    let neimansData = [];
    let linearCongurentData = [];

    Math.random();
    for (let i = 0; i < iterations; i++) {
        defaultData.push(getDefaultRandomInt(start, end));
        neimansData.push(neimansRandom.next(start, end));
        linearCongurentData.push(linearCongurentRandom.next(start, end));
    }

    function process(defaultData, start, end, step) {
        let data = {}
        for (let i = 0; i < end; i += step) {
            data[i.toString()] = 0;
        }
        for (let i = 0; i < defaultData.length; i++) {
            for (let j = 0; j <= end; j += step) {
                if (defaultData[i] >= j && defaultData[i] < j + step) {
                    data[j.toString()]++;
                }
            }
        }
        return data;
    }

    let processedDefault = process(defaultData, start, end, step);
    let processedNeiman = process(neimansData, start, end, step);
    let processedLinear = process(linearCongurentData, start, end, step);

    var defaultChart = new BarChart({
        canvas: defaultC,
        ctx: contextD,
        padding: 100,
        gridScale: gridScale,
        gridColor: "black",
        data: processedDefault,
        colors: ["#a55ca5", "#67b6c7", "#bccd7a", "#eb9743", "#bbbbbb"],
    });
    var neimanChart = new BarChart({
        canvas: neiman,
        ctx: contextN,
        padding: 100,
        gridScale: gridScale,
        gridColor: "black",
        data: processedNeiman,
        colors: ["#a55ca5", "#67b6c7", "#bccd7a", "#eb9743", "#bbbbbb"],
    });
    var linearChart = new BarChart({
        canvas: linear,
        ctx: contextL,
        padding: 100,
        gridScale: gridScale,
        gridColor: "black",
        data: processedLinear,
        colors: ["#a55ca5", "#67b6c7", "#bccd7a", "#eb9743", "#bbbbbb"],
    });

    document.getElementById("values1").innerHTML = defaultData.map(x => Math.round(x)).join("</br>")
    document.getElementById("values2").innerHTML = neimansData.map(x => Math.round(x)).join("</br>")
    document.getElementById("values3").innerHTML = linearCongurentData.map(x => Math.round(x)).join("</br>")

    defaultChart.draw();
    neimanChart.draw();
    linearChart.draw();
}

doMagic();
document.getElementById("start-new").onclick = doMagic;
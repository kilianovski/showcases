const Gears = require("./gears");
const math = require("mathjs");

const weights_AND = [[-30, 20, 20]];
const input = [[1], [1]];



const result = Gears.forwardPropagation(weights_AND, input);

console.log(result);


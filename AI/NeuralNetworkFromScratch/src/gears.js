const math = require("mathjs");

const deepCopy = matrix => JSON.parse(JSON.stringify(matrix));
const m = math.matrix;
module.exports.transpose = function(A) {
  return math.transpose(A);
};

module.exports.sigmoid = function(x) {
  return 1 / (1 - math.pow(math.e, -x));
}

module.exports.forwardPropagation = function(theta, x) {
  const X = deepCopy(x);
  X.unshift([1]);
  
  const Z = math.multiply(m(theta), m(X));

  return Z.map(module.exports.sigmoid)._data;
};

const Gears = require("./gears");
const math = require("mathjs");

test("transpose sample", () => {
  const A = [[1, 2], [3, 4], [5, 6]];

  const AT = [[1, 3, 5], [2, 4, 6]];

  expect(Gears.transpose(A)).toEqual(AT);
});

test("my understanding of matrix multiplication api", () => {
  const A = 
    [
      [1, 6, 3],
      [4, 2, 9]
    ];

  const B = 
    [
      [4, 8],
      [6, 1],
      [2, 5]
    ];

    const C = 
    [
      [46, 29],
      [46, 79]
    ];

    expect(math.multiply(A, B)).toEqual(C);
});

describe('sigmoid function', () => {
    it('should output >= 0.5', () => {
        expect(Gears.sigmoid(42)).toBeGreaterThanOrEqual(0.5);
        expect(Gears.sigmoid(0.001)).toBeGreaterThanOrEqual(0.5);
    })

    it('should output <= 0.5', () => {
        expect(Gears.sigmoid(-42)).toBeLessThanOrEqual(0.5);
        expect(Gears.sigmoid(-0.001)).toBeLessThanOrEqual(0.5);
    })
})

describe("one layer forward propagation", () => {
  it("should correctly be an AND function", () => {
    const weights_AND = [[-30, 20, 20]];
    const and = input => {
        const X = [[input[0]], [input[1]]];
        const result = math.squeeze(Gears.forwardPropagation(weights_AND, X));
        return result > 0.5 ? 1 : 0;
    }

    expect(and([0, 0])).toEqual(0);
    expect(and([0, 1])).toEqual(0);
    expect(and([1, 0])).toEqual(0);
    expect(and([1, 1])).toEqual(1);
  });

  it("should correctly be an OR function", () => {
    const weights_OR = [[-10, 20, 20]];
    const or = input => {
        const X = [[input[0]], [input[1]]];
        const result = math.squeeze(Gears.forwardPropagation(weights_OR, X));
        return result > 0.5 ? 1 : 0;
    }
    expect(or([0, 0])).toEqual(0);
    expect(or([0, 1])).toEqual(1);
    expect(or([1, 0])).toEqual(1);
    expect(or([1, 1])).toEqual(1);
  });
});

describe("multilayer forward propagation", () => {
    describe("should correctly be an XOR function", () => {
        const weights_XOR_0 = 
        [
            [-10, 20, 20],
            [-30, 20, 20]
        ];

        const weights_XOR_1 = [[-10, 25, -20]];

        const xor = input => {
            const X = [[input[0]], [input[1]]];
            const A0 = Gears.forwardPropagation(weights_XOR_0, X);
            const A1 = Gears.forwardPropagation(weights_XOR_1, A0);
            const result = math.squeeze(A1);
            return result > 0.5 ? 1 : 0;
        };

        expect(xor([0, 0])).toEqual(0);
        expect(xor([0, 1])).toEqual(1);
        expect(xor([1, 0])).toEqual(1);
        expect(xor([1, 1])).toEqual(0);
    });
})

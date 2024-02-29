const { AdventOfCode2 } = require('./day2');

test('Intcode runProgram 1', () => {
  const intCode = [1, 0, 0, 0, 99];
  const expectedFinalState = [2, 0, 0, 0, 99];
  expect(AdventOfCode2.runProgram(intCode).toString()).toBe(
    expectedFinalState.toString()
  );
});

test('Intcode runProgram 2', () => {
  const intCode = [2, 3, 0, 3, 99];
  const expectedFinalState = [2, 3, 0, 6, 99];
  expect(AdventOfCode2.runProgram(intCode).toString()).toBe(
    expectedFinalState.toString()
  );
});

test('Intcode runProgram 3', () => {
  const intCode = [2, 4, 4, 5, 99, 0];
  const expectedFinalState = [2, 4, 4, 5, 99, 9801];
  expect(AdventOfCode2.runProgram(intCode).toString()).toBe(
    expectedFinalState.toString()
  );
});

test('Intcode runProgram 4', () => {
  const intCode = [1, 1, 1, 4, 99, 5, 6, 0, 99];
  const expectedFinalState = [30, 1, 1, 4, 2, 5, 6, 0, 99];
  expect(AdventOfCode2.runProgram(intCode).toString()).toBe(
    expectedFinalState.toString()
  );
});

test('Intcode runProgram 5', () => {
  const intCode = [1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50];
  const expectedFinalState = [3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50];
  expect(AdventOfCode2.runProgram(intCode).toString()).toBe(
    expectedFinalState.toString()
  );
});

test('Intcode getNounAndVerb', () => {
  const intCode = AdventOfCode2.getInput();
  const output = 2894520; // Result from 2a
  const expectedNoun = 12; // Noun from 2a
  const expectedVerb = 2; // Verb from 2a
  expect(AdventOfCode2.getNounAndVerb(intCode, output).noun).toBe(expectedNoun);
  expect(AdventOfCode2.getNounAndVerb(intCode, output).verb).toBe(expectedVerb);
});

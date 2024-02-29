namespace AdventOfCode2 {
  export function getInput(): number[] {
    const fileName = './2/input.txt';
    const fs = require('fs');
    return fs
      .readFileSync(fileName, 'utf8')
      .split(',')
      .map((nbr: string) => parseInt(nbr));
  }

  export function runProgram(intCode: number[]): number[] {
    const output = [...intCode];
    let currentIndex = 0;
    while (output.at(currentIndex) !== 99) {
      const currentOpCode = output.at(currentIndex);
      const indexes = {
        nbr1: output.at(currentIndex + 1)!,
        nbr2: output.at(currentIndex + 2)!,
        res: output.at(currentIndex + 3)!,
      };
      const nbr1 = output.at(indexes.nbr1)!;
      const nbr2 = output.at(indexes.nbr2)!;
      let res = 0;
      if (currentOpCode === 1) {
        res = nbr1 + nbr2;
      } else if (currentOpCode === 2) {
        res = nbr1 * nbr2;
      } else {
        throw new Error(`Opcode must be 1, 2 or 99 but is ${currentOpCode}`);
      }
      output[indexes.res] = res;
      currentIndex += 4;
    }
    return output;
  }

  export function getNounAndVerb(
    intCode: number[],
    output: number
  ): {
    noun: number;
    verb: number;
  } {
    const instCodeLength = intCode.length;
    for (let noun = 0; noun < instCodeLength; noun++) {
      for (let verb = 0; verb < instCodeLength; verb++) {
        const restoredIntCode = getRestoredIntCode(intCode, noun, verb);
        const calculatedOutput = runProgram(restoredIntCode)[0];
        if (calculatedOutput === output) {
          return { noun, verb };
        }
      }
    }
    return { noun: 0, verb: 0 };
  }

  function getRestoredIntCode(
    intCode: number[],
    noun: number,
    verb: number
  ): number[] {
    const restoredIntCode = [...intCode];
    restoredIntCode[1] = noun;
    restoredIntCode[2] = verb;
    return restoredIntCode;
  }

  function solve2a(intCode: number[]): number {
    const restoredIntCode = getRestoredIntCode(intCode, 12, 2);
    const intCodeFinalState = runProgram(restoredIntCode);
    return intCodeFinalState[0];
  }

  function solve2b(intCode: number[]): number {
    const { noun, verb } = getNounAndVerb(intCode, 19690720);
    return 100 * noun + verb;
  }

  const intCode = getInput();
  console.log(`The result of AoC 2019 2a: ${solve2a(intCode)}`);
  console.log(`The result of AoC 2019 2b: ${solve2b(intCode)}`);
}

export { AdventOfCode2 };

namespace AdventOfCode2 {
  export function getInput(fileName: string): number[] {
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

  function restoreTo1202ProgramAlarm(intCode: number[]) {
    intCode[1] = 12;
    intCode[2] = 2;
  }

  function solve2a(): number {
    const intCode = getInput('./2/input.txt');
    restoreTo1202ProgramAlarm(intCode);
    const intCodeFinalState = runProgram(intCode);
    return intCodeFinalState[0];
  }

  console.log(`The result of AoC 2019 2a: ${solve2a()}`);
}

export { AdventOfCode2 };

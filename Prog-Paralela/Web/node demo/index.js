import chalk from "chalk";
import fileSystem from "fs";

let arr = new Array(Math.floor(5 + Math.random() * 15))
	.fill(1)
	.map((x) => (x = "abc " + Math.random()))
	.join("\n");

fileSystem.writeFileSync("./hello.txt", arr);
console.log(chalk.bold.green("200 success"));

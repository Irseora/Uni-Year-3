function printNumbers() {
	return new Promise((resolve) => {
		let i = 0;
		let interval = setInterval(() => {
			console.log(`Number: ${i}`);
			i++;
			if (i >= 5) {
				clearInterval(interval);
				resolve();
			}
		}, 1000);
	});
}

async function main() {
	await printNumbers();
	console.log("Execution completed.");
}

main();

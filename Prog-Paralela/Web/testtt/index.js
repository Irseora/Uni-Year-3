const express = require("express");
const app = express();
const port = 3000;

const items = [];
items.push({ id: 1, group: "A", name: "A1" });
items.push({ id: 2, group: "B", name: "B1" });
items.push({ id: 3, group: "A", name: "A2" });
items.push({ id: 4, group: "A", name: "A3" });
items.push({ id: 5, group: "A", name: "A4" });
items.push({ id: 6, group: "B", name: "B2" });
items.push({ id: 7, group: "B", name: "B3" });

app.get("/", (req, res) => {
	res.send("Hello World");
});

app.get("/grouped", (req, res) => {
	// apply to all elements
	const done = items.reduce((grouped, item) => {
		let group = item.group;

		// if current item's group doesnt exist yet, initialize
		if (!grouped[group]) {
			grouped[group] = [];
		}

		// push item to its group
		grouped[group].push(item);
		return grouped;
	}, {});

	for (item in done)
		for (key in item)
			if (typeof key !== "number") done.map((key, ...rest) => rest);

	res.json(done);
});

app.listen(port, () => {
	console.log(`localhost:${port}`);
});

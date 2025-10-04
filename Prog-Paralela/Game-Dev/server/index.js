const express = require("express");

const app = express();
const port = 3000;

let coords = {
	x: 100,
	y: 50,
};

app.get("/", (req, res) => {
	res.json({ coords });
});

// Start server
app.listen(port, () => {
	console.log(`localhost:${port}`);
});

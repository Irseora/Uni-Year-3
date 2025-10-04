const express = require("express");
const bodyParser = require("body-parser");

const app = express();
const port = 3000;

// (TEMA) TODO: refactor so find is O(1)

app.use(bodyParser.json());

const users = new Map();
users.set("aaa", { id: 1, password: "111" });
users.set("bbb", { id: 2, password: "222" });

// Add a new user (through postman)
app.post("/user", (req, res) => {
	const username = req.body.username;
	const password = req.body.password;
	const id = users.length + 1;

	users.set(username, { id: id, password: password });

	console.log(users);

	res.json({ status: "ok", users: users });
});

// Log in as an existing user (through postman)
app.post("/login", (req, res) => {
	const username = req.body.username;
	const password = req.body.password;

	if (users.get(username).password == password)
		res.status(200).json({ user: users.get(username) });
	else res.status(400).json({ status: "wrong user / password" });
});

// List all users
app.get("/", (req, res) => {
	res.json(users);
});

// Show user with given id
app.get("/user/:username", (req, res) => {
	res.json({
		user: users.get(username),
	});
});

// Start server
app.listen(port, () => {
	console.log(`localhost:${port}`);
});

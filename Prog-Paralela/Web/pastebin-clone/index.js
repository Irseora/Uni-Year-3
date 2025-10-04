import express from "express";
import bodyParser from "body-parser";
import sqlite3 from "sqlite3";
import { execute, fetchAll, fetchFirst } from "./sqlWrappers.js";
import { v4 as uuidv4 } from "uuid";

const app = express();
const port = 3000;
let db;

async function initDB() {
	db = new sqlite3.Database("test.db");

	try {
		await execute(
			db,
			`CREATE TABLE IF NOT EXISTS code_snippets (
            id INTEGER PRIMARY KEY,
            snippet TEXT NOT NULL,
            slug TEXT NOT NULL)`
		);
	} catch (error) {
		console.log(error);
	}
}

initDB();

app.use(bodyParser.json());

app.post("/", async (req, res) => {
	const { text, author, date, tags } = req.body;
	console.log(text);

	const slug = uuidv4();
	const sql = "INSERT INTO code_snippets(slug, snippet) VALUES(?, ?)";

	try {
		await execute(db, sql, [slug, text]);
		return res.json({
			slug: slug,
		});
	} catch (err) {
		console.log(err);
		return res.status(500).json({
			message: "Something went wrong",
		});
	}
});

app.get("/", async (req, res) => {
	const sql = "SELECT * FROM code_snippets";
	const snippets = await fetchAll(db, sql);

	res.json({ snippets });
});

app.get("/:slug", async (req, res) => {
	const { slug } = req.params;

	const sql = "SELECT * FROM code_snippets WHERE slug = ?";
	const snippet = await fetchFirst(db, sql, slug);

	res.json({ snippet });
});

app.listen(port, () => {
	console.log(`http://localhost:${port}`);
});

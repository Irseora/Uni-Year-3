import { useState } from "react";
import Task from "./Task";
import "./TodoList.css";

function TodoList() {
	const [text, setText] = useState("");
	const [tasks, setTasks] = useState([
		{
			id: 1,
			text: "AAAAAAAAAA",
			done: false,
		},
		{
			id: 2,
			text: "BBBBBBBBBBBBBB",
			done: true,
		},
	]);

	// Add new task with given text
	function addTask(text) {
		const newTask = {
			id: tasks.length + 1,
			text: text,
			done: false,
		};

		setTasks([...tasks, newTask]);
		setText("");
	}

	// Delete task with given id
	function deleteTask(id) {
		setTasks(tasks.filter((task) => task.id != id));
	}

	// Toggle task with given id
	function toggleDone(id) {
		setTasks(
			tasks.map((task) => {
				if (task.id == id) return { ...task, done: !task.done };
				else return task;
			})
		);
	}

	return (
		<>
			<div className="todo-list">
				<h3>Tasks:</h3>

				{tasks.map((task) => (
					<Task
						key={task.id}
						task={task}
						deleteTask={deleteTask}
						toggleDone={toggleDone}
					/>
				))}

				<div className="new-task-input">
					<input value={text} onChange={(e) => setText(e.target.value)} />
					<button onClick={() => addTask(text)}>Add Task</button>
				</div>
			</div>
		</>
	);
}

export default TodoList;

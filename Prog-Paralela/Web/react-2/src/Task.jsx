import React from "react";
import "./Task.css";

function Task({ task, deleteTask, toggleDone }) {
	function handleChange() {
		toggleDone(task.id);
	}

	return (
		<>
			<div className="task">
				<input type="checkbox" checked={task.done} onChange={handleChange} />
				<p>{task.text}</p>
				<button onClick={() => deleteTask(task.id)}>X</button>
			</div>
		</>
	);
}

export default Task;

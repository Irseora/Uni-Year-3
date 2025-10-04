function addTask() {
    let taskInput = document.getElementById("task");
    let taskValue = taskInput.value.trim();
    
    if (taskValue === "") {
        alert("Please enter a task!");
        return;
    }
    
    let listItem = document.createElement("li");
              
    let checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.className = "mr-1"
    checkbox.addEventListener("change", function() {
        taskText.classList.toggle("completed", checkbox.checked);
    });
    
    let taskText = document.createElement("span");
    taskText.textContent = taskValue;
    
    listItem.appendChild(checkbox);
    listItem.appendChild(taskText);
    
    document.getElementById("task-list").appendChild(listItem);
    taskInput.value = "";
}

var input = document.getElementById("task");
input.addEventListener("keypress", function(event) {
    if (event.key === "Enter") {
        event.preventDefault();
        document.getElementById("submit").click();
    }
});
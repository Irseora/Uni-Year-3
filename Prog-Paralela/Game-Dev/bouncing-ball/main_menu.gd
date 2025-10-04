extends Node2D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	if not FileAccess.file_exists("user://savegame.save"):
		return
	
	var save_file = FileAccess.open("user://savegame.save", FileAccess.READ)
	# Globals.saved_text = save_file.get_var()
	$LineEdit.placeholder_text = save_file.get_var()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_button_pressed() -> void:
	if $LineEdit.text != "": Globals.saved_text = $LineEdit.text
	else: Globals.saved_text = $LineEdit.placeholder_text
	
	var save_file = FileAccess.open("user://savegame.save", FileAccess.WRITE)
	save_file.store_var(Globals.saved_text)
	
	get_tree().change_scene_to_file("res://scene1.tscn")


func _on_line_edit_text_submitted(new_text: String) -> void:
	_on_button_pressed()

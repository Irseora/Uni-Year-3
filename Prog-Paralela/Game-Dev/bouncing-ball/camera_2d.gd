extends Camera2D


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func shake() -> void:
	var shakeStrength = 10;
	var shakeOffset = [
		Vector2(1, 0),
		Vector2(1, 1),
		Vector2(0, 1),
		Vector2(0, 0),
		Vector2(-1, 0),
		Vector2(-1, -1),
		Vector2(0, -1),
		Vector2(0, 0)
	];
	
	for i in 8:
		offset = shakeOffset[i] * shakeStrength;
		await get_tree().create_timer(0.01).timeout;

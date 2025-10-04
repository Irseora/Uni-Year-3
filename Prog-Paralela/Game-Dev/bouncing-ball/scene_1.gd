extends Node2D

var ball_scene = preload("res://ball.tscn")

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	$Label3.text = Globals.saved_text
	$HTTPRequest.request("http://localhost:3000")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if Input.is_action_just_pressed("spawn_ball_key"):
		var ball = ball_scene.instantiate()
		ball.position = get_global_mouse_position()
		add_child(ball)

func _on_http_request_completed(result: int, response_code: int, headers: PackedStringArray, body: PackedByteArray) -> void:
	var json = JSON.parse_string(body.get_string_from_utf8())
	var coords = json["coords"]
	print(coords)
	
	var ball = ball_scene.instantiate()
	ball.position = Vector2(coords["x"], coords["y"])
	add_child(ball)

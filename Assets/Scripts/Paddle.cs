using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private float screenWidth;
	private float paddlePosInWorldBlocks;
	private Vector3 paddlePos;
	const int INPUT_MOUSE = 0x03;
	const int INPUT_KEYBOARD = 0x04;
	private int inputState;

	// Use this for initialization
	void Start () {
		paddlePos = new Vector3(8f, 1f, 0f);
		inputState = INPUT_KEYBOARD;
	}
	
	// Update is called once per frame
	void Update () {
		screenWidth = Screen.width;
		switch(inputState) {
		case INPUT_MOUSE:
			updateMouse();
			break;
		case INPUT_KEYBOARD:
			checkKeyInput();
			break;
		}
	}
	
	private void updateMouse() {
		paddlePosInWorldBlocks = (Input.mousePosition.x / screenWidth) * 16;
		updatePaddlePos (paddlePosInWorldBlocks, this.transform.position.y);
	}
	
	private void checkKeyInput() {
		if(Input.GetKey (KeyCode.LeftArrow)) {
			updatePaddlePos (paddlePos.x - 0.25f, this.transform.position.y);
		} else if(Input.GetKey (KeyCode.RightArrow)) {
			updatePaddlePos (paddlePos.x + 0.25f, this.transform.position.y);
		}
	}
	
	private void updatePaddlePos(float x, float y) {
		paddlePos.x = Mathf.Clamp (x, 0.5f, 15.5f);
		paddlePos.y = y;
		this.transform.position = paddlePos;
	}
}

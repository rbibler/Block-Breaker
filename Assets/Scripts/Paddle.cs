using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private float screenWidth;
	private float paddlePosInWorldBlocks;
	private float paddleVel;
	private Vector3 paddlePos;
	const int INPUT_MOUSE = 0x03;
	const int INPUT_KEYBOARD = 0x04;
	const int INPUT_TOUCH = 0x05;
	private int inputState;


	// Use this for initialization
	void Start () {
		paddlePos = this.transform.position;
		setPaddleVel (.1f);
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
		case INPUT_TOUCH:
			checkClickInput ();
			break;
		}
	}
	
	private void updateMouse() {
		paddlePosInWorldBlocks = (Input.mousePosition.x / screenWidth) * 16;
		updatePaddlePos (paddlePosInWorldBlocks, this.transform.position.y);
	}
	
	private void checkKeyInput() {
		if(Input.GetKey (KeyCode.LeftArrow)) {
			movePaddleLeft ();
		} else if(Input.GetKey (KeyCode.RightArrow)) {
			movePaddleRight ();
		}
	}

	private void checkTouchInput() {
		Touch[] touches = Input.touches;
		foreach(Touch touch in touches) {
			if(touch.position.x < screenWidth / 2) {
				movePaddleLeft();
			} else {
				movePaddleRight();
			}

		}
	}

	private void checkClickInput() {
		if (Input.GetMouseButton(0)) {
			if(Input.mousePosition.x < screenWidth / 2) {
				movePaddleLeft();
			} else {
				movePaddleRight();
			}
		}
	}

	private void movePaddleLeft() {
		updatePaddlePos(paddlePos.x - paddleVel, paddlePos.y);
	}

	private void movePaddleRight() {
		updatePaddlePos (paddlePos.x + paddleVel, paddlePos.y);
	}
	
	private void updatePaddlePos(float x, float y) {
		paddlePos.x = Mathf.Clamp (x, 0.5f, 15.5f);
		paddlePos.y = y;
		this.transform.position = paddlePos;
	}
	
	public void setPaddleVel(float vel) {
		this.paddleVel = vel;
	}
}

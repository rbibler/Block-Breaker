using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public int inputState;

	private float screenWidth;
	private float paddlePosInWorldBlocks;
	private float paddleVel;
	private Vector3 paddlePos;
	private Ball ball;
	const int INPUT_MOUSE = 0x00;
	const int INPUT_KEYBOARD = 0x01;
	const int INPUT_TOUCH = 0x02;
	const int AUTO_PLAY = 0x03;
	


	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		paddlePos = this.transform.position;
		setPaddleVel (.1f);
		//inputState = AUTO_PLAY;
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
		case AUTO_PLAY:
			AutoPlay();
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
	
	private void AutoPlay() {
		paddlePos.x = Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f);
		transform.position = paddlePos;
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

	void OnCollisionEnter2D(Collision2D col) {
		col.gameObject.rigidbody2D.velocity += rigidbody2D.velocity;
	}
}

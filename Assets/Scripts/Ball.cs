using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;

	private Vector3 paddleToBallVector;
	private bool gameStarted;

	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if(Input.GetMouseButtonDown (0)) {
				print ("mouse");
				gameStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f, 10f);
			}
		}
	}
}

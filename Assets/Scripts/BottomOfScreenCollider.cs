using UnityEngine;
using System.Collections;

public class BottomOfScreenCollider : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D collider) {
		levelManager.LoadLevel ("Win Screen");
	}
}

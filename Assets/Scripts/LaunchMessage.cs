using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaunchMessage : MonoBehaviour {

	public string launchKey;
	public Text launchMessage;

	// Use this for initialization
	void Start () {
		launchMessage.text = "Press " + launchKey + " to launch ball...";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (launchKey)) {
			GameObject.FindObjectOfType<Ball>().Launch();
			Destroy (gameObject);
		}
	}
}

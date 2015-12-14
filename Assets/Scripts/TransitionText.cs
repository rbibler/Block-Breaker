using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransitionText : MonoBehaviour {

	public Text message;
	public Text levelYouBeat;
	private LevelManager levelManager;
	private long startTime;
	private const float displayTime = 1.5f;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelYouBeat.text += " " + levelManager.getCurrentLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad >= displayTime) {
			levelManager.TransitionFinished();
		}
	}
}

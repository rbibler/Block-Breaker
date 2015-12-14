using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {

	public int levelNumber;
	public int gameLevelNumber;

	void Awake() {
		LevelManager.currentLevel = levelNumber;
		LevelManager.lastGameLevel = Application.loadedLevel;
		print ("Current Level set from LevelInfo: " + LevelManager.currentLevel);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}

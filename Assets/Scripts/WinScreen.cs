﻿using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad >= 2.0f) {
			GameObject.FindObjectOfType<LevelManager>().ReturnToMenu();
		}
	}
}

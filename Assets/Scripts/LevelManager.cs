using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static int currentLevel;
	public static int lastGameLevel;

	void Start() {
	}

	public void QuitRequest() {
		Application.Quit ();
	}

	public void LoadTransition() {
		Application.LoadLevel ("Level_Transition");
	}

	public void TransitionFinished() {
		LoadNextLevel ();
	}

	public void LoadLevel(int levelToLoad) {
		Application.LoadLevel (levelToLoad);
	}

	public void ReloadLevel() {
		LoadLevel (lastGameLevel);
	}

	private void LoadNextLevel() {
		LoadLevel(lastGameLevel + 1);
	}

	public int getCurrentLevel() {
		return currentLevel;
	}

	public void BrickDestroyed() {
		if (Brick.breakableBricksRemaining <= 0) {
			LoadTransition();
		}
	}

	public void Lose() {
		Brick.breakableBricksRemaining = 0;
		Application.LoadLevel ("Lose Screen");
	}

	public void ReturnToMenu() {
		Application.LoadLevel ("Start Menu");
	}
	
}

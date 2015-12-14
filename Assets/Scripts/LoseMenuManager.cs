using UnityEngine;
using System.Collections;

public class LoseMenuManager : MenuOptionManager {
	
	public override void ExecuteOption(int optionNum) {
		switch (optionNum) {
		case 0:
			levelManager.ReloadLevel ();
			break;
		case 1:
			levelManager.ReturnToMenu();
			break;
		}
	}
}

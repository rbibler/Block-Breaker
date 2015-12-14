using UnityEngine;
using System.Collections;

public class StartMenuManager : MenuOptionManager {
	
	public override void ExecuteOption(int optionNum) {
		switch (optionNum) {
		case 0:
			levelManager.LoadLevel (1);
			break;
		case 1:
			Application.Quit ();
			break;
		}
	}
}

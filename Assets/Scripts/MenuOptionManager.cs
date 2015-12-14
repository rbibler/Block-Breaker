using UnityEngine;
using System.Collections;

public class MenuOptionManager : MonoBehaviour {

	protected LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	public virtual void ExecuteOption(int optionNum) {}
}

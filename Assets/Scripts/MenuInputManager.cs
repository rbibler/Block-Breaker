using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuInputManager : MonoBehaviour {


	public Text messageText;
	public Text instructionText;
	public Text menuOption1Text;
	public Text menuOption2Text;
	public Text cursorText;
	public Font font;

	private LevelManager levelManager;
	private Vector3 menuOption1TransformPos;
	private Vector3 menuOption2TransformPos;
	private Vector3 cursorTransformPos;
	private float cursorYOffset = 0;
	private bool menuOption1 = true;

	public MenuOptionManager menuManager;

	void Start () {
		font.material.mainTexture.filterMode = FilterMode.Point;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		menuOption1TransformPos = menuOption1Text.transform.position;
		menuOption2TransformPos = menuOption2Text.transform.position;
		cursorTransformPos = cursorText.transform.position;
	}

	void Update () {
		if (cursorYOffset == 0) {
			cursorYOffset = (menuOption1Text.rectTransform.rect.height - cursorText.rectTransform.rect.height) / 2;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (menuOption1) {
				cursorTransformPos.y = menuOption2TransformPos.y - cursorYOffset;
				menuOption1 = false;
			} else {
				cursorTransformPos.y = menuOption1TransformPos.y - cursorYOffset;
				menuOption1 = true;
			}
			cursorText.transform.position = cursorTransformPos;
		} else if(Input.GetKeyDown (KeyCode.Return)){
			if(menuOption1) {
				menuManager.ExecuteOption(0);
			} else {
				menuManager.ExecuteOption(1);
			}
		}
	}
}

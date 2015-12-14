using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int breakableBricksRemaining = 0;
	public Sprite[] brickImages;

	private int totalHits = 0;
	private int hitsAllowed;
	private LevelManager levelManager;
	SpriteRenderer spriteRenderer;
	private bool isBreakable;

	
	Color[] colors = new Color[] {
		new Color(148f/255f, 117f/255f, 216f/255f), new Color(234f/255f, 248f/255f, 0), new Color(248f/255f, 87f/255f, 0)
	};
	
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		SetupInitialSprite ();
		SetupBreakableStatus ();

	}

	void SetupBreakableStatus() {
		isBreakable = this.tag == "Breakable";
		if (isBreakable) {
			breakableBricksRemaining++;
		}
	}

	void SetupInitialSprite() {
		spriteRenderer = (SpriteRenderer)GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = brickImages [0];
	}
	
	void OnCollisionEnter2D(Collision2D collider) {
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		++totalHits;
		hitsAllowed = brickImages.Length;
		if (totalHits >= hitsAllowed) {
			//AudioSource.PlayClipAtPoint(crack, transform.position);
			breakableBricksRemaining--;
			levelManager.BrickDestroyed();
			Destroy (gameObject, .05f);
		} else {
			UpdateSprite ();
		}
	}

	private void UpdateSprite() {
		if (brickImages [totalHits]) {
			spriteRenderer.sprite = brickImages [totalHits];
		}
	}

	private void CheckColorChange() {
		int color = (hitsAllowed - totalHits) - 1;
		if (color < 0) {
			color = 0;
		}
		spriteRenderer.color = colors [color];
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadTransition ();
	}
}

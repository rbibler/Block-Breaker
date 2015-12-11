using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int totalHits;
	public int hitsAllowed;
	
	Color[] colors = new Color[] {
		new Color(255f/148f, 255f/117f, 255f/216f), new Color(255f/234f, 255f/248f, 0), new Color(255f/248f, 255f/87f, 0)
	};
	
	
	// Use this for initialization
	void Start () {
		totalHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collider) {
		++totalHits;
		if(totalHits >= hitsAllowed) {
			Destroy (gameObject);
		}
		int color = (hitsAllowed - totalHits) - 1;
		print (color);
		this.renderer.material.SetColor("_Color", colors[color]);
	}
}

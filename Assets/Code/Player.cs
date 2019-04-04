using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject Camera;
	public GameObject Canvas;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Canvas.GetComponent<Gamemaster>().Game_State == "Game") {
			this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + .025f, this.gameObject.transform.position.y);
			if (this.gameObject.transform.position.y >= 5.5 || this.gameObject.transform.position.y <= -5.5) {
				Canvas.GetComponent<Gamemaster>().Game_State = "End";
			}
		}

		Camera.transform.position = new Vector3(this.gameObject.transform.position.x, 0, -10);

		if (Input.GetMouseButtonDown(0)) {
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(3f * new Vector2(0, 2f), ForceMode2D.Impulse);
		}
	}
}

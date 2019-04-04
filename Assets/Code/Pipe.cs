using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	GameObject Player;
	GameObject Canvas;

	void Start () {
		Player = GameObject.Find("Bird");
		Canvas = GameObject.Find("Canvas");

		this.gameObject.name = "Pipe_Middle";
		if (Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y + 1))) {
			if (Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 1)) == null) {
				this.gameObject.name = "Pipe_Bottom";
			}
		}else if (Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 1))) {
			this.gameObject.name = "Pip_Top";
		}
		Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 1), Color.blue, 10);
	}

	void Update () {
		if (Player && this.gameObject.transform.position.x <= Player.transform.position.x - 10) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log("test");
		if (collision.gameObject.name == "Bird") {
			Canvas.GetComponent<Gamemaster>().Game_State = "End";
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody2D rb;
	public float speed = 100f;
	public float MAXIMUM_SPEED = 10f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		

			float veloX = Input.GetAxis ("Horizontal");
			float veloY = Input.GetAxis ("Vertical");

			Vector2 velocity = new Vector2 (veloX, veloY);

		if ((rb.velocity + velocity).magnitude < MAXIMUM_SPEED) {
			
			transform.position = Vector2.MoveTowards(transform.position, (Vector2) transform.position + velocity, speed * Time.deltaTime);
			//rb.position = (Vector2) transform.position + velocity * speed * Time.deltaTime;
		}
	}
}

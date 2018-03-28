using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private GameObject player;
	public float MAXIMUM_DISTANCE = 5f;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(player.transform.position, transform.position) <=  MAXIMUM_DISTANCE)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			Debug.Log ("+1 points");
			Destroy (this.gameObject);
		}	

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	public float speed = 10f;
	public float jumpCooldown = 4;
	public float maxJumpDist = 2;
	public bool jumpAvailable = true;
	public float jumpSpeed = 100f;
	private float startTime;
	private float journeyLength;
	public float enemyDamage = 10;
	public float searchRange = 20;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance (player.transform.position, transform.position) <= searchRange) {
			RotateAndMove (player.transform.position);
		}
		
		if (jumpAvailable && Vector2.Distance(player.transform.position, transform.position) <= maxJumpDist)
		{
			Vector2 direction = player.transform.position - transform.position;
			direction.Normalize ();
			Jump(direction);
		}

		// Slow down velocity from jumping
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		rb.velocity = Vector3.Lerp(rb.velocity, Vector2.zero, fracJourney);


		// LOOK AT PLAYER

	}

	void RotateAndMove(Vector3 position)
	{

		Vector3 diff = position - transform.position;
		diff.Normalize ();

		float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, rot_z - 90);


		transform.Translate (0, speed * Time.deltaTime, 0);
	}
	void Jump(Vector2 direction)
	{
		rb.AddForce (direction * jumpSpeed);
		startTime = Time.time;
		journeyLength = 15;
		jumpAvailable = false;
		StartCoroutine(wait());
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(jumpCooldown);
		jumpAvailable = true;
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag.Equals ("Player"))
			player.GetComponent<Unit> ().TakeDamage (enemyDamage); {

		}


	}


}

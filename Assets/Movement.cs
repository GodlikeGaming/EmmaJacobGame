using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody2D rb;
	public float speed = 100f;
	public float MAXIMUM_SPEED = 10f;
	public float rollSpeed = 10f;
	public float startTime;
	private bool rollAvailable = true;
	public float rollCooldown = 5;

	public float speedModifier = 1f;

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
			
			transform.position = Vector2.MoveTowards(transform.position, (Vector2) transform.position + velocity, speedModifier*speed * Time.deltaTime);
			//rb.position = (Vector2) transform.position + velocity * speed * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector2 direction = new Vector2 (veloX, veloY);
			direction.Normalize ();
			Roll (direction);
		}

		// Slow down velocity from rolling
		/*if (Time.time - startTime < 1) {
			var rot = transform.rotation;
			transform.rotation = rot * Quaternion.Euler(5, 0, 0); 
		}*/
		
		//transform.eulerAngles.x += 10;
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / 25;
		rb.velocity = Vector3.Lerp(rb.velocity, Vector2.zero, fracJourney);
	}

	void Roll(Vector2 direction)
	{
		rb.AddForce (direction * rollSpeed);
		startTime = Time.time;
		rollAvailable = false;
		StartCoroutine(wait(rollCooldown));
		StartCoroutine (AfterImage ());
	}

	IEnumerator AfterImage()
	{
		Color trans = new Color(255,255,255);
		trans.a = 0.5f;
		for (int i = 0; i < 3; i++) {
			GameObject temp = new GameObject ();
			SpriteRenderer sr = temp.AddComponent<SpriteRenderer> ();
			sr.sprite = GetComponent<SpriteRenderer> ().sprite;
			sr.sortingLayerName = "fire";
			sr.color = trans;
			temp.transform.position = transform.position;
			temp.AddComponent<FadeAndDestroy> ();
			yield return new WaitForSeconds (0.1f);
		}
	}
	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds(time);
		rollAvailable = true;
	}
	public void modifySpeed (float mod, float duration){
		StartCoroutine (modify (mod, duration));
	}
	IEnumerator modify(float mod, float duration)
	{
		speedModifier = mod * speedModifier;
		Debug.Log ("slow");
		yield return new WaitForSeconds(duration);
		speedModifier = speedModifier / mod;
		Debug.Log ("fast");
	}
}

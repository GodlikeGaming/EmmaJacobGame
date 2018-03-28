using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour {

	public float webCooldown = 5f;
	public float mod = 0.5f;
	public float duration = 5f;
	// Use this for initialization
	void Start () {
		StartCoroutine(wait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			Debug.Log("col");
			col.gameObject.GetComponent<Movement> ().modifySpeed (mod, duration);


		}	
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(webCooldown);
		Destroy (this.gameObject);
	}
}

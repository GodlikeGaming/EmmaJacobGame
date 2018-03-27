using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	LineRenderer lr;
	public GameObject laserEffect;
	public float laserDamage = 5f;

	// Use this for initialization
	void Start () {
		lr = gameObject.GetComponent<LineRenderer> ();
		ResetLR ();
	}

	void ResetLR()
	{
		lr.positionCount = 2;
		lr.SetPosition (0, transform.position);
		lr.SetPosition (1, transform.position);
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (0)) {
			//Debug.Log ("Mouse clicked!");
			Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition)  - transform.position);
			int layerMask = 1 << 9;
			RaycastHit2D hit = Physics2D.Raycast (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position, 10000, layerMask);
			if (hit.collider != null) {
				CreateParticles (hit.point);
				DrawLaser (hit.point);
				hit.transform.GetComponent<Unit> ().TakeDamage (laserDamage);
			} else {
				DrawLaser (Camera.main.ScreenToWorldPoint (Input.mousePosition));
			}
		} else {
			ResetLR ();
		}
	}
	void CreateParticles(Vector2 pos)
	{
		GameObject temp = Instantiate (laserEffect, pos, Quaternion.identity) as GameObject;
	}

	void DrawLaser(Vector2 hit)
	{
		lr.positionCount = 2;
		lr.SetPosition (0, transform.position);
		lr.SetPosition (1, hit);
	}
}

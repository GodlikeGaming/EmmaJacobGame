using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateExplode : MonoBehaviour {

	public GameObject[] cratePieces = new GameObject[6];
	public float speed = 5f;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < cratePieces.Length; i++)
		{
			GameObject piece = Instantiate (cratePieces [i], transform.position, Quaternion.identity) as GameObject;
			piece.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-1, 1), Random.Range (-1, 1)) * speed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

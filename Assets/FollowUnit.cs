using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowUnit : MonoBehaviour {

	public GameObject unit;
	public Vector2 offset = new Vector2 (0, 0.25f);
	private Image img;

	// Use this for initialization
	void Start () {
		//img = GetComponentInChildren<Image> ();
		img = transform.GetChild (0).GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (Vector2) unit.transform.position + offset;
		img.fillAmount = unit.GetComponent<Unit>().HP / unit.GetComponent<Unit> ().maxHP;
	}
}

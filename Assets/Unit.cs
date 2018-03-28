using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public float maxHP = 100;
	public float HP = 100;
	public GameObject ExplosionUnit;
	public GameObject web; 

	public GameObject coin;

	public GameObject healthBar;
	///public 

	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.Find("Canvas");
		GameObject temp = Instantiate (healthBar, canvas.transform) as GameObject;
		temp.GetComponent<FollowUnit> ().unit = this.gameObject;
	}
	


	public void TakeDamage(float damage)
	{
		HP -= damage;
		Debug.Log (HP + " " + transform.name);
		if (HP <= 0)
			Explosion ();
	}

	void Explosion()
	{
		if (this.tag.Equals("Spider"))
			Instantiate (web, transform.position, Quaternion.identity);
		if (this.tag.Equals("Crate"))
			Instantiate (coin, transform.position, Quaternion.identity);
		if (ExplosionUnit != null)
			Instantiate (ExplosionUnit, transform.position, Quaternion.identity);
		Destroy (this.gameObject);

	}
}

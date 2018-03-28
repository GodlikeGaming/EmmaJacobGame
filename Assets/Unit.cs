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
		if (healthBar != null) {
			GameObject temp = Instantiate (healthBar, canvas.transform) as GameObject;
			temp.GetComponent<FollowUnit> ().unit = this.gameObject;
		}
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
		if (this.tag.Equals ("Crate")) {
			for (int i = 0; i < 6; i++)
				Instantiate (coin, (Vector2) transform.position + new Vector2(Random.Range(-0.25f,0.25f), Random.Range(-0.25f,0.25f)), Quaternion.identity);
		}
		if (ExplosionUnit != null)
			Instantiate (ExplosionUnit, transform.position, Quaternion.identity);
		Destroy (this.gameObject);

	}
}

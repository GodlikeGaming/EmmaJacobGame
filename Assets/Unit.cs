using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public float maxHP = 100;
	public float HP = 100;
	public GameObject ExplosionUnit;
	public GameObject web; 
	public GameObject coin;
	// Use this for initialization
	void Start () {
		
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

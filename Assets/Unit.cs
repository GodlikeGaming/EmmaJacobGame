using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public float HP = 100;
	public GameObject ExplosionUnit;
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
		if (ExplosionUnit != null)
			Instantiate (ExplosionUnit, transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
}

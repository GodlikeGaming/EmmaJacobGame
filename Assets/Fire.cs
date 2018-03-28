using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	public ParticleSystem ps; 
	private bool onFire = false;
	private Unit unitInfo;

	// Use this for initialization
	void Start () {
		unitInfo = GetComponent<Unit> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!onFire) {
			if (unitInfo.HP < unitInfo.maxHP) {
				onFire = true;
				Instantiate (ps, transform.position, Quaternion.identity);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAndDestroy : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Color temp = sr.color;
		temp.a -= 0.01f;
		if (temp.a < 0)
			Destroy (this.gameObject);
		sr.color = temp;
	}
}

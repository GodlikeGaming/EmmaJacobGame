using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	void Update() {
		Vector3 targetPosition = target.transform.position;
		targetPosition.z = -10;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}

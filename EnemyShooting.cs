﻿using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);
	
	public GameObject bulletPrefab;
	
	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if(cooldownTimer <=0 ) {
			//SHOOT!
			Debug.Log ("Pew!");
			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * new Vector3(0, 1.5f, 0);
			
			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = gameObject.layer;
		}
	}
}
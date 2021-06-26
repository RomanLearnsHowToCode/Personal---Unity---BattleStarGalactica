using UnityEngine;
using System.Collections;

public class FacesPlayer : MonoBehaviour {

	float rotSpeed = 100f;

	Transform player;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	
		if(player == null) {
			GameObject go = GameObject.Find ("Ship_1");

			if(go != null) {
				player = go.transform;
	}
}

		if (player == null)
		return; 
	
		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
	}


}
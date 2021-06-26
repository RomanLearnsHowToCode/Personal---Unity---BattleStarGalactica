using UnityEngine;
using System.Collections;

public class MoveShip2 : MonoBehaviour {
	
	float maxSpeed = 7f;
	float rotSpeed = 270f;
	float shipBoundaryRadius = 0.5f;


	void Start()
	{

	}
	void Update(){

		// ROTATE the ship

		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;
		
		//Grab the Z euler angle
		float z = rot.eulerAngles.z;

		//Change the Z angle based on input
		z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

		// Recreate the quaternion
		rot = Quaternion.Euler( 0, 0, z);

		//Feed the quaternion into our rotaion
		transform.rotation = rot;

		// MOVE the ship
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

		pos += rot * velocity;

		//RESTRICT the player to the camera's boundaries


		//FIRST do vertical, because it's simpler
		if (pos.y > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize;

		}
		if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		// Now calculate the orthographic width based on the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height; // WARNING ! Will be weird!
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		if (pos.x + shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if (pos.x - shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}

		//Finally, update our position !!
		transform.position = pos; 
	}
}
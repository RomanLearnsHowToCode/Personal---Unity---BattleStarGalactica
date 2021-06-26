using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour {
	public Sprite Ship_0;
	public Sprite Ship_1;
	public float AngularSpeed = 360.0f;
	public float Speed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Move players ship
	void Update () {
		float tHorizontal = Input.GetAxis("Horizontal"); //Get the inputs for Horz & Vert
		float tVertical = Input.GetAxis("Vertical");
		transform.Rotate(0, 0, -tHorizontal * AngularSpeed * Time.deltaTime); //Rotate ship 
		transform.position += transform.up * tVertical * Speed * Time.deltaTime; //Move in direction of rotation
		float tHeight = Camera.main.orthographicSize;
		float tWidth = tHeight * Camera.main.aspect;
		
		if (transform.position.y > tHeight) {
			transform.position -= Vector3.up * 2 * tHeight;   //Offset to other side of screen
		} else if(transform.position.y<-tHeight) {
			transform.position -= Vector3.down* 2*tHeight;
		}
		
		if(transform.position.x>tWidth) {
			transform.position -= Vector3.right* 2* tWidth;
		} else if(transform.position.x<-tWidth) {
			transform.position -= Vector3.left* 2* tWidth;
		}

	}
}
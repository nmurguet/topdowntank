using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
	private Rigidbody2D rb; 
	public float moveSpeed; 


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();


	}
	
	// Update is called once per frame
	void Update () {
		Movement (); 
	}



	void Movement()
	{

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
			rb.velocity = new Vector2 (rb.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
		}

	}
}

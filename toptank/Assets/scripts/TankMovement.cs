using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
	private Rigidbody2D rb; 
	public float moveSpeed; 
	public float torque; 


	//Turret
	public GameObject turret; 
	public float smooth; 
	private float zVelocity = 2f;




	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();


	}
	
	// Update is called once per frame
	void Update () {
		Movement (); 
		MoveTurret (); 
	}



	void Movement()
	{

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {



			rb.AddRelativeForce(Vector2.up * moveSpeed * Input.GetAxisRaw("Vertical"));
		}


		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {

			rb.AddTorque (Input.GetAxisRaw ("Horizontal") * -torque);


		}

	}



	void MoveTurret()
	{
		transform.rotation = gameObject.transform.rotation; 

		Vector3 diff_left = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		diff_left.Normalize ();

		float rot_zl = Mathf.Atan2 (diff_left.y, diff_left.x) * Mathf.Rad2Deg;
		float zl = Mathf.SmoothDampAngle(turret.transform.eulerAngles.z,rot_zl + 92f, ref zVelocity, smooth);
		turret.transform.rotation = Quaternion.Euler (0f, 0f, zl);
	}
}

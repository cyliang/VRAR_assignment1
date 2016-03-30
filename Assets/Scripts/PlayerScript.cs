using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public Vector3 direction;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate() {
		if (Input.GetKey (KeyCode.Space)) {
			rb.velocity = rb.velocity * 0.95f;
		} else {
			rb.AddForce ((
				direction * Input.GetAxis ("Vertical") +
				Vector3.Cross(Vector3.up, direction) * Input.GetAxis ("Horizontal")				
			) * speed);
		}
	}
}

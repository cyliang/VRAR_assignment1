using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate() {
		if (Input.GetKey (KeyCode.Space)) {
			rb.velocity = rb.velocity * 0.95f;
		} else {
			rb.AddForce (new Vector3 (
				Input.GetAxis ("Horizontal"),
				0,
				Input.GetAxis ("Vertical")
			) * speed);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float maxHeight;
	public Vector3 direction;
	public Text scoreText, resultText;
	public AudioClip[] scoreClips;
	public GameObject scoreEffect;
	public AudioClip winSound, loseSound;

	Rigidbody rb;
	int score;
	bool gameOver;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		updateScore ();
		gameOver = false;
	}

	void Update() {
		if (transform.position.y < -10 && !gameOver) {
			resultText.text = "Game Over!!!!";
			resultText.color = Color.blue;
			resultText.gameObject.SetActive (true);
			AudioSource.PlayClipAtPoint (loseSound, transform.position);
			gameOver = true;
		}
	}
	
	void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.LeftControl) && transform.position.y < maxHeight) {
			rb.AddForce (Vector3.up * jumpSpeed);
		}
		if (Input.GetKey (KeyCode.Space)) {
			rb.velocity = rb.velocity * 0.95f;
		} else {
			rb.AddForce ((
				direction * Input.GetAxis ("Vertical") +
				Vector3.Cross(Vector3.up, direction) * Input.GetAxis ("Horizontal")				
			) * speed);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Treasure")) {
			other.gameObject.transform.parent.gameObject.SetActive (false);

			AudioSource.PlayClipAtPoint(scoreClips[Random.Range(0, scoreClips.Length)], transform.position);
			Instantiate (scoreEffect, other.transform.position, Quaternion.identity);

			score++;
			updateScore ();

			if (score == 10)
				win ();
		}
	}

	void updateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}

	void win() {
		resultText.text = "You Win!!!";
		resultText.color = Color.yellow;
		resultText.gameObject.SetActive (true);
		AudioSource.PlayClipAtPoint (winSound, transform.position);
	}
}

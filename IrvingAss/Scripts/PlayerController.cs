using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	//public int DeathCount = 0;

	private Rigidbody rb;
	private Vector3 defaultPos;
	void Start(){
		rb = GetComponent<Rigidbody> ();
		defaultPos = transform.position;
	}

	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter (Collider other)  {
		if (other.gameObject.CompareTag ("PickUpFast")) {
			speed += 10.0f;

			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("PickUpSlow")) {
			speed -= 10.0f;

			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("PickUpGravUp")) {
			rb.mass += 10.0f;

			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("PickUpGravReset")) {
			rb.mass = 1.0f;

			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag =="Water"){
			transform.position = defaultPos;
			rb.mass = 1.0f;
			speed = 10;
			rb.velocity = Vector3.zero;
		}
	}
}






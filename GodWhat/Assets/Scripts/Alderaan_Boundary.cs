using UnityEngine;
using System.Collections;

public class Alderaan_Boundary : MonoBehaviour {

	public GameObject game;
	public GameObject playerExplosion;
	//GameObject game = GameObject.Find ("GameController");

	void start(){
		//game = GameObject.Find ("Game Controller");
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
			Debug.Log ("tag works");
			Done_GameController gameController = (Done_GameController)game.GetComponent (typeof(Done_GameController));
			gameController.GameOver ();

			Destroy(GameObject.Find ("renderer"));
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
			
	}
}

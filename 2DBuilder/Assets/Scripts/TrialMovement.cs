using UnityEngine;
using System.Collections;

public class TrialMovement : MonoBehaviour {

	void Start(){
		gameObject.GetComponent<Rigidbody2D>().AddForce(
			new Vector2(-5f,0f) * 20f);
	}
}

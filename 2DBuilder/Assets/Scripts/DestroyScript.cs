using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	public int destroyedObjects;

	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
		destroyedObjects++;
	}
}

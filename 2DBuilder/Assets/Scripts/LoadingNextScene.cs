using UnityEngine;
using System.Collections;

public class LoadingNextScene : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Scaling Bar"){
			Application.LoadLevel(02);	
		}
	}
}

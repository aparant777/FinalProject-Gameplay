using UnityEngine;
using System.Collections;

public class CloudGenerator : MonoBehaviour {

	public float cloudMovementSpeed;
	public Sprite[] clouds;

	//public float maxTime = 3f;
	public float currentTime;

	void Start(){
		currentTime = 3f;
	}

	void Update(){
		if(currentTime < 0){
			Sprite cloud = Instantiate(clouds[Random.Range(0,clouds.Length)]);	//it will instantiate any one of the cloud.
			currentTime = 3f;
		}
		currentTime -= Time.deltaTime;
	}

	void MoveCloud(Sprite cloud){

	}
}

using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public GameObject[] ejectors;
	public GameObject[] objects;
	//will hold all the references for all the objects
	public float timeLimit;
	public float currentTime;
	public float EjectionPower;
	public AudioSource launchObject;

	void Start(){
		currentTime = Time.deltaTime;
	}

	void Update(){
		if(currentTime > timeLimit) {
		
			GameObject firedObject = (GameObject)Instantiate(objects[Random.Range(0,objects.Length)],
	                                 ejectors[Random.Range(0,ejectors.Length)].transform.position,
	                                 ejectors[Random.Range(0,ejectors.Length)].transform.rotation);
			//since instantiate returns a Object we need to cast it as a Gameobject.
			firedObject.GetComponent<Rigidbody2D>().velocity = transform.up * EjectionPower;
			currentTime = 0f;
			//launchObject.Play();

		}
		currentTime += Time.deltaTime;
	}
}

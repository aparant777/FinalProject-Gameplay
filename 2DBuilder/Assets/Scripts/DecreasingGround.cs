using UnityEngine;
using System.Collections;

public class DecreasingGround : MonoBehaviour {

	public DestroyScript ds;

	void Start(){
		ds = new DestroyScript();
	}

	void Update () {
		if(ds.destroyedObjects < ds.destroyedObjects++){
			transform.localScale = new Vector3(-3f,2f,0f);
		}
	}
}

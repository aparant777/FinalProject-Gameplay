using UnityEngine;
using System.Collections;

public class Scalling : MonoBehaviour {

	public float scaleSpeed = 6f;
	void Update () {
		transform.localScale += new Vector3(1f * Time.deltaTime * scaleSpeed,0f,0f);
	}
}

using System.Collections;
using Boomlagoon.JSON;
using System.Collections.Generic;
using UnityEngine;

public class FetchData : MonoBehaviour {

	private const string APIKEY = "adadadadadadad";
	private const string BaseURL = "http://sampletest123.getsandbox.com/";	///"http://ancient-silence-8671.getsandbox.com/";

	public string username="aparant";
	public string password="secretpassword";

	void Start(){
		//WWW www = new WWW (BaseURL + "hello");
		StartCoroutine (UploadUserDetails ());
		//StartCoroutine (ConvertToJSON (www));
	}

	IEnumerator ConvertToJSON(WWW www){
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
		} else {
			Debug.LogError (www.error);
		}
	}

	IEnumerator UploadUserDetails(){
		WWWForm form = new WWWForm ();
		form.AddField ("abcd", "abcd");

		WWW www = new WWW ((BaseURL + "setnumber"), form);
		yield return www;

		if (www.error == null) {
			Debug.Log (www.text);
		} else {
			Debug.LogError (www.error);
		}
	}
}
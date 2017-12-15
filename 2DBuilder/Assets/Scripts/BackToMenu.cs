using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	public void BackToMainMenu(){
		Application.LoadLevel(Application.loadedLevel);
	}
}

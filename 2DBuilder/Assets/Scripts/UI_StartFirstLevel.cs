using UnityEngine;
using System.Collections;

public class UI_StartFirstLevel : MonoBehaviour {

	public void AdvanceNextLevel(){
		Application.LoadLevel(1);
	}
}

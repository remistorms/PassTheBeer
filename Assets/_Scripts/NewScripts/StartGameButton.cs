using UnityEngine;
using System.Collections;

public class StartGameButton : MonoBehaviour {

	public string[] levelNames;


	void OnClick()
	{
		//Debug.Log("The mode selected is: " + ModeSelectScript.selectedButtonID);
		Application.LoadLevel(levelNames[ModeSelectScript.selectedButtonID]);
	}
}

using UnityEngine;
using System.Collections;

public class ModeSelectButton : MonoBehaviour {

	public int myButtonID;
	public ModeSelectScript myModeSelectScriptRef;

	void OnClick()
	{
		myModeSelectScriptRef.ModeSelect(myButtonID);
	}
}

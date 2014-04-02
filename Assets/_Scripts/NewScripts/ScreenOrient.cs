using UnityEngine;
using System.Collections;

public class ScreenOrient : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

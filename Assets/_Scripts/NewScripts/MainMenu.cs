using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GameObject[] panelMenu;


	void Start()
	{
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}

	// Use this for initialization
	void Awake () 
	{
		//Disables world select pannels 
		for (int i = 0; i < panelMenu.Length; i++) 
			{
			panelMenu[i].SetActive(false);
			}

		//Enables main menu panel
		panelMenu[0].SetActive(true);
	}

	public void PanelSelect(int panelID)
	{
	
		//Disables world select pannels 
		for (int i = 0; i < panelMenu.Length; i++) 
		{
			panelMenu[i].SetActive(false);
		}
		panelMenu[panelID].SetActive(true);
	}
}

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject[] worldSelect;


	// Use this for initialization
	void Awake () 
	{
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;

		//Disables world select pannels 
		for (int i = 0; i < worldSelect.Length; i++) 
			{
			worldSelect[i].SetActive(false);
			}

		//Enables main menu panel
		mainMenu.SetActive(true);
	}

	public void WorldSelect(int panelID)
	{
		mainMenu.SetActive(false);
		//Disables world select pannels 
		for (int i = 0; i < worldSelect.Length; i++) 
		{
			worldSelect[i].SetActive(false);
		}
		worldSelect[panelID].SetActive(true);
	}
}

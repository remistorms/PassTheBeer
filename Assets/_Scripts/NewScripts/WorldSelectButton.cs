using UnityEngine;
using System.Collections;

public class WorldSelectButton : MonoBehaviour {

	public MainMenu myMainMenuRef;
	public int worldPanelID = 0;

	void Awake()
	{
		myMainMenuRef = GameObject.Find("_MenuControl").GetComponent<MainMenu>();
	}

	void OnClick()
	{
		myMainMenuRef.PanelSelect(worldPanelID);
	}

}

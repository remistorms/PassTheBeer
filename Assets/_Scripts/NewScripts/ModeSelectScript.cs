using UnityEngine;
using System.Collections;

public class ModeSelectScript : MonoBehaviour {

	public  UILabel modeNameLabel;
	public  UILabel modeDescriptionLabel;
	public  UISprite[] myButtons;
	public  Color selectedColour;
	public  Color normalColour;
	public  static int selectedButtonID;


	// Use this for initialization
	void Start () 
	{

		modeNameLabel.text = "- Last Call -";
		modeDescriptionLabel.text = "It's the last call before closing time. You have two minutes to serve as many customers as you can. ";

		for (int i = 0; i < myButtons.Length; i++) 
			{
			myButtons[i].color = normalColour;
			}
		myButtons[0].color = selectedColour;
		selectedButtonID = 0;
	}

	// Update is called once per frame
	void Update () 
	
	{
		myButtons[selectedButtonID].color = selectedColour;
	}

	public  void ModeSelect(int modeSelectID)
	{
		selectedButtonID = modeSelectID;
		for (int i = 0; i < myButtons.Length; i++) 
		{
			myButtons[i].color = normalColour;
		}
		myButtons[modeSelectID].color = selectedColour;

		switch (modeSelectID) 
		
		{
			//Last Call Mode Selected
			case 0:
			modeNameLabel.text = "- Last Call -";
			modeDescriptionLabel.text ="It's the last call before closing time. You have two minutes to serve as many customers as you can. ";
			break;

			//Endless Mode Selected
			case 1:
			modeNameLabel.text = "- Endless -";
			modeDescriptionLabel.text ="See how long can you survive in this classic endless mode.";
			break;

			//How to Play Mode Selected
			case 2:
			modeNameLabel.text = "- How To Play -";
			modeDescriptionLabel.text ="Learn how to become a master bar tender.";
			break;
			
		}
	}

}

using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	public UIButton[] myButtonsToDissable;
	public GameObject myPauseScreen;

	void Start()
	{
		myPauseScreen.SetActive(false);
	}


	void OnClick()
	{
		Control.paused = !Control.paused;
		myPauseScreen.SetActive(Control.paused);

		Control.PauseGame(Control.paused);

		foreach (var button in myButtonsToDissable)
		
			{
				button.isEnabled = !Control.paused;
			}

	}
}

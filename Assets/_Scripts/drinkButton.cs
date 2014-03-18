using UnityEngine;
using System.Collections;

public class drinkButton : MonoBehaviour {

	public string drinkName;
	public gameControl myControl;
	public int throwForce = 100;
	public bool isPressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		Debug.Log(throwForce);

		if(isPressed)
		{
			//Start counting up the force each frame

			throwForce += 5;
			if(throwForce >= 500)
			{
				throwForce = 100;
			}
		}
	}

	void OnPress(bool buttonState)
	{
		isPressed = buttonState;

	}

	void OnClick()
	{
		myControl.SpawnDrink(drinkName,throwForce);
		throwForce = 100;
	}

	void OnGUI()
	{

	}
}

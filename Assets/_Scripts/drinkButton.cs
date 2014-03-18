using UnityEngine;
using System.Collections;

public class drinkButton : MonoBehaviour {

	public string drinkName;
	public gameControl myControl;
	public int throwForce = 0;
	public bool isPressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	
	{

	}

	public void OnPress(bool value)
	{
		myControl.ButtonIsPressed(value);
		if(value == false)
		{
			myControl.SpawnDrink(drinkName);
		}

	}

}

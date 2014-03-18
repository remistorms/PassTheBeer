using UnityEngine;
using System.Collections;

public class drinkButton : MonoBehaviour {

	public string drinkName;
	public gameControl myControl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		Debug.Log("On click was called.");
		myControl.SpawnDrink(drinkName);
	}
}

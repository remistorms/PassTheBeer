﻿using UnityEngine;
using System.Collections;

public class drinkButton : MonoBehaviour {

	public MainDrinksScript mainDrinkScriptRef;
	public GameObject buttonDrink;
	public Transform spawnPoint;
	public UISlider mySliderRef;
	public ChargeScript myChargeRef;
	bool isPressed = false;
	GameObject spawnedDrink;
	public GameObject slider;


	void Awake()
	{
		// Gets all the reference scripts needed
		mainDrinkScriptRef = GameObject.Find("Drinks").GetComponent<MainDrinksScript>();
		slider = GameObject.Find("Slider");
		mySliderRef = slider.GetComponent<UISlider>();
		myChargeRef = slider.GetComponent<ChargeScript>();
	
	}


	void Start()
	{
		slider.SetActive(false);
	}

	void OnPress()
	{

		slider.SetActive(true);
		myChargeRef.ResetCharge();
		if (spawnedDrink == null) 
			{
				spawnedDrink = mainDrinkScriptRef.SpawnDrink(buttonDrink, spawnPoint.transform);
			}
	}


	void OnClick()
	{
		//Sends a force to the drink drom the slider
		spawnedDrink.rigidbody2D.AddForce(new Vector2(mySliderRef.value * 500, 0));
		// Clears the spawned drink 
		spawnedDrink = null;
		//Disables the slider
		slider.SetActive(false);

	}


}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerScript : MonoBehaviour {

	SeatsScript mySeatScriptRef;
	GameObject customer;
	float moveSpeed;
	public GameObject myOccupiedSeat;
	public GameObject baloon;
	public string drinkWanted;
	public float waitingTime = 5f;
	public MainDrinksScript mainDrinksScriptRef;


	void Awake()
	{
		mySeatScriptRef = (GameObject.Find("BarSeats")).GetComponent<SeatsScript>();
		customer = this.gameObject;
		// Makes the baloon invisible at start
		baloon.SetActive(false);
		// Empties the current sprite slot
		mainDrinksScriptRef = (GameObject.Find("Drinks")).GetComponent<MainDrinksScript>();

	}

	// Use this for initialization
	void Start () 
	{
		FindASeat();

	}


	void FindASeat()
	{
		//Checks to see how many empty seats are
		int seatsRemaining = mySeatScriptRef.emptySeats.Count;

		// The rest only happens if there is at least one empty seat
		if (seatsRemaining > 0) 
		
			{

			// Random number to pick a seat from the remaining ones
			int seatNumber = Random.Range(0, seatsRemaining);
			myOccupiedSeat = mySeatScriptRef.emptySeats[seatNumber];

			//Move character to chosen seat at random speed
			moveSpeed = Random.Range(0.4f, 2.0f);
			iTween.MoveTo(customer, iTween.Hash("x", mySeatScriptRef.emptySeats[seatNumber].transform.position.x, "speed", moveSpeed, "easetype", "linear", "oncomplete", "OrderDrink", "oncompletetarget", customer));

			//Adds taken seat to the occupied list
			mySeatScriptRef.occupiedSeats.Add(mySeatScriptRef.emptySeats[seatNumber]);

			//Removes taken seat from the empty Seats list
			mySeatScriptRef.emptySeats.Remove(mySeatScriptRef.emptySeats[seatNumber]);

			}

		// If no seats available, destroy customer.
		else { Destroy(customer, 0.1f); }

	}

	void OrderDrink()
	{
		// Makes baloon visible
		baloon.SetActive(true);
		//Picks a random drink from the Drinks Object and displays it
		int drinkID = Random.Range(0, mainDrinksScriptRef.allDrinks.Length);
		mainDrinksScriptRef.DisplayDrink(mainDrinksScriptRef.allDrinks[drinkID],baloon.transform);
		drinkWanted = mainDrinksScriptRef.allDrinks[drinkID].name;
		drinkWanted = drinkWanted + "(Clone)";

	}

	void Leave()
	{
		// Moves the character outside the bar at a random speed
		moveSpeed = Random.Range(0.5f, 1.5f);
		iTween.MoveTo(customer, iTween.Hash("x", -10, "speed", moveSpeed, "easetype", "linear", "oncomplete", "SelfDestroy", "oncompletetarget", customer));

		// Returns the occupied seat back to the empty seats list
		mySeatScriptRef.emptySeats.Add (myOccupiedSeat);
		mySeatScriptRef.occupiedSeats.Remove(myOccupiedSeat);
	}

	void SelfDestroy()
	{
		Destroy(this.gameObject, 1);
	}
	
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerScript : MonoBehaviour {

	SeatsScript mySeatScriptRef;
	GameObject customer;
	float moveSpeed;
	public GameObject myOccupiedSeat;


	void Awake()
	{
		mySeatScriptRef = (GameObject.Find("BarSeats")).GetComponent<SeatsScript>();
		customer = this.gameObject;
	}

	// Use this for initialization
	void Start () 
	{
		FindASeat();

	}
	
	// Update is called once per frame
	void Update () {
	
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

		else { Debug.Log("No more seats"); }

	}

	void OrderDrink()
	{

	}

	void Leave()
	{
		moveSpeed = Random.Range(1.0f, 2.5f);
		iTween.MoveTo(customer, iTween.Hash("x", -10, "speed", moveSpeed, "easetype", "linear", "oncomplete", "SelfDestroy", "oncompletetarget", customer));
		mySeatScriptRef.emptySeats.Add (myOccupiedSeat);
	}

	void SelfDestroy()
	{

	}
}

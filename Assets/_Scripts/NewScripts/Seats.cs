using UnityEngine;
using System.Collections;
using System.Collections.Generic; //This is needed to use lists

public class Seats : MonoBehaviour {
	
	public List<GameObject> emptySeats = new List<GameObject>();
	public List<GameObject> occupiedSeats = new List<GameObject>();

	void Start()
	{
	
	}

	public GameObject AssignSeat()
	{
		// Variable to store the seat taken
		GameObject seatTaken = null;

		//This will happen if there are still seats remaining
		if (emptySeats.Count > 0) 
			{

				//Generate a random number between the remaining seats	
				int seatNumber = Random.Range(0, emptySeats.Count);
				//Assigns that seat to the seatTaken variable	
				seatTaken = emptySeats[seatNumber];
				//Adds the selected seat to the occupied seat list
				occupiedSeats.Add(emptySeats[seatNumber]);
				//Removes the selected seat from the empty seat list
				emptySeats.Remove(emptySeats[seatNumber]);

				

			}
		//This will happen if there are no seats left
		else 
			{
			Debug.Log("No empty seats available");
			}

		return seatTaken;


	}

	public void FreeSeat(GameObject freedSeat)
	{
		//Removes the seat passed by the Customer from the occupiedSeats List
		occupiedSeats.Remove(freedSeat);
		//Adds the seat passed by the Customer to the emptySeats List
		emptySeats.Add(freedSeat);
	}
}

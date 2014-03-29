using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

	//External Scripts References
	public Seats mySeatReference;
	public Control myControlRef;
	public DrinksContainer myDrinksContainerRef;

	// Public Variables
	public string name;
	public float walkSpeed = 2.5f;
	public int drinkLimit = 1;
	public GameObject drinkWanted;
	public GameObject baloon;
	public Transform spawnPoint;
	
	// Components needed (WONT BE PUBLIC)
	public SpriteRenderer customer_Renderer;
	public BoxCollider2D customer_Collision;
	public GameObject seatTaken;
	
	//This Game Object Reference
	GameObject thisCustomer;

	void Awake () 
	{
		// Gets a reference of the components
		thisCustomer = this.gameObject;
		customer_Renderer = thisCustomer.GetComponent<SpriteRenderer>();
		customer_Collision = thisCustomer.GetComponent<BoxCollider2D>();
		//Initial Status of some elements
		thisCustomer.name = name;
		baloon.SetActive(false);

	}

	void Start () 
	{
		GrabASeat();
	}

	void GrabASeat()
	{
		//Assigns the seat taken
		seatTaken = mySeatReference.AssignSeat();
		//Moves the character to the specified seat
		iTween.MoveTo(thisCustomer, iTween.Hash("position", seatTaken.transform.position, "speed", walkSpeed,"easetype", "linear", "oncomplete", "OrderDrink","oncompletetarget", thisCustomer));
	}

	IEnumerator OrderDrink()
	{
		//Activates the baloon Game Object to display de trink
		baloon.SetActive(true);

		// Picks a random drink from the Drinks Container Array 
		drinkWanted = myDrinksContainerRef.AllDrinks[Random.Range(0, myDrinksContainerRef.AllDrinks.Length)];

		//Calls the Display Drink function from the control Script after waiting for a short time
		yield return new WaitForSeconds(Random.Range(0.5f, 3.0f));
		myControlRef.DisplayDrink(drinkWanted, spawnPoint);

		//Time to wait before leaving the seat
		yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));

		Leave ();
	}

	void Leave()
	{
		//Stops coroutine Order drink
		StopCoroutine("OrderDrink");
		//Hides baloon
		baloon.SetActive(false);
		// Moves away from screen
		iTween.MoveTo(thisCustomer, iTween.Hash("x", 10, "speed", walkSpeed * 1.2f,"easetype","linear", "oncomplete", "SelfDestroy", "oncompletetarget", thisCustomer));

	}

	void SelfDestroy()
	{
		Destroy(thisCustomer, 0.5f);
	}
}

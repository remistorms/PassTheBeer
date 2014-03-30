using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

	//External Scripts References (These were public before)
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
	public GameObject drinkReceived;
	
	// Components needed (WONT BE PUBLIC)
	public SpriteRenderer customer_Renderer;
	public BoxCollider2D customer_Collision;
	public GameObject seatTaken;
	
	//This Game Object Reference
	GameObject thisCustomer;

	void Awake () 
	{
		// Gets a reference of Main Scripts inside the Game Objects
		mySeatReference = GameObject.Find("_Seats").GetComponent<Seats>();
		myControlRef = GameObject.Find("_Control").GetComponent<Control>();
		myDrinksContainerRef = GameObject.Find("_DrinksContainer").GetComponent<DrinksContainer>();

		//Gets reference of this game object components
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


		//Calls the Display Drink function from the control Script after waiting for a short time

		yield return new WaitForSeconds(Random.Range(0.2f, 1.0f));

		// Picks a random drink from the Drinks Container Array 
		drinkWanted = myDrinksContainerRef.AllDrinks[Random.Range(0, myDrinksContainerRef.AllDrinks.Length)];

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
		//Frees the occupied seat
		mySeatReference.FreeSeat(seatTaken);

	}

	void SelfDestroy()
	{
		Destroy(thisCustomer, 0.5f);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.rigidbody2D.velocity.x == 0 && drinkWanted != null)
		{
			//Debug.Log("A " + other.name + " has stopped in front of me");
			drinkReceived = other.gameObject;

			if (drinkReceived.name == drinkWanted.name) 
				
			{
				//Pays for the drink
				Debug.Log("Thats my drink, Ill pay now");
				//Dissables customer collider so it doesnt keep checking
				thisCustomer.collider2D.enabled = false;
				myControlRef.playerScore += drinkReceived.GetComponent<Drink>().price;

				StartCoroutine(WaitAndLeave());
				//Leave();
			}
		}
	}

	void CheckDrink()
	{
		if (drinkReceived == drinkWanted) 
		
			{
				//Pays for the drink
			Debug.Log("Thats my drink, Ill pay now");
			myControlRef.playerScore += drinkReceived.GetComponent<Drink>().price;

			Leave();
			}
		else 
			{
			//Debug.Log("That's a  " + drinkReceived.name + ", I ordered a " + drinkWanted.name);
			}
	}

	IEnumerator WaitAndLeave()
	{
		yield return new WaitForSeconds(1.5f);
		Leave();
		StopCoroutine("WaitAndLeave");

	}


}

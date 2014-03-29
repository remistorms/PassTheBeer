using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// External Script References
	DrinksContainer myDrinksContainerRef;
	Drink myDrinkRef;
	GameObject currentDrink;
	public Seats mySeatsRef;

	//Public variables
	public float playerScore;
	public float forceMultiplier;
	public GameObject[] customers;
	public Transform customerSpawner;

	void Awake()
	{
		// Automatic find game objects and references
		myDrinksContainerRef = GameObject.Find("_DrinksContainer").GetComponent<DrinksContainer>();
		mySeatsRef = GameObject.Find("_Seats").GetComponent<Seats>();
	}

	void Start()
	{
		InvokeRepeating("SpawnCustomer", 1, Random.Range(3f, 5f));
	}

	public void SpawnDrink(GameObject drinkToSpawn, Transform spawningPoint)
	{
		GameObject SpawnedDrink = Instantiate(drinkToSpawn, spawningPoint.position, spawningPoint.rotation) as GameObject;
	}

	public void DisplayDrink(GameObject drinkToSpawn, Transform spawningPoint)
	{

		GameObject SpawnedDrink = Instantiate(drinkToSpawn, spawningPoint.position, spawningPoint.rotation) as GameObject;
		SpawnedDrink.transform.parent = spawningPoint.gameObject.transform;
		//Spanws a copy of the drink wanted but destroys the rigid body
		Destroy(SpawnedDrink.rigidbody2D);
		currentDrink = SpawnedDrink;
	
	}

	public void ThrowDrink(float force)
	{
		// Add a force to the spawned drink
		currentDrink.rigidbody2D.AddForce(new Vector2(force * forceMultiplier, 0));

	}

	void SpawnCustomer()
	{
		// Only instantiates a customer if there is at least one empty seat
		if (mySeatsRef.emptySeats.Count > 0) 
			{
			Instantiate(customers[Random.Range(0, customers.Length)], customerSpawner.position, customerSpawner.rotation);
			}

	}

	void Update()

	{
		/*if (Input.GetKeyDown(KeyCode.Space)) {

			SpawnCustomer();
				}*/
	}

}

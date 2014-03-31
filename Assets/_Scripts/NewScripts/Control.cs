using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// External Script References
	DrinksContainer myDrinksContainerRef;
	Drink myDrinkRef;
	GameObject currentDrink;
	public Seats mySeatsRef;

	//Public variables
	//float baseForce = 1;
	public float playerScore;
	public float forceMultiplier;
	public GameObject[] customers;
	public Transform customerSpawner;
	public Transform drinkSpawner;

	// Other variables
	public bool drinkServed = false;
	GameObject spawnedDrink;
	GameObject displayedDrink;

	void Awake()
	{
		// Automatic find game objects and references
		myDrinksContainerRef = GameObject.Find("_DrinksContainer").GetComponent<DrinksContainer>();
		mySeatsRef = GameObject.Find("_Seats").GetComponent<Seats>();
		drinkSpawner = GameObject.Find("DrinkSpawner").transform;
	}

	void Start()
	{
		InvokeRepeating("SpawnCustomer", 1, Random.Range(3f, 5f));
	}

	public void SpawnDrink(GameObject drinkToSpawn, Transform spawningPoint)
	{
		// Spawns a drink on the bar if there is no drink served currently
		if (drinkServed == false) 
		
			{
				spawnedDrink = Instantiate(drinkToSpawn, spawningPoint.position, spawningPoint.rotation) as GameObject;
				drinkServed = true;
			}

	}

	public void DisplayDrink(GameObject drinkToSpawn, Transform spawningPoint)
	{

		displayedDrink = Instantiate(drinkToSpawn, spawningPoint.position, spawningPoint.rotation) as GameObject;
		displayedDrink.transform.parent = spawningPoint.gameObject.transform;
		//Spanws a copy of the drink wanted but destroys the rigid body
		Destroy(displayedDrink.rigidbody2D);
		currentDrink = displayedDrink;
	
	}

	public void ThrowDrink(float baseForce)
	{
		if (drinkServed) 
		{
			// Add a force to the spawned drink
			spawnedDrink.rigidbody2D.AddForce(new Vector2(baseForce * forceMultiplier, 0));
			// Opens up the option to spawn another drink
			drinkServed = false;
			StartCoroutine(SelfDestroy(spawnedDrink));

		}

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

	IEnumerator SelfDestroy(GameObject drinkToDestroy)
	{
		yield return new WaitForSeconds(3.0f);
		iTween.FadeTo(drinkToDestroy, iTween.Hash("alpha", 0, "time", 0.1f, "looptype", "pingPong"));
		yield return new WaitForSeconds(1.5f);
		Destroy(drinkToDestroy);
	}
}

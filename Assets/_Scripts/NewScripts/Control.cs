using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// External Script References
	DrinksContainer myDrinksContainerRef;
	Drink myDrinkRef;
	GameObject currentDrink;
	public Seats mySeatsRef;
	CountDownTimer myCountDownTimerRef;
	public LevelStats myLevelStatsRef;

	//Public variables
	//float baseForce = 1;
	public float playerScore;
	public float forceMultiplier;
	public GameObject[] customers;
	public Transform customerSpawner;
	public Transform drinkSpawner;
	public bool isTimed = false;
	public static bool paused = false;

	// Other variables
	public bool drinkServed = false;
	GameObject spawnedDrink;
	GameObject displayedDrink;

	void OnLevelWasLoaded()
	{
		ResetScene();
	}

	public void ResetScene()
	{
		// Reset all values here
		playerScore = 0;
		CountDownTimer.Timeleft = 120;
		paused = false;
	}

	void Awake()
	{
		ResetScene();

		if (isTimed) 
		{
			myCountDownTimerRef = GameObject.Find("TimerLabel").GetComponent<CountDownTimer>();
		}
		myLevelStatsRef = this.gameObject.GetComponent<LevelStats>();
		// Automatic find game objects and references
		myDrinksContainerRef = GameObject.Find("_DrinksContainer").GetComponent<DrinksContainer>();
		mySeatsRef = GameObject.Find("_Seats").GetComponent<Seats>();
		drinkSpawner = GameObject.Find("_DrinkSpawner").transform;
	}

	void Start()
	{
		//Screen rotation 
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;

		//Starts spawning Customers
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
	public static void PauseGame(bool isPaused)
	{
		if (isPaused == false)
		{
			Time.timeScale = 1f;
			isPaused = false;
		}
		else
		{
			Time.timeScale = 0f;
			isPaused = true;
			
		}
	}

	public void Update()
	{
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;

		if (myCountDownTimerRef != null && myCountDownTimerRef.isTimeUp == true) 
			
		{
			Debug.Log("Level has ended FUCK !!!");
			EndLevel();
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
			spawnedDrink.rigidbody2D.AddForce(new Vector2(100 + (baseForce * forceMultiplier), 0));
			myLevelStatsRef.drinksServed += 1;
			// Opens up the option to spawn another drink
			drinkServed = false;

			//This makes the drink disapear
			//StartCoroutine(SelfDestroy(spawnedDrink));

		}

	}

	void SpawnCustomer()
	{
		// Only instantiates a customer if there is at least one empty seat
		if (mySeatsRef.emptySeats.Count > 0) 
			{
			Instantiate(customers[Random.Range(0, customers.Length)], customerSpawner.position, customerSpawner.rotation);
			myLevelStatsRef.customerSpawned += 1;
			}

	}

	IEnumerator SelfDestroy(GameObject drinkToDestroy)
	{

			yield return new WaitForSeconds(3.0f);

		if (drinkToDestroy != null) 
		{
			iTween.FadeTo(drinkToDestroy, iTween.Hash("alpha", 0, "time", 0.1f, "looptype", "pingPong"));
		}
			yield return new WaitForSeconds(1.5f);
			Destroy(drinkToDestroy);

	}

	void EndLevel()
	{
		CancelInvoke();
	}
}

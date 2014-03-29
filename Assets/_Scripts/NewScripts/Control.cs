using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// External Script References
	DrinksContainer myDrinksContainerRef;
	Drink myDrinkRef;
	GameObject currentDrink;

	//Public variables
	public float playerScore;
	public float forceMultiplier;


	public void SpawnDrink(GameObject drinkToSpawn, Transform spawningPoint)
	{
		GameObject SpawnedDrink = Instantiate(drinkToSpawn, spawningPoint.position, spawningPoint.rotation) as GameObject;
	}

	public void DisplayDrink(GameObject drinkToSpawn, Transform spawningPoint)
	{
		Debug.Log("Display Drink Called");
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

}

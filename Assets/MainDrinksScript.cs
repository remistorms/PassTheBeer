using UnityEngine;
using System.Collections;

public class MainDrinksScript : MonoBehaviour {

	public GameObject[] allDrinks;

	// Function to spawn a drink, Takes 2 arguments
	public GameObject SpawnDrink(GameObject drink, Transform drinkTransform)
	{
		GameObject spawnedDrink = Instantiate(drink, drinkTransform.position, drinkTransform.rotation) as GameObject;
		spawnedDrink.AddComponent<Rigidbody2D>();
		spawnedDrink.AddComponent<DrinkScript>();
		return spawnedDrink;
	}

	// Function to display a drink, Takes 2 arguments
	public void DisplayDrink(GameObject drink, Transform drinkTransform)
	{
		GameObject DisplayedDrink = Instantiate(drink, drinkTransform.position, drinkTransform.rotation) as GameObject;
		Destroy(DisplayedDrink.rigidbody2D);
		Destroy(DisplayedDrink.collider2D);
	}

	// Function to randomize adrink
	public GameObject RandomizeDrink()
	{
		GameObject randomDrink = allDrinks[Random.Range(0, allDrinks.Length)];
		return randomDrink;
	}

}

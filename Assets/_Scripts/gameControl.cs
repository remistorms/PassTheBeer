using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

	public GameObject beer;
	public GameObject margarita;
	public GameObject bloodyMary;
	public GameObject drinkSpawner;
	public string typeOfDrink;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			SpawnDrink(typeOfDrink);
		}
	}

	// function to spawn drinks
	public void SpawnDrink(string drinkType)
	{
		switch (drinkType) 
		
		{
		case "beer":
				Instantiate(beer, drinkSpawner.transform.position, drinkSpawner.transform.rotation);
			break;

		case "margarita":
			Instantiate(margarita, drinkSpawner.transform.position, drinkSpawner.transform.rotation);
			break;

		case "bloodyMary":
				Instantiate(bloodyMary, drinkSpawner.transform.position, drinkSpawner.transform.rotation);
			break;

		} //cierre de switch
	} //close SpawnDrinks

	public static void MyStaticMethod()
	{
		Debug.Log("My static method has been called.");
	}
}

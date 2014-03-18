using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

	public GameObject beer;
	public GameObject margarita;
	public GameObject bloodyMary;
	public GameObject drinkSpawner;
	//public float Force = 10f;
	public string typeOfDrink;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// function to spawn drinks
	public void SpawnDrink(string drinkType, float throwForce)
	{
		switch (drinkType) 
		
		{
		case "beer":
			beer = Instantiate(beer, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
			drinkScript be_drinkScriptRef = beer.GetComponent<drinkScript>();
			beer.rigidbody2D.AddForce(new Vector2(throwForce , 0));
			break;

		case "margarita":
			margarita = Instantiate(margarita, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
			drinkScript mr_drinkScriptRef = margarita.GetComponent<drinkScript>();
			margarita.rigidbody2D.AddForce(new Vector2(throwForce , 0));
			break;

		case "bloodyMary":
			bloodyMary = Instantiate(bloodyMary, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
			drinkScript bm_drinkScriptRef = bloodyMary.GetComponent<drinkScript>();
			bloodyMary.rigidbody2D.AddForce(new Vector2(throwForce , 0));
			break;

		} //cierre de switch
	} //close SpawnDrinks
	
}

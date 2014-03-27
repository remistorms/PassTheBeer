using UnityEngine;
using System.Collections;

public class drinkButton : MonoBehaviour {

	public MainDrinksScript mainDrinkScriptRef;
	public GameObject buttonDrink;
	public Transform spawnPoint;

	void Awake()

	{

	}

	void OnClick()
	{
		Debug.Log("I was clicked !!!");
		mainDrinkScriptRef.SpawnDrink(buttonDrink, spawnPoint.transform);
	}



}

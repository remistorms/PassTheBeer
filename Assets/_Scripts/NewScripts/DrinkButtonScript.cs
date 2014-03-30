using UnityEngine;
using System.Collections;

public class DrinkButtonScript : MonoBehaviour {

	//External References
	public DrinksContainer myDrinksContainerRef;
	public Control myControlRef;

	public int drinkID;

	void Awake()
	{
		myDrinksContainerRef = GameObject.Find("_DrinksContainer").GetComponent<DrinksContainer>();
		myControlRef = GameObject.Find("_Control").GetComponent<Control>();
	}

	void OnPress()
	{

		myControlRef.SpawnDrink(myDrinksContainerRef.AllDrinks[drinkID], myControlRef.drinkSpawner);
		myControlRef.drinkServed = true;
	}

	void OnClick()
	{
		if (myControlRef.drinkServed) 
			{
				myControlRef.ThrowDrink();
			}
	}
}

using UnityEngine;
using System.Collections;

public class DrinkButtonScript : MonoBehaviour {

	//External References
	public DrinksContainer myDrinksContainerRef;
	public Control myControlRef;
	public UISlider mySliderRef;
	public PowerCharge myPowerChargeRef;

	public int drinkID;

	void Awake()
	{
		myDrinksContainerRef = GameObject.Find("_DrinksContainer").GetComponent<DrinksContainer>();
		myControlRef = GameObject.Find("_Control").GetComponent<Control>();
		mySliderRef = GameObject.Find("PowerCharge").GetComponent<UISlider>();
		myPowerChargeRef = GameObject.Find("PowerCharge").GetComponent<PowerCharge>();
	}

	void OnPress()
	{
		myPowerChargeRef.ChargeBar();
		myControlRef.SpawnDrink(myDrinksContainerRef.AllDrinks[drinkID], myControlRef.drinkSpawner);
		myControlRef.drinkServed = true;
	}

	void OnClick()
	{
		if (myControlRef.drinkServed) 
			{
				myControlRef.ThrowDrink(mySliderRef.value);
			myPowerChargeRef.ResetBar();
				
			}
	}
}

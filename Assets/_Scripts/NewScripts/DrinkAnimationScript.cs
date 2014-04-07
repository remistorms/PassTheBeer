using UnityEngine;
using System.Collections;

public class DrinkAnimationScript : MonoBehaviour {

	public Transform minArmPosition;
	public Transform maxArmPosition;
	public Transform handPosition;
	public GameObject customerArm;
	float drinkingSpeed = 0.8f;
	GameObject myDrinkTaken;

	void Awake()
	{
		//Parents the arm to the customer Sprite
		//customerArm.transform.parent = this.gameObject.transform;
		//Zeroes out the position of the arm
		//customerArm.transform.position = new Vector2(0,minArmPosition.transform.position.y);
	}

	void Start()
	{
		customerArm.SetActive(false);
	}

	public void BottomsUp(GameObject drinkTaken)
	{
		myDrinkTaken = drinkTaken;
		//Makes the arm visible
		customerArm.SetActive(true);
		// Parent the drink to the Hand
		drinkTaken.transform.parent = handPosition.transform;
		//To prevent from destroying the drink and falling again
		//Destroy(drinkTaken.GetComponent<Drink>());
		Destroy(drinkTaken.rigidbody2D);
		//Zeroes out the position of the drink in relation to the hand
		drinkTaken.transform.localPosition = new Vector2(0,0);
		drinkTaken.renderer.sortingOrder = -1;
		StartCoroutine(PlayAnimation());

	}

	IEnumerator PlayAnimation()
	{
		//yield return new WaitForSeconds(.5f);
		//iTween parameters:

		for (int i = 0; i < 1; i++) 
		
			{
			yield return new WaitForSeconds(1.0f);
			//Hand down
			Hashtable myHash = iTween.Hash("name","drinkAnimation","y", 0.3f,"speed", drinkingSpeed,"easetype", "linear");
			iTween.MoveAdd(customerArm, myHash);

			//Wait before next zip
			yield return new WaitForSeconds(1.0f);
			myDrinkTaken.GetComponent<Drink>().drink_Renderer.sprite = myDrinkTaken.GetComponent<Drink>().emptySprite;

			//Hand Up
			Hashtable myHash2 = iTween.Hash("name","drinkAnimation2","y", -0.3f,"speed", drinkingSpeed,"easetype", "linear");
			iTween.MoveAdd(customerArm, myHash2);
			}

		yield return new WaitForSeconds(1);

		customerArm.SetActive(false);
		myDrinkTaken.transform.parent = null;
		StartCoroutine(DestroyEmptyGlass());
		Destroy(myDrinkTaken,2.5f);
	
	}

	public IEnumerator DestroyEmptyGlass()
	{
		yield return new WaitForSeconds(1.5f);
		
		if (myDrinkTaken != null) 
		{
			iTween.FadeTo(myDrinkTaken, iTween.Hash("name","FadingEmptyDrink","alpha", 0, "time", 0.1f, "looptype", "pingPong"));
		}
		yield return new WaitForSeconds(1.5f);


	
		
	}
}

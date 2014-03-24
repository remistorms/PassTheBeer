using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	public int drinkWanted;
	public int drinkRecieved;
	public SpriteRenderer drinkWantedSprite;
	public gameControl myControlRef;
	public drinkScript myDrinkScriptRef;
	public Sprite[] myDrinkSprites;


	// Use this for initialization
	void Start () 
	{
		OrderDrink();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			OrderDrink();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		myDrinkScriptRef = other.GetComponent<drinkScript>();
		if(myDrinkScriptRef.hasStopped == true)
		{

			if(drinkWanted == myDrinkScriptRef.drinkID)
			{
				myControlRef.playerScore += 100;
			}
			
			if(drinkWanted != myDrinkScriptRef.drinkID)
			{
				myControlRef.playerScore -= 100;
			}

		}

	}

	void OrderDrink()
	{
		int drinkID = Random.Range(0,3);

		switch(drinkID)
		{
		case 0:
			Debug.Log("I want Beer");
			drinkWanted = 0;
			drinkWantedSprite.sprite = myDrinkSprites[0];

			break;

		case 1:
			Debug.Log("I want Margarita");
			drinkWanted = 1;
			drinkWantedSprite.sprite = myDrinkSprites[1];

			break;

		case 2:
			Debug.Log("I want BloodyMary");
			drinkWanted = 2;
			drinkWantedSprite.sprite = myDrinkSprites[2];

			break;
		}
	}
}

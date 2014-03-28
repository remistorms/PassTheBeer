using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	public int drinkWanted;
	public int drinkRecieved;
	public SpriteRenderer drinkWantedSprite;
	public gameControl myControlRef;
	public DrinkScript myDrinkScriptRef;
	public Sprite[] myDrinkSprites;
	GameObject customer;
	public GameObject balloon;
	GameObject drinkObject;


	void Awake()
	{
		customer = this.gameObject;
		GameObject controlObjectRef = GameObject.Find("GameController");
		myControlRef = controlObjectRef.GetComponent<gameControl>();
	}

	// Use this for initialization
	void Start () 
	{
		FindASeat();
		//OrderDrink();
		CheckDrink();
		Pay();

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerStay2D(Collider2D other)
	{
		myDrinkScriptRef = other.GetComponent<DrinkScript>();
		drinkObject = other.gameObject;
		CheckDrink();
	}

	void FindASeat()
	{
		float amtToMove = Random.Range(0.5f, 3.0f);
		float moveSpeed = Random.Range(0.2f, 1.5f);
		iTween.MoveAdd(customer, iTween.Hash("x", -amtToMove, "speed", moveSpeed, "oncomplete", "OrderDrink", "oncompletetarget", this.gameObject, "easetype", "linear"));
	}

	void OrderDrink()
	{
		balloon.SetActive(true);
		Debug.Log("Order Drink Has been called");
		int drinkID = Random.Range(0,myDrinkSprites.Length);
		drinkWanted = drinkID;
		drinkWantedSprite.sprite = myDrinkSprites[drinkID];
	}

	void CheckDrink()
	{
		/*Debug.Log("Check Drink Function");


		if(myDrinkScriptRef.hasStopped == true)
		{
			
			if(drinkWanted == myDrinkScriptRef.drinkID)
			{

				Destroy(drinkObject, 0.2f);
				balloon.SetActive(false);
				Pay ();
				StartCoroutine("Wait");
				Leave();
				StopCoroutine("Wait");
			}
			
			if(drinkWanted != myDrinkScriptRef.drinkID)
			{
				Debug.Log("Not my drink");
				Destroy(drinkObject, 0.2f);
			}
			
		}*/
	}

	void Pay()
	{
		Debug.Log("Pay Function");
		//myControlRef.playerScore += myDrinkScriptRef.drinkPrice; 
	}

	void Leave()
	{
		Debug.Log("Leave Function");
		iTween.MoveAdd(customer, iTween.Hash("x", 3.3f, "speed", 1, "easetype", "linear", "oncomplete", "Destroy", "oncompletetarget", this.gameObject));
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}

	IEnumerator Wait() 
	
	{
		yield return new WaitForSeconds(3.5f);
	}


}

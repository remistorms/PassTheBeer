using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

	public GameObject beer;
	public GameObject margarita;
	public GameObject bloodyMary;
	public GameObject drinkSpawner;
	public float force = 10f;
	public int throwForce = 0;
	public bool countForce = false;
	public float playerScore = 1000;
	int lastForce;


	void RestoreDrinks()
	{
		beer = GameObject.Find("Beer");
		margarita = GameObject.Find("Margarita");
		bloodyMary = GameObject.Find ("BloodyMary");
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(countForce)
		
		{
			if(throwForce < 100)
			{
				throwForce += 1;
				
				if (throwForce >= 100) 
				{
					throwForce = 0;
				}
			}
		}

	}

	// function to spawn drinks
	public void SpawnDrink(string drinkName)
	{
		switch (drinkName) 
		
		{
		case "beer":
			beer = Instantiate(beer, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
			beer.AddComponent<SelfDestroy>();
			drinkScript be_drinkScriptRef = beer.GetComponent<drinkScript>();
			beer.rigidbody2D.AddForce(new Vector2(throwForce * force , 0));
			lastForce = throwForce;
			throwForce = 0;
			playerScore -= 2.5f;
			RestoreDrinks();
			break;

		case "margarita":
			margarita = Instantiate(margarita, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
			margarita.AddComponent<SelfDestroy>();
			drinkScript mr_drinkScriptRef = margarita.GetComponent<drinkScript>();
			margarita.rigidbody2D.AddForce(new Vector2(throwForce * force , 0));
			lastForce = throwForce;
			throwForce = 0;
			playerScore -= 4.0f;
			RestoreDrinks();
			break;

		case "bloodyMary":
			bloodyMary = Instantiate(bloodyMary, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
			bloodyMary.AddComponent<SelfDestroy>();
			drinkScript bm_drinkScriptRef = bloodyMary.GetComponent<drinkScript>();
			bloodyMary.rigidbody2D.AddForce(new Vector2(throwForce * force, 0));
			lastForce = throwForce;
			throwForce = 0;
			playerScore -= 5.5f;
			RestoreDrinks();
			break;

		} //cierre de switch
	} //close SpawnDrinks


	void OnGUI()
	{
		GUI.Box(new Rect(10,10,100,50), "Force =" + throwForce);
		//GUI.Box(new Rect(150, 10, 100, 50), "Last Shot = " + lastForce);
		GUI.Box(new Rect(120, 10, 200, 50), "Money =" + playerScore + " $");
	}

	public void ButtonIsPressed(bool value)
	{
		countForce = value;

	}
}

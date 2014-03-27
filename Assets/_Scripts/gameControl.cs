using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

	GameObject beer;
	GameObject margarita;
	GameObject bloodyMary;
	public GameObject drinkSpawner;
	public float force = 10f;
	public int throwForce = 0;
	public bool countForce = false;
	public float playerScore = 1000;
	int lastForce;


	void FindDrinks()
	{
		beer = GameObject.Find("Beer");
		margarita = GameObject.Find("Margarita");
		bloodyMary = GameObject.Find ("BloodyMary");
	}

	// Use this for initialization
	void Start () 
	{
		FindDrinks();
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

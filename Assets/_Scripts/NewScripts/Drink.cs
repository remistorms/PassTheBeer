using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {


	// Public Variables
	public int ID;
	public string name;
	public float price;
	public float weight;
	public bool hasBeenThrown = false;

	// Components needed (WONT BE PUBLIC)
	public SpriteRenderer drink_Renderer;
	public BoxCollider2D drink_Collision;
	public Rigidbody2D drink_RigidBody;
	public Sprite emptySprite;

	//This Game Object Reference
	GameObject thisDrink;

	void Awake()
	{
		// Gets a reference of the components
		thisDrink = this.gameObject;
		drink_Renderer = thisDrink.GetComponent<SpriteRenderer>();
		drink_Collision = thisDrink.GetComponent<BoxCollider2D>();
		drink_RigidBody = thisDrink.GetComponent<Rigidbody2D>();
	}

	void Update()
	{

		if (drink_RigidBody != null) 
		
		{
			if (drink_RigidBody.velocity.x > 0) 
			{
				hasBeenThrown = true;
			}
			if (drink_RigidBody.velocity.x == 0 && hasBeenThrown == true) 
			{
				//Destroys Object after stops
				hasBeenThrown = false;
				StartCoroutine(SelfDestroy());
			}
		}

	}

	void Start()

	{

		thisDrink.name = name;

	}

	public IEnumerator SelfDestroy()
	{
		yield return new WaitForSeconds(3.5f);
		
		if (thisDrink != null) 
		{
			iTween.FadeTo(thisDrink, iTween.Hash("alpha", 0, "time", 0.1f, "looptype", "pingPong"));
		}
		yield return new WaitForSeconds(1.5f);
		Destroy(thisDrink);

	}



}

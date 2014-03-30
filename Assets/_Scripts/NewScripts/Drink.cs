using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {


	// Public Variables
	public int ID;
	public string name;
	public float price;
	public float weight;

	// Components needed (WONT BE PUBLIC)
	public SpriteRenderer drink_Renderer;
	public BoxCollider2D drink_Collision;
	public Rigidbody2D drink_RigidBody;

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

	void Start()

	{
		thisDrink.name = name;
		//StartCoroutine(SelfDestroy());
	}



}

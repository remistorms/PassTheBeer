using UnityEngine;
using System.Collections;

public class DrinkScript : MonoBehaviour {
	
	GameObject thisDrink;
	public float weight = 1.0f;
	Rigidbody2D drinkRigidBody;
	public float drinkPrice = 0.0f;
	public int drinkID;
	public bool hasStopped = false;
	bool onlyOnce = true;
	
	
	// Use this for initialization
	void Awake () 
	{
		thisDrink = this.gameObject;
		if(this.gameObject.GetComponent<Rigidbody2D>() == null)
		{
			this.gameObject.AddComponent<Rigidbody2D>();
		}
	}
	
	void Update()
	{
		//Debug.Log(this.gameObject.name + " velocity is = " + drinkRigidBody.velocity.x );
	}
	
	void Start()
		
	{

			drinkRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
			drinkRigidBody.mass = weight;
			Destroy(this.gameObject, 5);

	}
	
	void OnTriggerStay2D(Collider2D other)
	{
			if (drinkRigidBody.velocity.x == 0) 
			{
				//Debug.Log("I stopped and I'm touching  " + other.name);
				CustomerScript myCustomerScriptRef = other.GetComponent<CustomerScript>();
				myCustomerScriptRef.CheckDrink(thisDrink);
				onlyOnce = false;
			}
	
	}
	
	
	
}

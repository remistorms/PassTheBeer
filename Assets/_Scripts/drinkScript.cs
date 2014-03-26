using UnityEngine;
using System.Collections;

public class drinkScript : MonoBehaviour {

	public string drinkName;
	public float weight = 1.0f;
	Rigidbody2D drinkRigidBody;
	public float drinkPrice = 0.0f;
	public int drinkID;
	public bool hasStopped = false;


	// Use this for initialization
	void Awake () 
	{
		if(this.gameObject.GetComponent<Rigidbody2D>() == null)
		{
			this.gameObject.AddComponent<Rigidbody2D>();
		}

		drinkRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
		drinkRigidBody.mass = weight;
	}
	
	// Update is called once per frame
	void Update () 
	
	{
		//Debug.Log("drink velocity is = " + drinkRigidBody.velocity);
		if(drinkRigidBody.velocity.x == 0)
		{
			hasStopped = true;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("Im touching " + other.name);
	}
	
}

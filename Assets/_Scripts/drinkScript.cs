using UnityEngine;
using System.Collections;

public class drinkScript : MonoBehaviour {

	public string drinkName;
	public float weight = 1.0f;
	Rigidbody2D drinkRigidBody;
	public float drinkPrice = 0.0f;

	// Use this for initialization
	void Start () 
	{
		this.gameObject.AddComponent<Rigidbody2D>();
		drinkRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
		drinkRigidBody.mass = weight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

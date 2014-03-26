using UnityEngine;
using System.Collections;

public class CharacterSpawn : MonoBehaviour {

	public GameObject[] customers;
	GameObject spawnPoint;

	void Awake()
	{
		spawnPoint = this.gameObject;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
			SpawnCustomer();
	}

	void SpawnCustomer()
	{
		int customerNumber = Random.Range(0, customers.Length);
		Instantiate(customers[customerNumber], spawnPoint.transform.position, spawnPoint.transform.rotation);

		//bloodyMary = Instantiate(bloodyMary, drinkSpawner.transform.position, drinkSpawner.transform.rotation) as GameObject;
	}


}

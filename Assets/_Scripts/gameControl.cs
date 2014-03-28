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

}

using UnityEngine;
using System.Collections;

public class LevelStats : MonoBehaviour {

	public Control myControlRef;
	public int customerSeved;
	public int customerSpawned;
	public float moneyEarned;
	public float tips;
	public int drinksServed;

	void Awake()
	{
		myControlRef = this.gameObject.GetComponent<Control>();
	}
}

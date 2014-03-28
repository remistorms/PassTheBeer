using UnityEngine;
using System.Collections;

public class ChargeScript : MonoBehaviour {

	public UISlider mySlider;
	public float power;
	public float powerSpeed = 0.01f;

	void Update()
	{
		mySlider.value = power/100;
	}

	void Start()
	{

		StartCoroutine("ChargeUp");

	}

	public  IEnumerator ChargeUp() 
	{
		for (int i = 0; i <= 100; i += 1) 
			
		{
			power = i;
			yield return new WaitForSeconds(powerSpeed);
		}
		StartCoroutine("ChargeDown");
	}

	IEnumerator ChargeDown () 
	{
		for (int i = 100; i >= 0; i -= 1) 
			
		{
			power = i;
			yield return new WaitForSeconds(powerSpeed);
		}
		StartCoroutine("ChargeUp");
	}

	
}

using UnityEngine;
using System.Collections;

public class CustomerTimer : MonoBehaviour {

	Animator myAnimator;

	void Awake()
	{
		myAnimator = this.gameObject.GetComponent<Animator>();
	}

	void Update()
	{

	}

	public void WaitingTime (float seconds) 
	{
		myAnimator.speed = 1/seconds;
	}

}

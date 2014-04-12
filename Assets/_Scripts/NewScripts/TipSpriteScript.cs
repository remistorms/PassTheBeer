using UnityEngine;
using System.Collections;

public class TipSpriteScript : MonoBehaviour {

	public Sprite[] myPercentageSprite;
	public float timeToAnimate = 1;

	// Use this for initialization
	void Start () 
	{
		//this.gameObject.SetActive(false);
	}
	
	public void SpawnPercentage(int percentage)
	{
		this.gameObject.SetActive(true);
		Destroy(this.gameObject, timeToAnimate);
		switch (percentage) 
		
		{
		case 0:
			this.gameObject.GetComponent<SpriteRenderer>().sprite = myPercentageSprite[0];
			break;

		case 10:
			this.gameObject.GetComponent<SpriteRenderer>().sprite = myPercentageSprite[1];
			break;

		case 25:
			this.gameObject.GetComponent<SpriteRenderer>().sprite = myPercentageSprite[2];
			break;
		}

		iTween.ScaleAdd(this.gameObject, iTween.Hash("x", 0.5f, "y",0.5f,"easetype", "linear","time", timeToAnimate));
		iTween.MoveBy(this.gameObject, iTween.Hash("y", 1.0f, "time", timeToAnimate));
	}
}

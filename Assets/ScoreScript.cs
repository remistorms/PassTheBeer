using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	UILabel myUILabelRef;
	public float myScore = 100;

	void Awake()
	{
		myUILabelRef = this.gameObject.GetComponent<UILabel>();
	}
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	
	{
		myUILabelRef.text = "$ " + myScore.ToString();
	}
}

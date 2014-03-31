using UnityEngine;
using System.Collections;

public class ScoreScriptDisplay : MonoBehaviour {

	// External References
	public Control myControlRef;
	public UILabel myScoreLabel;


	void Awake () 
	{
		myControlRef = GameObject.Find("_Control").GetComponent<Control>();
		myScoreLabel = this.GetComponentInChildren<UILabel>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		myScoreLabel.text = "$ " + myControlRef.playerScore.ToString();
	}
}

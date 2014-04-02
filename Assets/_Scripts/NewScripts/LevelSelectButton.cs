using UnityEngine;
using System.Collections;

public class LevelSelectButton : MonoBehaviour {

	public int level;
	public bool isLocked = true;
	public UIButton myUIButtonRef;
	public UILabel myLabelRef;
	public string levelToLoad;

	// Use this for initialization
	void Awake () 
	{
		myUIButtonRef = this.gameObject.GetComponent<UIButton>();
		myLabelRef = this.gameObject.GetComponentInChildren<UILabel>();
		if (isLocked) 
		
		{
			myUIButtonRef.isEnabled = false;
			myLabelRef.text = "";
		}
	}

	void OnClick()
	{
		Application.LoadLevel(levelToLoad);
	}
}

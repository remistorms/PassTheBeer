using UnityEngine;
using System.Collections;

public class CountDownTimer : MonoBehaviour {

	private float startTime;
	private float restSeconds;
	private int roundedRestSeconds;
	private float displaySeconds;
	private float displayMinutes;
	public int CountDownSeconds=120;
	private float Timeleft;
	string timetext;
	public bool isTimeUp = false;
	public UILabel myTimerLabel;
	
	
	// Use this for initialization
	
	void Start () 
	{
		startTime=Time.deltaTime;
		myTimerLabel = this.gameObject.GetComponent<UILabel>();

		
	}

	void Update()
	{
		myTimerLabel.text =timetext;

		if (timetext != "0:00")
			{
				CalculateTime();
			}

		else 
			{
				myTimerLabel.text = "TIME'S UP";
				isTimeUp = true;
			}
			

	}
	
	void CalculateTime()
	{
		
		Timeleft= Time.time-startTime;
		
		restSeconds = CountDownSeconds-(Timeleft);
		
		roundedRestSeconds=Mathf.CeilToInt(restSeconds);
		displaySeconds = roundedRestSeconds % 60;
		displayMinutes = (roundedRestSeconds / 60)%60;
		
		timetext = (displayMinutes.ToString()+":");
		if (displaySeconds > 9)
		{
			timetext = timetext + displaySeconds.ToString();
		}
		else 
		{
			timetext = timetext + "0" + displaySeconds.ToString();
		}

	}
}
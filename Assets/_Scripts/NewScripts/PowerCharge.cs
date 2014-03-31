using UnityEngine;
using System.Collections;

public class PowerCharge : MonoBehaviour {

	// References
	public UISlider powerSlider;
	public GameObject thisGameObjectRef;
	public UISprite foregroundBar;
	public GameObject fakeSlider;
	// Variables
	public Color minColour;
	public Color maxColour;
	public float barSpeed;
	public float barValue;

	void Update()
	{
		barValue = powerSlider.value;
	}
	void Awake()
	{
		thisGameObjectRef = this.gameObject;
		fakeSlider = GameObject.Find("_FakeSlider");
		powerSlider = thisGameObjectRef.GetComponent<UISlider>();
		foregroundBar = GameObject.Find("PowerChargeForeground").GetComponent<UISprite>();

	}

	void Start()
	{
		foregroundBar.color = minColour;
		powerSlider.value = 0.0f;

	}

	public void ChargeBar() // FIx usign charge up and charge down instead of loopty pingPong
	{
		//Swaps betwen fake and real slider
		thisGameObjectRef.SetActive(true);
		fakeSlider.SetActive(false);

		// Changes the numeric value of the slider
		Hashtable ihv = iTween.Hash("from",0,"to",1,"speed",barSpeed,"name","itweenValue","looptype","pingPong", "onupdate", "UpdateValue");
		iTween.ValueTo(thisGameObjectRef, ihv);

		// Changes the colour value of the slider
		Hashtable ihc = iTween.Hash("from",minColour,"to",maxColour,"speed",barSpeed,"name","itweenColour","looptype","pingPong","onupdate", "UpdateColour");
		iTween.ValueTo(thisGameObjectRef, ihc);
	}



	public void ResetBar()
	{
		thisGameObjectRef.SetActive(false);
		fakeSlider.SetActive(true);
		powerSlider.value = 0;
		foregroundBar.color = minColour;
	}

	void UpdateValue(float myValue)
	{
		powerSlider.value = myValue;
	}

	void UpdateColour(Color myColour)
	{
		foregroundBar.color = myColour;
	}
}

using UnityEngine;

[System.Serializable]
public class SP_Result
{
	[SerializeField]
	private string identifier;
	
	[SerializeField]
	private int index;
	
	public string Identifier
	{
		set
		{
			identifier = value;
		}
		
		get
		{
			return identifier;
		}
	}
	
	public int Index
	{
		set
		{
			index = value;
		}
		
		get
		{
			return index;
		}
	}
}
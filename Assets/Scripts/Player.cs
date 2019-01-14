using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public  int Id;
	public Color color;


	public float expansionPoint =0;

	public List<HexController> HexList;
	void Awake () 
	{
		HexList = new List<HexController>();
		color = Random.ColorHSV(0f,1f,1f,1f,0f,1f);
		this.gameObject.GetComponent<MeshRenderer> ().material.color = color;

	}

	void Update ()
	{
		IncExpansionPoint ();
	}

	void IncExpansionPoint()
	{
		float IncRate = 1f;    //TODO:Update IncRate Calculation with fieldCount etc...
		expansionPoint += IncRate * Time.deltaTime;
		//expansionPointText.text = "Expansion Point: " + expansionPoint;
	}
	void DecExpansionPoint(float amount)
	{
		expansionPoint -= amount;
	}

	bool IsOurNeighbour(HexController hex)
	{
		foreach (HexController Hex in HexList)
		{
			HexController[] adjecents = Hex.GetAdjecent();
			foreach (HexController a in adjecents)
			{
				if(a == hex)
				{
					return true;
				}
			}
		}
		return false;
	}
	
	public void Claim(HexController hex)
	{
		if (expansionPoint > 10 && IsOurNeighbour(hex) == true) //And adjacent And in limit
		{
			hex.GetComponent<HexController>().SetOwner(Id);
			HexList.Add(hex);
			DecExpansionPoint(10);
		}

	}
	

}

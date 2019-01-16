using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour 
{
	public  int Id;
	public Color color;
	public GameObject cubePrefab;
	public float expansionPoint =0;
	public List<HexController> HexList;

	public int hexCost = 10, cubeCost=40; 

	void Awake () 
	{
		HexList = new List<HexController>();
		color = Random.ColorHSV(0f,1f,1f,1f,0f,1f);		
	}

	void Update ()
	{
		IncExpansionPoint ();
	}

	void IncExpansionPoint()
	{
		float IncRate = 1f;  
		expansionPoint += IncRate * Time.deltaTime;
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
		if(hex.GetOwner() ==Id)
		{
			Debug.Log("You already own this hex");
			return;
		}
		if (expansionPoint > hexCost && IsOurNeighbour(hex) == true) //And adjacent And in limit
		{
			DecExpansionPoint(hex.GetCost());
			hex.SetOwner(Id);
			HexList.Add(hex);
		}
		else
		{
			Debug.Log("Please select an adjacent hex");
		}

	}
	public void AddCube(HexController hex)
	{
		if(expansionPoint >= cubeCost)
		{
			hex.AddCube();
			hex.UpdateCost();
			DecExpansionPoint(cubeCost);
		}
		
	}

	public bool isMyHex(HexController hex)
	{
		if(hex.GetOwner() == Id)
		{
			return true;
		}
		return false;
	}
}

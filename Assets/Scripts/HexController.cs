using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HexController : MonoBehaviour 
{
	private int owner = -1;
	private bool isRised = false;
	private int cost =10;
	private int allyHexCount =0;
	public bool isCubePresent = false;
	private int extraCubeCost = 30;
	public GameObject cubePrefab;

	public int x,z;
	public int mapXLimit,mapZLimit;
	
	
	public void SetOwner(int o)
	{
		Rise();
		owner = o;
		UpdateAllyHexCount();
		SetHexColor ();
	}
	void SetHexColor()
	{
		GetComponentInChildren<MeshRenderer> ().material.color = GetPlayerById().color;
	}
	public void Rise()
	{
		if(owner < 0 && isRised == false)
		{
			Vector3 target = new Vector3(transform.position.x,transform.position.y+0.3f,transform.position.z);
			transform.position = Vector3.Lerp(transform.position,target,1);
			isRised = true;
		}
		
	}
	public void Fall()
	{
		if(owner <0 && isRised == true)
		{
			Vector3 target = new Vector3(transform.position.x,transform.position.y-0.3f,transform.position.z);
			transform.position = Vector3.Lerp(transform.position,target,1);
			isRised = false;
		}
	}
	public int GetOwner()
	{
		return owner;
	}
	public HexController[] GetAdjecent()
	{
		#region xatLimit 
		if(x == 0 && z % 2 ==0)
		{
			HexController h1 = GameObject.Find("Hex_"+(x)+"_"+(z+1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x+1)+"_"+(z-1)).GetComponent<HexController>();
			
			HexController[] a = new HexController[3] {h1,h2,h3};
			return  a;
		}
		else if(x == 0 && z % 2 ==1)
		{
			HexController h1 = GameObject.Find("Hex_"+(x+1)+"_"+(z+1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x+1)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x+1)+"_"+(z-1)).GetComponent<HexController>();
			HexController h4 = GameObject.Find("Hex_"+x+"_"+(z+1)).GetComponent<HexController>();
			HexController h5 = GameObject.Find("Hex_"+x+"_"+(z-1)).GetComponent<HexController>();
			HexController[] a = new HexController[5] {h1,h2,h3,h4,h5};
			return  a;
		}
		else if(x == mapXLimit && z % 2 == 1)
		{
			HexController h1 = GameObject.Find("Hex_"+(x)+"_"+(z-1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x-1)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x)+"_"+(z+1)).GetComponent<HexController>();
			
			HexController[] a = new HexController[3] {h1,h2,h3};
			return  a;
		}
		else if(x == mapXLimit && z % 2 == 0)
		{
			HexController h1 = GameObject.Find("Hex_"+(x-1)+"_"+(z+1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x-1)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x-1)+"_"+(z-1)).GetComponent<HexController>();
			HexController h4 = GameObject.Find("Hex_"+x+"_"+(z+1)).GetComponent<HexController>();
			HexController h5 = GameObject.Find("Hex_"+x+"_"+(z-1)).GetComponent<HexController>();
			HexController[] a = new HexController[5] {h1,h2,h3,h4,h5};
			return  a;
		}
		#endregion
		#region zatLimit
		if(z == 0)
		{
			HexController h1 = GameObject.Find("Hex_"+(x-1)+"_"+(z+1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x+1)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x-1)+"_"+(z)).GetComponent<HexController>();
			HexController h4 = GameObject.Find("Hex_"+x+"_"+(z+1)).GetComponent<HexController>();
			HexController[] a = new HexController[4] {h1,h2,h3,h4};
			return  a;
			
		}
		if(z == mapZLimit)
		{
			HexController h1 = GameObject.Find("Hex_"+(x-1)+"_"+(z)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x+1)+"_"+(z-1)).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x+1)+"_"+(z)).GetComponent<HexController>();
			HexController h4 = GameObject.Find("Hex_"+x+"_"+(z-1)).GetComponent<HexController>();
			HexController[] a = new HexController[4] {h1,h2,h3,h4};
			return  a;
		}
		#endregion
		#region atMiddle
		if(z % 2 == 0)
		{
			HexController h1 = GameObject.Find("Hex_"+(x-1)+"_"+(z+1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x-1)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x-1)+"_"+(z-1)).GetComponent<HexController>();
			HexController h4 = GameObject.Find("Hex_"+x+"_"+(z-1)).GetComponent<HexController>();
			HexController h5 = GameObject.Find("Hex_"+(x+1)+"_"+z).GetComponent<HexController>();
			HexController h6 = GameObject.Find("Hex_"+x+"_"+(z+1)).GetComponent<HexController>();
			HexController[] a = new HexController[6] {h1,h2,h3,h4,h5,h6};
			return  a;
		}
		else
		{
		
			HexController h1 = GameObject.Find("Hex_"+(x+1)+"_"+(z+1)).GetComponent<HexController>();
			HexController h2 = GameObject.Find("Hex_"+(x+1)+"_"+z).GetComponent<HexController>();
			HexController h3 = GameObject.Find("Hex_"+(x+1)+"_"+(z-1)).GetComponent<HexController>();
			HexController h4 = GameObject.Find("Hex_"+x+"_"+(z-1)).GetComponent<HexController>();
			HexController h5 = GameObject.Find("Hex_"+(x-1)+"_"+z).GetComponent<HexController>();
			HexController h6 = GameObject.Find("Hex_"+x+"_"+(z+1)).GetComponent<HexController>();
			HexController[] a = new HexController[6] {h1,h2,h3,h4,h5,h6};
			return  a;
		}
		#endregion
	}
	
	void UpdateAllyHexCount()
	{
		HexController[] hexs = this.GetAdjecent();
		foreach (HexController hex in hexs)
		{
			if(hex.GetOwner() == owner)
			{
				hex.IncAllyHexCount();
				hex.UpdateCost();
				allyHexCount++;
			}
		}
		UpdateCost();
	}
	void IncAllyHexCount()
	{
		allyHexCount++;
	}
	public int GetAllyHexCount()
	{
		return allyHexCount;
	}
	
	public void UpdateCost()
	{
		if(isCubePresent)
		{
			cost = 10 + (10 * allyHexCount) + extraCubeCost;
		}
		else
		{
			cost = 10 + (10 * allyHexCount);
		}
	}
	public int GetCost()
	{
		return cost;
	}

	public GameObject AddCube()
	{
		if(isCubePresent == false)
		{
			Vector3 ExtraY = new Vector3 (transform.position.x, 1.639f,transform.position.z);// position of Cube
			isCubePresent = true;
			GameObject cube =(GameObject)Instantiate(cubePrefab,ExtraY,Quaternion.identity);
			cube.GetComponent<MeshRenderer> ().material.color = GetComponentInChildren<MeshRenderer> ().material.color;
			return cube;
		}
		else {
			return null;
		}
	}
	Player GetPlayerById()
	{
		Player[] p = FindObjectsOfType<Player>();
		foreach (Player player in p)
		{
			if(player.Id == owner)
			{
				return player;
			}
		}
		return null;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexController : MonoBehaviour 
{
	private int owner = -1;
	private bool isRised = false;

	public int x,z;

	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetOwner(int o)
	{
		Rise();
		owner = o;
		SetHexColor ();
	}
	void SetHexColor()
	{
		GetComponentInChildren<MeshRenderer> ().material.color = MainController.Players[owner].color;
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
	
	public HexController[] GetAdjecent()
	{
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
		
	}
}

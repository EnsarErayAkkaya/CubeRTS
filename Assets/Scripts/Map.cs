using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour 
{
	public GameObject hexPrefab;
	//Those is the number of hexagons wil spawn
	public int width = 5;
	public int height = 5;

	float hexX = 1.73205f;
	float hexZ = 2f;

	float xOffset = 1.1f;
	float zOffset = 0.81f;
	void Awake ()
	{
		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < height; z++)
			{
				float xPos = x * xOffset;

				//if z is odd then line hexs little further
				if(z % 2 == 1) 
				{
					xPos += xOffset/2;
				}

				GameObject hex_go = (GameObject)Instantiate(hexPrefab,new Vector3((xPos * hexX),0,(z * hexZ)* zOffset),Quaternion.identity);

				hex_go.name = "Hex_"+x+"_"+z; // setting name

				hex_go.transform.SetParent(this.transform); // seting parent

				hex_go.GetComponent<HexController>().x = x;// for Adjacent info ...
				hex_go.GetComponent<HexController>().z = z;//
			}
		}
	}
}

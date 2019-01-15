using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	public GameObject playerGO;
	public  static HexController[] HexFields;
	public static Player[] Players; 
	public int playerCount =1;

	// Use this for initializatio
	void Start () 
	{
		Players = new Player[playerCount];

		HexFields = GameObject.FindObjectsOfType<HexController>();
		for (int i = 0; i < Players.Length; i++) {
			SetUpPlayers (i);
		}
	}
	void Update()
	{
		
	}

	void SetUpPlayers(int i)
	{
		int SpawnHex =Random.Range(0,HexFields.Length); // index of Spawn Hex

		Players [i] = playerGO.GetComponent<Player> ();

		Players [i].Id = i;
		Players[i].HexList.Add(HexFields [SpawnHex]);

		HexFields [SpawnHex].SetOwner (i);//Hex Color 
		
		GameObject cube = HexFields [SpawnHex].AddCube();//instantiating cube
	}


}

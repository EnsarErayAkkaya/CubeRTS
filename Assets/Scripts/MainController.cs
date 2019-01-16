using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	private int playerId = 0;
	public GameObject playerGO;
	public  static HexController[] HexFields;
	
	public int playerCount =1;

	// Use this for initializatio
	void Start () 
	{
		
		
		HexFields = GameObject.FindObjectsOfType<HexController>();
		
			SetUpPlayers ();
		
	}
	void Update()
	{
		
	}

	void SetUpPlayers()
	{
		int SpawnHex =Random.Range(0,HexFields.Length); // index of Spawn Hex

		GameObject player = Instantiate(playerGO);
		
		player.GetComponent<Player>().Id = CreatePlayerId();

		player.GetComponent<Player>().HexList.Add(HexFields [SpawnHex]);

		HexFields [SpawnHex].SetOwner (player.GetComponent<Player>().Id);//Hex Color 
		
		GameObject cube = HexFields [SpawnHex].AddCube();//instantiating cube
	}

	int CreatePlayerId()
	{
		return ++playerId;
	}
}

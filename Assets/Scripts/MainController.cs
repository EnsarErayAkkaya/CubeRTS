using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	public GameObject Cube;
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
		Vector3 ExtraY = new Vector3 (HexFields [SpawnHex].transform.position.x, 1.639f,
			HexFields [SpawnHex].transform.position.z);// position of Cube
		GameObject cube = Instantiate (Cube, ExtraY, Quaternion.identity);// instantiating cube

		cube.AddComponent<Player> ();
		Players [i] = cube.GetComponent<Player> ();

		Players [i].Id = i;
		Players[i].HexList.Add(HexFields [SpawnHex]);

		HexFields [SpawnHex].SetOwner (i);//Hex Color 
	}


}

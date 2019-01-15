using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour {

	private LayerMask layer ;
	private HexController selectedHex; 
	public Button claimButton;
	public Text allyHexText,costText,expansionPointText;
	public float cameraSpeed=0.1f;

	// Use this for initialization
	void Start () {
		layer = LayerMask.GetMask ("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
		CameraControl();
		SelectHex();
		UpdateUI();
	}
	void SelectHex()
	{
		if(EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,layer)) {
				Debug.Log ("name " + hit.transform.name);
				if(hit.transform.GetComponent<HexController>() != null)
				{
					if(hit.transform.gameObject != selectedHex && selectedHex != null)
					{
						selectedHex.Fall();
						hit.transform.GetComponent<HexController>().Rise();		
					}
					else if(selectedHex == null && hit.transform.gameObject != selectedHex)
					{	
						hit.transform.GetComponent<HexController>().Rise();	
					}
					selectedHex = hit.transform.gameObject.GetComponent<HexController>();
					if(MainController.Players[0].isMyHex(selectedHex))
					{
						claimButton.GetComponentInChildren<Text>().text = "Add Cube";
						if(selectedHex.isCubePresent)
						{
							claimButton.interactable = false;
						}
						else
						{
							claimButton.interactable = true;
						}
					}
					else
					{
						claimButton.GetComponentInChildren<Text>().text = "Claim";
						claimButton.interactable = true;
					}
					claimButton.gameObject.SetActive(true);//Button pop up					
				}	    
			}
			else
			{	
				if(selectedHex != null)
				{
					selectedHex.Fall();
				}			
				selectedHex = null; 
				claimButton.gameObject.SetActive(false);
			}
		}
	}

	void CameraControl()
	{
		if(Input.GetKey(KeyCode.W))
		{
			Camera.main.transform.position += Vector3.forward *cameraSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S))
		{
			Camera.main.transform.position += Vector3.forward *-cameraSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D))
		{
			Camera.main.transform.position += Camera.main.transform.right *cameraSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A))
		{
			Camera.main.transform.position += Camera.main.transform.right *-cameraSpeed * Time.deltaTime;
		}
	}
	void UpdateUI()
	{
		expansionPointText.text = "Expansion Point: " + (int)(MainController.Players[0].expansionPoint);//Temp: expansion point updating
		if(selectedHex != null)
		{
			costText.text = "Cost: " + selectedHex.GetCost();//Cost TExt Updadting
			allyHexText.text = "Allies: "+selectedHex.GetAllyHexCount();//Ally Hex Count of selected hex
		}	
	}
	public void ClaimButton()
	{
		if(selectedHex.GetOwner() < 0)
		{
			MainController.Players[0].Claim(selectedHex);
		}
		else if(selectedHex.GetOwner() == MainController.Players[0].Id)
		{
			MainController.Players[0].AddCube(selectedHex);
		}

	}

}

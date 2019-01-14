using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	private LayerMask layer ;
	private HexController selectedHex; 

	public float cameraSpeed=0.1f;

	// Use this for initialization
	void Start () {
		layer = LayerMask.GetMask ("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
		CameraControl();
		SelectHex();
	}
	void SelectHex()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,layer)) {
				Debug.Log ("name " + hit.transform.name);
				if(hit.transform.GetComponent<HexController>() != null)
				{
					if(hit.transform.gameObject != selectedHex && selectedHex != null)
					{
						selectedHex.GetComponent<HexController>().Fall();
						hit.transform.GetComponent<HexController>().Rise();	
						selectedHex = hit.transform.gameObject.GetComponent<HexController>();
						MainController.Players[0].Claim(selectedHex);
					}
					else if(selectedHex == null && hit.transform.gameObject != selectedHex)
					{	
						hit.transform.GetComponent<HexController>().Rise();	
						selectedHex = hit.transform.gameObject.GetComponent<HexController>();
					}
				}	    
			}
			else
				{				
					selectedHex.GetComponent<HexController>().Fall();
					selectedHex = null; 
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
}

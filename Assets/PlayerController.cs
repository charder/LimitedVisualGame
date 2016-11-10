using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float xPos; //movement factor on the x-axis
	float yPos; //movement factor on the y-axis
	public GameObject indicator;
	public GameObject playerObj; //object that this controller moves
	// Use this for initialization
	void Start () {
		xPos = 0;
		yPos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (mousePos.x < 2.0f && mousePos.x > -2.0f && mousePos.y < 2.0f && mousePos.y > -2.0f) {
			if (Input.GetMouseButton(0)) {
				indicator.transform.position = new Vector3(mousePos.x,mousePos.y,-1); //move indicator to mouse location
				// A portion of the controller's input translated to movement
				xPos = indicator.transform.position.x / 100; 
				yPos = indicator.transform.position.y / 100;
			} else if (Input.GetMouseButtonUp(0)) {
				if (Mathf.Abs (indicator.transform.position.x) < 0.1) {
					indicator.transform.position = new Vector3 (0, indicator.transform.position.y, -1);
					xPos = 0;
				}
				if (Mathf.Abs (indicator.transform.position.y) < 0.1) {
					indicator.transform.position = new Vector3 (indicator.transform.position.x, 0, -1);
					yPos = 0;
				}
			}
		} 
		//move player object based on controller input
		playerObj.transform.position = new Vector3 (playerObj.transform.position.x + xPos, playerObj.transform.position.y + yPos, -1);
	}
}

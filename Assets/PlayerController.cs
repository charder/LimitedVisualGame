using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	int xPos; //movement factor on the x-axis
	int yPos; //movement factor on the y-axis
	public GameObject indicator;
	// Use this for initialization
	void Start () {
		xPos = 0;
		yPos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//print (mousePos.x + ", " + mousePos.y);
		if (mousePos.x < 2.0f && mousePos.x > -2.0f && mousePos.y < 2.0f && mousePos.y > -2.0f) {
			if (Input.GetMouseButton(0)) {
				indicator.transform.position = new Vector3(mousePos.x,mousePos.y,-1); //move indicator to mouse location
			} else if (Input.GetMouseButtonUp(0)) {
				if (Mathf.Abs (indicator.transform.position.x) < 0.1) {
					indicator.transform.position = new Vector3 (0, indicator.transform.position.y, -1);
				}
				if (Mathf.Abs (indicator.transform.position.y) < 0.1) {
					indicator.transform.position = new Vector3 (indicator.transform.position.x, 0, -1);
				}
			}
		} 
	}
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Vector3[] levelStarts;
	public int level;
	public int currentPitch; //pitch of sound currently playing
	public int newPitch; //pitch of sounds sent to object
	// Use this for initialization
	void Start () {
		this.transform.position = levelStarts [level];
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPitch < newPitch) {
			currentPitch++;
		} else if (currentPitch > newPitch) {
			currentPitch--;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		print(col.gameObject.tag);
		if (col.gameObject.tag == "Exit") {
			print ("LEAVE THIS PLACE");
			progressLevel ();
		}
	}

	void OnTriggerStay(Collider col) {
		print (col.gameObject.name);
	}

	void progressLevel() {
		if (level != levelStarts.Length - 1) { //if there is a next level
			level++;
			transform.position = levelStarts [level];
		}
	}
}

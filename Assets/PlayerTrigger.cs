using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {
	public int pitch; //The pitch of sound that will play (or be increased/decreased to) when the player is within this zone
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "Player") { //send player this trigger's pitch
			col.gameObject.GetComponent<GameManager> ().newPitch = pitch;
		}
		print (col.gameObject.name);
	}
}

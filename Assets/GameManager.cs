using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	bool gameOver;
	public Vector3[] levelStarts;
	public string[] levelText;
	public int level;
	public int currentPitch; //pitch of sound currently playing
	public int newPitch; //pitch of sounds sent to object
	public Hv_LimitedVisualPatch_LibWrapper wrapper;
	public Text levelDetails;
	// Use this for initialization
	void Start () {
		gameOver = false;
		this.transform.position = levelStarts [level];
		levelDetails.text = levelText [level];
		wrapper.freq = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPitch < newPitch) {
			currentPitch++;
		} else if (currentPitch > newPitch) {
			currentPitch--;
		}
		wrapper.pitch = currentPitch;
		if (wrapper.freq > 0) {
			wrapper.freq -= .02f;
		}
		if (Input.GetKeyDown (KeyCode.R) && gameOver) { //restart game
			gameOver = false;
			transform.position = levelStarts [level];
			levelDetails.text = levelText [level];
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		print(col.gameObject.tag);
		if (col.gameObject.tag == "Exit") {
			progressLevel ();
			currentPitch = 0;
			wrapper.freq = 0.5f;
		}
	}

	void progressLevel() {
		if (level != levelStarts.Length - 1) { //if there is a next level
			level++;
			transform.position = levelStarts [level];
			levelDetails.text = levelText [level];
		} else {
			gameOver = true;
			level = 0;
			transform.position = new Vector3 (5, 15, -1);
			levelDetails.text = "You Win! Press R to Restart.";
		}
	}
}

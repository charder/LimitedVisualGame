using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	bool gameOver;
	public Vector3[] levelStarts;
	public string[] levelText;
	public int level;
	float floatPitch;
	public int currentPitch; //pitch of sound currently playing
	public int newPitch; //pitch of sounds sent to object
	public Hv_LimitedVisualPatch_LibWrapper wrapper;
	public Text levelDetails;
	// Use this for initialization

	void Awake () {
		Application.targetFrameRate = 60;
	}
	void Start () {
		gameOver = false;
		this.transform.position = levelStarts [level];
		levelDetails.text = levelText [level];
	}
	
	// Update is called once per frame
	void Update () {
		//Allign pitch to new pitch
		if (currentPitch < newPitch) {
			floatPitch += Time.fixedDeltaTime * 60;
		} else if (currentPitch > newPitch) {
			floatPitch -= Time.fixedDeltaTime * 60;
		}
		currentPitch = Mathf.RoundToInt (floatPitch);
		wrapper.pitch = currentPitch;
		if (wrapper.freq > 0) {
			wrapper.freq -= Time.fixedDeltaTime;
		} else if (wrapper.freq < 0) { //don't want a negative frequency here
			wrapper.freq = 0;
		}
		if (Input.GetKeyDown (KeyCode.R) && gameOver) { //restart game
			gameOver = false;
			transform.position = levelStarts [level];
			levelDetails.text = levelText [level];
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Exit") {
			progressLevel ();
			floatPitch = 0;
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

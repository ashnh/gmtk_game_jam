using UnityEngine;
using System.Collections;

public class CloudBall : MonoBehaviour {

	public GameObject player;
	public GameObject cloudMeter;

	public float increaseAmount;
	public float decreaseAmount;

	public string color;

	float multiplyer;

	bool activated;

	public void setActivated (bool state) {
		activated = state;
	}

	// Use this for initialization
	void Start () {
		multiplyer = 1F;
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0F) {
			if (Input.GetKey (KeyCode.R)) {
				multiplyer = 2F;
			} else {
				multiplyer = 1F;
			}
			if (player.GetComponent <Player> ().getColorDown ().Equals (Player.states.PURPLE) && color.Equals ("purple") && activated) {
				cloudMeter.transform.localScale = cloudMeter.transform.localScale + new Vector3 (-decreaseAmount * multiplyer, 0);
			} else if (player.GetComponent <Player> ().getColorDown ().Equals (Player.states.RED) && color.Equals ("red") && activated) {
				cloudMeter.transform.localScale = cloudMeter.transform.localScale + new Vector3 (-decreaseAmount * multiplyer, 0);
			} else if (player.GetComponent <Player> ().getColorDown ().Equals (Player.states.TEAL) && color.Equals ("teal") && activated) {
				cloudMeter.transform.localScale = cloudMeter.transform.localScale + new Vector3 (-decreaseAmount * multiplyer, 0);
			} else {
				cloudMeter.transform.localScale = cloudMeter.transform.localScale + new Vector3 (increaseAmount * multiplyer, 0);
			}

			//Debug.Log (player.GetComponent <Player> ().getColorDown ());

			if (cloudMeter.transform.localScale.x > 1) {
				player.GetComponent <Player> ().changeHealth (-1);
				Destroy (gameObject);
			} else if (cloudMeter.transform.localScale.x < 0) {
				Destroy (gameObject);
			}
		}

	}
}

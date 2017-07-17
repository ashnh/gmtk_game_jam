using UnityEngine;
using System.Collections;

public class MagicMeters : MonoBehaviour {

	public GameObject redMeter;
	public GameObject tealMeter;
	public GameObject purpleMeter;

	float redMeterNumber;
	float tealMeterNumber;
	float purpleMeterNumber;

	public float increaseAmount;
	public float decreaseAmount;

	public bool isRedHighEnough () {
		return redMeterNumber > 0;
	}

	public bool isTealHighEnough () {
		return tealMeterNumber > 0;
	}

	public bool isPurpleHighEnough () {
		return purpleMeterNumber > 0;
	}

	// Use this for initialization
	void Start () {
		redMeterNumber = 1F;
		tealMeterNumber = 1F;
		purpleMeterNumber = 1F;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale != 0F) {
			if (Input.GetKey (KeyCode.Q)) {
				redMeterNumber -= decreaseAmount;
				tealMeterNumber += increaseAmount;
				purpleMeterNumber += increaseAmount;
				//red
			} else if (Input.GetKey (KeyCode.W)) {
				redMeterNumber += increaseAmount;
				tealMeterNumber -= decreaseAmount;
				purpleMeterNumber += increaseAmount;
				//teal
			} else if (Input.GetKey (KeyCode.E)) {
				redMeterNumber += increaseAmount;
				tealMeterNumber += increaseAmount;
				purpleMeterNumber -= decreaseAmount;
				//purple
			} else if (Input.GetKey (KeyCode.R)) {
				redMeterNumber += increaseAmount;
				tealMeterNumber += increaseAmount;
				purpleMeterNumber += increaseAmount;
				//purple
			}

			if (redMeterNumber > 1) {
				redMeterNumber = 1;
			} else if (redMeterNumber < 0) {
				redMeterNumber = 0;
			}

			if (tealMeterNumber > 1) {
				tealMeterNumber = 1;
			} else if (tealMeterNumber < 0) {
				tealMeterNumber = 0;
			}

			if (purpleMeterNumber > 1) {
				purpleMeterNumber = 1;
			} else if (purpleMeterNumber < 0) {
				purpleMeterNumber = 0;
			}

			redMeter.transform.localScale = new Vector3 (redMeterNumber, 1, 1);
			tealMeter.transform.localScale = new Vector3 (tealMeterNumber, 1, 1);
			purpleMeter.transform.localScale = new Vector3 (purpleMeterNumber, 1, 1);
		}

	}
}

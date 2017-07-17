using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spectacle : MonoBehaviour {

	public GameObject spawner;

	public GameObject hundreds;
	public GameObject tens;
	public GameObject ones;

	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	public Sprite zero;

	Dictionary <string, Sprite> numbers;

	public int crowdWinAmount;

	public float timeTick;
	public float deadband;
	public float multiplierAmount;
	public float evenSpectacleAmount;

	public int winToLevel;

	int crowdAmount;

	bool ticked;


	// Use this for initialization
	void Start () {

		ticked = false;

		crowdAmount = 0;

		numbers = new Dictionary <string, Sprite> ();

		numbers.Add ("0", zero);
		numbers.Add ("1", one);
		numbers.Add ("2", two);
		numbers.Add ("3", three);
		numbers.Add ("4", four);
		numbers.Add ("5", five);
		numbers.Add ("6", six);
		numbers.Add ("7", seven);
		numbers.Add ("8", eight);
		numbers.Add ("9", nine);

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0F) {
			//Debug.Log (crowdAmount.ToString ());
			try {
				if (crowdAmount < 10) {
					ones.GetComponent <SpriteRenderer> ().sprite = numbers [crowdAmount.ToString ()];
					tens.GetComponent <SpriteRenderer> ().sprite = zero;
					hundreds.GetComponent <SpriteRenderer> ().sprite = zero;
				} else if (crowdAmount < 100) {
					ones.GetComponent <SpriteRenderer> ().sprite = numbers [crowdAmount.ToString ().Substring (1)];
					tens.GetComponent <SpriteRenderer> ().sprite = numbers [crowdAmount.ToString ().Substring (0, 1)];
					hundreds.GetComponent <SpriteRenderer> ().sprite = zero;
				} else {
					ones.GetComponent <SpriteRenderer> ().sprite = numbers [crowdAmount.ToString ().Substring (2)];
					tens.GetComponent <SpriteRenderer> ().sprite = numbers [crowdAmount.ToString ().Substring (1, 1)];
					hundreds.GetComponent <SpriteRenderer> ().sprite = numbers [crowdAmount.ToString ().Substring (0, 1)];
				}
			} catch (System.Exception e) {

			}

			if ((Time.timeSinceLevelLoad % timeTick < deadband || Time.timeSinceLevelLoad % timeTick > timeTick - deadband)) {
				if (!ticked) {
					crowdAmount = (int)((multiplierAmount * (spawner.GetComponent <Spawner> ().getCloudNumber (evenSpectacleAmount) - evenSpectacleAmount)) + crowdAmount);
					if (crowdAmount < 0) {
						crowdAmount = 0;
					}
					ticked = true;
				}
			} else {
				ticked = false;
			}
			if (crowdAmount >= crowdWinAmount) {
				PlayerPrefs.SetInt ("Level " + UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex + " done", 1);
				UnityEngine.SceneManagement.SceneManager.LoadScene (winToLevel);
			}
		}

	}
}

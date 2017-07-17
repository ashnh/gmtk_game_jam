using UnityEngine;
using System.Collections;

public class UICode : MonoBehaviour {

	public GameObject ExitButton;

	public bool isTitle;

	public GameObject levelOne;
	public GameObject levelTwo;
	public GameObject levelThree;

	public int levelOneNumber;
	public int levelTwoNumber;
	public int levelThreeNumber;

	public void loadLevel (int index) {
		UnityEngine.SceneManagement.SceneManager.LoadScene (index);
	}

	bool buttonOpen;

	// Use this for initialization
	void Start () {
		buttonOpen = false;
		Time.timeScale = 1F;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isTitle) {
			Debug.Log (buttonOpen);
			if (Input.GetKeyDown (KeyCode.Escape)) {
				buttonOpen = !buttonOpen;
			}

			if (buttonOpen) {
				Debug.Log (buttonOpen);
				Time.timeScale = 0F;
				ExitButton.transform.localScale = new Vector3 (1, 1, 1);
			} else {
				Time.timeScale = 1F;
				ExitButton.transform.localScale = new Vector3 (0, 0, 0);
			}
		} else {
			levelOne.SetActive (true);

			if (PlayerPrefs.GetInt ("Level " + levelOneNumber + " done") == 1) {
				levelTwo.SetActive (true);
			} else {
				levelTwo.SetActive (false);
			}

			if (PlayerPrefs.GetInt ("Level " + levelTwoNumber + " done") == 1) {
				levelThree.SetActive (true);
			} else {
				levelThree.SetActive (false);
			}

			//if (Input.GetKey (KeyCode.R)) {
			//	PlayerPrefs.SetInt ("Level " + levelOneNumber + " done", 0);
			//	PlayerPrefs.SetInt ("Level " + levelTwoNumber + " done", 0);
			//	PlayerPrefs.SetInt ("Level " + levelThreeNumber + " done", 0);
			//}

		}

	}
}

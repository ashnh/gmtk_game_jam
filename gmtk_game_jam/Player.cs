using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject healthNodeOne;
	public GameObject healthNodeTwo;
	public GameObject healthNodeThree;
	public GameObject healthNodeFour;
	public GameObject healthNodeFive;

	public Animator anim;

	public bool turnOffTeal;

	public int healthNodeAmount;

	public GameObject magicMeters;

	public enum states {NONE, RED, TEAL, PURPLE};

	public states getColorDown () {
		return colorDown;
	}

	public void changeHealth (int x) {
		health += x;
		updateHealthBar ();
	}
		
	int health;

	states colorDown;

	void changeBar (bool one, bool two, bool three, bool four, bool five) {
		healthNodeOne.SetActive (one);
		healthNodeTwo.SetActive (two);
		healthNodeThree.SetActive (three);
		healthNodeFour.SetActive (four);
		healthNodeFive.SetActive (five);
	}

	void updateHealthBar () {
		switch (health) {
		case 1:
			changeBar (true, false, false, false, false);
			break;
		case 2:
			changeBar (true, true, false, false, false);
			break;
		case 3:
			changeBar (true, true, true, false, false);
			break;
		case 4:
			changeBar (true, true, true, true, false);
			break;
		case 5:
			changeBar (true, true, true, true, true);
			break;
		case 0:
		default:
			changeBar (false, false, false, false, false);
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
			break;
		}
	}

	// Use this for initialization
	void Start () {
		colorDown = states.NONE;
		health = healthNodeAmount;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeSinceLevelLoad != 0F) {
			
			if (Input.GetKey (KeyCode.Q) && magicMeters.GetComponent <MagicMeters> ().isRedHighEnough ()) {
				colorDown = states.RED;
			} else if (Input.GetKey (KeyCode.W) && magicMeters.GetComponent <MagicMeters> ().isTealHighEnough () && !turnOffTeal) {
				colorDown = states.TEAL;
			} else if (Input.GetKey (KeyCode.E) && magicMeters.GetComponent <MagicMeters> ().isPurpleHighEnough ()) {
				colorDown = states.PURPLE;
			} else {
				colorDown = states.NONE;
			}



		}
	}
}

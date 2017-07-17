using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject player;

	public GameObject redCloud;
	public GameObject tealCloud;
	public GameObject purpleCloud;

	public bool turnOffRed;
	public bool turnOffTeal;
	public bool turnOffPurple;

	public int redSpawnNumber;
	public int tealSpawnNumber;
	public int purpleSpawnNumber;

	public float redSpawnTimer;
	public float tealSpawnTimer;
	public float purpleSpawnTimer;
	public float deadband;

	public float height;
	public float verticalSpacing;
	public float horizontalSpacing;

	int redAmountSpawned;
	int tealAmountSpawned;
	int purpleAmountSpawned;

	bool redSpawned;
	bool tealSpawned;
	bool purpleSpawned;

	ArrayList redClouds;
	ArrayList tealClouds;
	ArrayList purpleClouds;

	public float getCloudNumber (float defaultAmount) {
		try {
			float n = 0;
			foreach (GameObject cloud in redClouds) {
				n++;
			}
			foreach (GameObject cloud in tealClouds) {
				n++;
			}
			foreach (GameObject cloud in purpleClouds) {
				n++;
			}
			return n;
		} catch (System.Exception e) {
			return defaultAmount;
		}
	}

	void reorganizeArray (ArrayList list, float typeNumber) {
		int i = 0;
		foreach (GameObject cloud in list) {
			cloud.GetComponent <CloudBall> ().setActivated (false);
			cloud.transform.position = new Vector3 (typeNumber * horizontalSpacing, height + (verticalSpacing * i), 0);
			i++;
		}
	
	}

	void checkForNullEntries (ArrayList list, float typeNumber) {
		foreach (GameObject cloud in list) {
			if (cloud.Equals (null)) {
				list.Remove (cloud);
				reorganizeArray (list, typeNumber);
			}
		}
	}

	void spawnCloud (GameObject cloud, ArrayList list, float typeNumber) {
		GameObject x = (GameObject) Instantiate (cloud, new Vector3 (1000, 1000, 0), transform.rotation);
		x.GetComponent <CloudBall> ().player = player;
		list.Add (x);
		reorganizeArray (list, typeNumber);
	}

	void cloudSpawnTimer (GameObject cloud, ArrayList list, float typeNumber, float timeSpan, bool isSpawned, int spawnedNumber) {
		if ((Time.timeSinceLevelLoad % timeSpan < deadband || Time.timeSinceLevelLoad % timeSpan > timeSpan - deadband)) {
			if (!isSpawned) {
				spawnCloud (cloud, list, typeNumber);
				if (typeNumber.Equals (-1F)) {
					redSpawned = true;
					redAmountSpawned++;
				} else if (typeNumber.Equals (0F)) {
					tealSpawned = true;
					tealAmountSpawned++;
				} else {
					purpleSpawned = true;
					purpleAmountSpawned++;
				}
			}
		} else {
			if (typeNumber.Equals (-1F)) {
				redSpawned = false;
			} else if (typeNumber.Equals (0F)) {
				tealSpawned = false;
			} else {
				purpleSpawned = false;
			}
		}
	}

	void processRed () {
		
		if (redAmountSpawned < redSpawnNumber) {
			cloudSpawnTimer (redCloud, redClouds, -1F, redSpawnTimer, redSpawned, redAmountSpawned);
		}

		checkForNullEntries (redClouds, -1F);
		try {
		((GameObject)redClouds [0]).GetComponent <CloudBall> ().setActivated (true);
		} catch (System.Exception) {

		}
	}

	void processTeal () {

		if (tealAmountSpawned < tealSpawnNumber) {
			cloudSpawnTimer (tealCloud, tealClouds, 0F, tealSpawnTimer, tealSpawned, tealAmountSpawned);
		}

		checkForNullEntries (tealClouds, 0F);
		try {
		((GameObject)tealClouds [0]).GetComponent <CloudBall> ().setActivated (true);
		} catch (System.Exception e) {

		}
	}

	void processPurple () {

		if (purpleAmountSpawned < purpleSpawnNumber) {
			cloudSpawnTimer (purpleCloud, purpleClouds, 1F, purpleSpawnTimer, purpleSpawned, purpleAmountSpawned);
		}

		checkForNullEntries (purpleClouds, 1F);
		try {
		((GameObject)purpleClouds [0]).GetComponent <CloudBall> ().setActivated (true);
		} catch (System.Exception e) {

		}
	}

	// Use this for initialization
	void Start () {
		redSpawned = false;
		tealSpawned = false;
		purpleSpawned = false;

		redClouds = new ArrayList();
		tealClouds = new ArrayList();
		purpleClouds = new ArrayList();

		redAmountSpawned = 0;
		tealAmountSpawned = 0;
		purpleAmountSpawned = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0F) {
			if (!turnOffRed) {
				processRed ();
			}
			if (!turnOffTeal) {
				processTeal ();
			}
			if (!turnOffPurple) {
				processPurple ();
			}
		}
	}
}

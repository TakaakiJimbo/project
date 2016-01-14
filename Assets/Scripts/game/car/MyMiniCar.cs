using UnityEngine;
using System.Collections;

public class MyMiniCar : MonoBehaviour {

	private Vector3 positionInScreen;
	private Vector3 startPosition;
	private Camera camera;
	private double margin = 1.5;

	void OnEnable() {
		camera = Camera.main;
		startPosition = gameObject.transform.position;
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(8, 13), 0, 0);
	}

	void Update() {
		if(isOutOfScreen()) {
			gameObject.SetActive(false);
		}
	}

	bool isOutOfScreen() {
		positionInScreen = camera.WorldToViewportPoint(transform.position);
		if(positionInScreen.x >= margin) {
			gameObject.transform.position = startPosition;
			return true;
		}
		else {
			return false;
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheckPoint : MonoBehaviour {
	MyLevelControl levelControl;

	void Start() {
		iTween.ColorTo(gameObject.transform.root.gameObject, iTween.Hash("a", 0, "looptype", "pingpong", "time", 1f));
		levelControl = GameObject.Find("GameControl").GetComponent<MyLevelControl>();
	}

	// layer 10 is "Cartriger"
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == 10) {
			levelControl.levelup();
			gameObject.SetActiveRecursively(false);
		}
	}
}
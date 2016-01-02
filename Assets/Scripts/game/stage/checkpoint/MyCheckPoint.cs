using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheckPoint : MonoBehaviour {
	MyLevelControl levelControl;

	void Start () {
		iTween.ColorTo(gameObject.transform.root.gameObject,iTween.Hash("a",0,"looptype","pingpong","time",1f));
		levelControl = GameObject.Find ("GameControl").GetComponent<MyLevelControl> ();
	}

	// layer 8 is "Car"
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 8) {
			GameObject carobject     = other.transform.root.gameObject;
			levelControl.levelup();
			Vector3    carposition   = carobject.transform.position;		
			gameObject.SetActiveRecursively(false);
		}
	}
}
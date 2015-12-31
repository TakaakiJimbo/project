using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheckPoint : MonoBehaviour {
	GameObject LevelControl;
	//[SerializeField, Range(1, 3)] private int      checkpointnumber;
	
	void Start () {
		iTween.ColorTo(gameObject.transform.root.gameObject,iTween.Hash("a",0,"looptype","pingpong","time",1f));
		LevelControl = GameObject.Find("LevelControl");
	}
	
	// layer 8 is "Car"
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 8) {
			GameObject carobject     = other.transform.root.gameObject;
			MyLevelControl levelControl = LevelControl.GetComponent<MyLevelControl> ();
			levelControl.levelup();
			//MyCarRank  carrank       = carobject.GetComponent<MyCarRank>();
			Vector3    carposition   = carobject.transform.position;		
			gameObject.SetActiveRecursively(false);
			//	markCheckPoint(checkpointnumber, carrank , carposition);
		}
	}
}
﻿using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] private int       lifepoint = 3;	//  if lifepoint  > 0, the car will be alive
	[SerializeField] private AudioClip diedsound;

	void Start() {
		reflectLifePoint();
	}

	void Update(){
		if( transform.position.y < -30){
			lifepoint = 0;
			changeLifePoint(0);
		}
		targetcamera.showNowScore((int)transform.position.z);
	}
	public void changeLifePoint(int changepoint) {
		if(!targetcamera.isResult()) {
			lifepoint += changepoint;
			if(!isAliveLifePoint()) {
				lifepoint = 0;
			//	gameObject.GetComponent<MyCarRank>().receiveRank(3, -1);	// finish mode, failed to goal
				Invoke("diedAnimation", 1);
				Invoke("Debugreturn", 3);
			}
			reflectLifePoint();
		}
	}

	private void Debugreturn(){
		Application.LoadLevel("Debug");
	}


	public int getLifePoint() {
		return lifepoint;
	}

	public bool isAliveLifePoint() {
		return lifepoint > 0;
	}

	private void reflectLifePoint() {
		targetcamera.showLifePoint(lifepoint);
	}
	
	private void diedAnimation() {
		gameObject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameObject.GetComponent<Detonator>().Explode();
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y  ", 0, "z", 0, "time", 0.0f));
		AudioSource.PlayClipAtPoint (diedsound, gameObject.transform.position);
	}
}
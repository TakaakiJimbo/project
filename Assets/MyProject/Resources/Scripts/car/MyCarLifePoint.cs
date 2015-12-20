using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] private int       lifepoint = 2;	//  if lifepoint  > 0, the car will be alive
	[SerializeField] private AudioClip diedsound;

	void Start() {
	
	}

	void Update(){
		if( transform.position.y < -20){
			lifepoint = 0;
			Invoke("diedAnimation", 0.5f);
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
			}
			//reflectLifePoint();
		}
	}

	public int getLifePoint() {
		return lifepoint;
	}

	public bool isAliveLifePoint() {
		return lifepoint > 0;
	}
	
	private  void diedAnimation() {
		gameObject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameObject.GetComponent<Detonator>().Explode();
		if (transform.position.y > -20) {
			iTween.ScaleTo (gameObject, iTween.Hash ("x", 0, "y  ", 0, "z", 0, "time", 0.0f));
		} else {
			gameObject.SetActiveRecursively(false);
		}
		AudioSource.PlayClipAtPoint (diedsound, gameObject.transform.position);
		Invoke("Debugreturn",2);
	}

		private void Debugreturn(){
		Application.LoadLevel("Debug");
	}
}
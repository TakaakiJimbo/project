using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] private int       lifepoint = 2;	//  if lifepoint  > 0, the car will be alive
	[SerializeField] private AudioClip diedsound;
	[SerializeField] private AudioClip fallsound;

	private bool isDead = false;

	// not good
	void Update(){
		if(transform.position.y < -20 && !isDead){
			changeLifePoint ((-1)*lifepoint);
		}
		targetcamera.showNowScore((int)transform.position.z);
	}

	public void changeLifePoint(int changepoint) {
		if(!targetcamera.isResult()) {
			lifepoint += changepoint;
			if(!isAliveLifePoint() && !isDead) {
				isDead = true;
				Invoke("diedAnimation", 1);
			}
		}
	}

	public int getLifePoint() {
		return lifepoint;
	}

	public bool isAliveLifePoint() {
		return lifepoint > 0;
	}
	
	private  void diedAnimation() {
		AudioSource audiosource = gameObject.GetComponent<AudioSource> ();
		GameObject.Find ("GameControl").GetComponent<MyTimeControl> ().enabled = false;
		gameObject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		if (transform.position.y < -20) {
			audiosource.PlayOneShot (fallsound);
			iTween.ScaleTo (gameObject, iTween.Hash ("x", 0, "y  ", 0, "z", 0, "time", 1.0f));
		}
		else {
			gameObject.GetComponent<Detonator>().Explode();
			audiosource.PlayOneShot (diedsound);
			iTween.ScaleTo (gameObject, iTween.Hash ("x", 0, "y  ", 0, "z", 0, "time", 0.0f));
		}
		GameObject.Find("Canvas").transform.FindChild("Retry").gameObject.SetActive(true); 
		GameObject.Find("Canvas").transform.FindChild("Title").gameObject.SetActive(true); 
	}
}
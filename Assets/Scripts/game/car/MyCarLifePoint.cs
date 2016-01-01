using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] private int       lifepoint = 2;	//  if lifepoint  > 0, the car will be alive
	[SerializeField] private AudioClip diedsound;
	[SerializeField] private AudioClip fallsound;

	private bool isDead = false;

	void Start() {
		GameObject.Find("Canvas").transform.FindChild("Retry").gameObject.SetActive(false); 
		GameObject.Find("Canvas").transform.FindChild("Title").gameObject.SetActive(false); 
		if(PlayerPrefs.HasKey("Highscore")){
			PlayerPrefs.SetInt("HighScore", 0); 
		}
		Debug.Log (PlayerPrefs.GetInt("HighScore"));
		targetcamera.showHighScore(PlayerPrefs.GetInt("HighScore"));
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
		gameObject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		if (transform.position.y > 0) {
			gameObject.GetComponent<Detonator>().Explode();
			audiosource.PlayOneShot (diedsound);
			iTween.ScaleTo (gameObject, iTween.Hash ("x", 0, "y  ", 0, "z", 0, "time", 0.0f));
		}
		else {
			audiosource.PlayOneShot (fallsound);
			Invoke("fallDestroy",2);
		}
		if (PlayerPrefs.GetInt("HighScore") < (int)transform.position.z) {
			PlayerPrefs.SetInt ("HighScore", (int)transform.position.z);
		}
		targetcamera.showHighScore(PlayerPrefs.GetInt("HighScore"));
		GameObject.Find("Canvas").transform.FindChild("Retry").gameObject.SetActive(true); 
		GameObject.Find("Canvas").transform.FindChild("Title").gameObject.SetActive(true); 
	}

	private void fallDestroy(){
		Destroy(gameObject);
	}
}
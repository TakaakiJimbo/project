using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] private int       lifepoint = 2;	//  if lifepoint  > 0, the car will be alive
	[SerializeField] private AudioClip diedsound;
	[SerializeField] private AudioClip fallsound;
	int[] scoreArray = new int[10];

	private bool isDead = false;

	void Start () {
		//reflectLifePoint ();
		Debug.Log (PlayerPrefs.GetInt("Result1",0));
		targetcamera.showHighScore(PlayerPrefs.GetInt("Result1",0));
		for (int i = 0; i < 10; i++) {
			scoreArray[i] = PlayerPrefs.GetInt("Result" + (i + 1), 0);
		}
	}

	// not good
	void Update(){
		if(transform.position.y < -1){
			GameObject.Find("Canvas").transform.FindChild("Stop").gameObject.SetActive(false);
		}
		if(transform.position.y < -20 && !isDead){
			changeLifePoint ((-1)*lifepoint);
		}
		targetcamera.showNowScore((int)transform.position.z);
	}

	public void changeLifePoint(int changepoint) {
		if(!targetcamera.isResult()) {
			lifepoint += changepoint;
		//	reflectLifePoint ();
			if(!isAliveLifePoint() && !isDead) {
				isDead = true;
				GameObject.Find("Canvas").transform.FindChild("Stop").gameObject.SetActive(false);
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
	/*
	private void reflectLifePoint() {
		targetcamera.showLifePoint(lifepoint);
	}
	*/
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

	public void checkScore(){
		int nowScore = (int)transform.position.z;
		int tmp = 0;
		for (int i = 0; i < 10; i++) {
			if (scoreArray[i] < nowScore) {
				if (i != 9) {
					for (int j = 9; j > i; j--) {
						scoreArray [j] = scoreArray [j - 1];
					}
				}
				scoreArray[i] = (int)nowScore;
				break;
			}
		}
		for(int i = 0; i < 10 ;i++){
			PlayerPrefs.SetInt ("Result" + (i + 1), scoreArray[i]);
			Debug.Log ("scoreArray[" +i + "]:" + scoreArray[i]);
		}
		targetcamera.showHighScore (PlayerPrefs.GetInt ("Result1"));
	}

}
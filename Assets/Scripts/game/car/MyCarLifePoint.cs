using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] private int       lifepoint = 2;	//  if lifepoint  > 0, the car will be alive
	[SerializeField] private AudioClip diedsound;
	[SerializeField] private AudioClip diedsound2;
	GameObject TimeControl;

	void Start() {
		TimeControl = GameObject.Find("GameControl");
		GameObject.Find("Canvas").transform.FindChild("Retry").gameObject.SetActive(false); 
		GameObject.Find("Canvas").transform.FindChild("Title").gameObject.SetActive(false); 
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
			AudioSource.PlayClipAtPoint (diedsound, gameObject.transform.position);
		} else {
			gameObject.SetActiveRecursively(false);
			AudioSource.PlayClipAtPoint (diedsound2, gameObject.transform.position);
		}
		/*
			GUI.color = new Color(1f,1f,1f,0.3f);
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),blackTex);
			GUI.color = new Color(1,1,1,1);
		*/

		Invoke("Debugreturn",2);
	}
		private void Debugreturn(){
		MyTimeControl timeControl = TimeControl.GetComponent<MyTimeControl> ();
		timeControl.enableReflectCount(false);
		GameObject.Find("Canvas").transform.FindChild("Retry").gameObject.SetActive(true); 
		GameObject.Find("Canvas").transform.FindChild("Title").gameObject.SetActive(true); 
		//Application.LoadLevel("Debug");
	}
}
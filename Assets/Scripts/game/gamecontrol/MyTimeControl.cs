using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MyTimeControl : MyGameControl {

	private GameObject[]   carplayerobjects;
	private GameObject[]   cameraobjects;
	private int            limittime     = 3;
	private TimeSpan       pastTime;
	private DateTime       startTime;
	private List<MyCamera> carcameras    = new List<MyCamera> ();
	private bool           countdownflag = true; 
	private float firstInterval = 2.0f;
	static public float interval; 
	[SerializeField]  private GameObject PlayerCar;
	[SerializeField]  private GameObject Enemy;
	[SerializeField]  private GameObject Barieer;
	[SerializeField]  private  AudioClip countdown;
	[SerializeField]  private  AudioClip endinvisible;

	protected override void initialize() {
		carplayerobjects = GameObject.FindGameObjectsWithTag ("Player");
		cameraobjects    = GameObject.FindGameObjectsWithTag ("Camera");
		foreach(GameObject cameraobject in cameraobjects) {
			carcameras.Add(cameraobject.GetComponent<MyCamera>());
		}
		foreach(GameObject carobject in carplayerobjects) {
			carobject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		}
	}

	void Start () {
		startTime = DateTime.Now;
		enableReflectCount(false);
		interval = firstInterval;
		gameObject.GetComponent<AudioSource>().PlayOneShot(countdown);
	}
	
	void Update () {
		pastTime = DateTime.Now - startTime;
		if(Time.timeScale !=0 && PlayerCar){
			reflectCount(pastTime.Minutes, pastTime.Seconds, pastTime.Milliseconds);
		}
		if(countdownflag) {
			int time = limittime - pastTime.Seconds;
			if(time > 0) {
				reflectCountDown(limittime - pastTime.Seconds);
			}
			else if(time == 0) {
				countdownflag = false;
				reflectCountDown(limittime - pastTime.Seconds);
				timeStart();
				GameObject.Find("Canvas").transform.FindChild("Stop").gameObject.SetActive(true); 
				StartCoroutine("SpawnEnemy");
				//StartCoroutine("ProhibitStop");
				removeCarKinematic();
				StartCoroutine(enableReflectCountDown(1, false));
			}
		}
	}

	public void enableReflectCount(bool flag) {
		foreach(MyCamera carcamera in carcameras) {
			carcamera.enabledCount(flag);
		}
	}

	private IEnumerator enableReflectCountDown(float delay, bool flag) {
		yield return new WaitForSeconds(delay);
		foreach(MyCamera carcamera in carcameras) {
			carcamera.enabledCountDown(flag);
		}
	}

	private void reflectCountDown(int second) {
		foreach(MyCamera carcamera in carcameras) {
			carcamera.showCountDown(second);
		}
	}

	private void reflectCount(int minutes, int seconds, int milliseconds) {
		foreach(MyCamera carcamera in carcameras) {
		carcamera.showNowCount(minutes, seconds, milliseconds);
		}
	}
	
	private void removeCarKinematic() {
		foreach(GameObject carobject in carplayerobjects) {
			carobject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = true;
		}
	}

	private void timeStart() {
		enableReflectCount(true);
		startTime = DateTime.Now;
	}
	
	IEnumerator SpawnEnemy() {
		while (true) {
			 GameObject obj = (GameObject)Instantiate(Enemy, new Vector3 (UnityEngine.Random.Range (-20f, 20f), 3.5f, 
			                                 UnityEngine.Random.Range (PlayerCar.transform.position.z + 40f, PlayerCar.transform.position.z + 50f))
			             					 ,Quaternion.identity);
			obj.transform.parent = transform;
			 if(MyLevelControl.level < 3){
				Destroy(obj , 10);
			}else{
				Destroy(obj , 5);
			}
				Resources.UnloadUnusedAssets();
			yield return new WaitForSeconds (interval);
			if (PlayerCar == null)
				break;
		}
			SpawnStop();
	}

	public void SpawnStop () {
		StopCoroutine("SpawnEnemy");
	}
	
	static public void ShortInterval () {
		interval = interval * 0.9f;
	}

	public void getItem(){
		Invoke ("endEnable",2f );
	}

	public void invisibleItem(){
		Barieer.SetActiveRecursively(true);
		Invoke ("endInvisible",15f );
	}

	private void endEnable(){
		MyItem.itemFlag = true;
	}

	private void endInvisible(){
		MyItem.itemFlag = true;
		gameObject.GetComponent<AudioSource>().PlayOneShot(endinvisible);
		Barieer.SetActiveRecursively(false);
	}
}

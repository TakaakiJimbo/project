using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControrl : MonoBehaviour {

	private AudioSource sound01;

	void Start () {
		sound01 = GetComponent<AudioSource>();
	}

	void Retry(){
		Application.LoadLevel ("Ready");
	}

	void BackTitle(){
		Application.LoadLevel ("main");
	}

	public void OnClick (int number){

		switch (number) {

		case 0:
			sound01.PlayOneShot(sound01.clip);
			Invoke("Retry",0.5f);
			break;

		case 1:
			sound01.PlayOneShot(sound01.clip);
			Invoke("BackTitle",0.5f);
			break;

		default:
			break;
		}

	}
}
	

/*
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControrl : MyCar {

	private AudioSource sound01;
	//GameObject TimeControl;
	public GameObject PlayerCar;

	void Start () {
		//TimeControl = GameObject.Find("GameControl");
		sound01 = GetComponent<AudioSource>();
		/*
		gameObject.transform.FindChild("Retry").gameObject.SetActive(false); 
		gameObject.transform.FindChild("Title").gameObject.SetActive(false); 
		if(PlayerPrefs.HasKey("Highscore")){
			PlayerPrefs.SetInt("HighScore", 0); 
		}
		Debug.Log (PlayerPrefs.GetInt("HighScore"));
		targetcamera.showHighScore(PlayerPrefs.GetInt("HighScore"));

}

void Retry(){
	Application.LoadLevel ("debug");
}

void BackTitle(){
	Application.LoadLevel ("main");
}


	void StopGame(){
		MyTimeControl timeControl = TimeControl.GetComponent<MyTimeControl> ();
		timeControl.enableReflectCount(false);
		if (PlayerPrefs.GetInt("HighScore") < (int)PlayerCar.transform.position.z) {
			PlayerPrefs.SetInt ("HighScore", (int)PlayerCar.transform.position.z);
		}
		Debug.Log (PlayerPrefs.GetInt("HighScore"));
		targetcamera.showHighScore(PlayerPrefs.GetInt("HighScore"));
		gameObject.transform.FindChild("Retry").gameObject.SetActive(true); 
		gameObject.transform.FindChild("Title").gameObject.SetActive(true); 
	}

public void OnClick (int number){

	switch (number) {
	case 0:
		sound01.PlayOneShot(sound01.clip);
		Invoke("Retry",0.5f);
		break;

	case 1:
		sound01.PlayOneShot(sound01.clip);
		Invoke("BackTitle",0.5f);
		break;

	default:
		//		sound01.PlayOneShot(sound01.clip);
		//		Invoke("StopGame", 2.0f);
		break;
	}
}
}
*/
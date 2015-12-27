using UnityEngine;
using System.Collections;

public class MyLevelControl : MonoBehaviour {

	public MyCamera targetcamera;
	public static int level;
	public int firstlevel = 1;
	public AudioClip checkedsound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip =  checkedsound;
		//debug only
		level = firstlevel;
		if(firstlevel > 1){
			for(int i = 1; i <= firstlevel; i++){
				MyTimeControl.ShortInterval();
			}
			targetcamera.showNowLevel(level);
		}
	}

	public void levelup(){
		level++;
		audioSource.Play();
		MyTimeControl.ShortInterval();
		targetcamera.showNowLevel(level);
	}
}

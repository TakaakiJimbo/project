using UnityEngine;
using System.Collections;

public class MyLevelControl : MonoBehaviour {

	public MyCamera targetcamera;
	public static int level;
	public int firstlevel = 1;

	// Use this for initialization
	void Start () {
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
		MyTimeControl.ShortInterval();
		targetcamera.showNowLevel(level);
	}
}

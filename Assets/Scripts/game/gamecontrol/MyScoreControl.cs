using UnityEngine;
using System.Collections;

public class MyScoreControl : MyCar  {

	int[] scoreArray = new int[10];
	[SerializeField]  private GameObject PlayerCar;

	void Start () {
		Debug.Log (PlayerPrefs.GetInt("Result1",0));
		targetcamera.showHighScore(PlayerPrefs.GetInt("Result1",0));
		for (int i = 0; i < 10; i++) {
			scoreArray[i] = PlayerPrefs.GetInt("Result" + (i + 1), 0);
		}
	}

	public void checkScore(){
		int nowScore = (int)PlayerCar.transform.position.z;
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
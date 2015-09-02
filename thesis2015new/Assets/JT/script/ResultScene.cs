using UnityEngine;
using System.Collections;
using UnityEngine.UI;  

public class ResultScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int WinPlayer = ButtonA.playerNum;	
		Debug.Log(WinPlayer);
		winP(WinPlayer);
	}



public void winP(int number){
	
	switch (number) {
	case 0:
			this.GetComponent<Text>().text = "PLAYER 1・2 WIN!";
		break;
		
	case 1:
			this.GetComponent<Text>().text = "PLAYER 3・4 WIN!";
		break;
		
	default:
		break;
		}
	}

}
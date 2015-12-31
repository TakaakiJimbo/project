﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyCamera : MonoBehaviour {

	private Text timecounter;
	private Text level;
	private Text score;
	private RawImage rank;
	private RawImage startcount;
	private RawImage result;
	private bool  resultflag;
	private Color fadeincolor = new Color(0,0,0,1);	
	private Color fadeoutolor = new Color(0,0,0,0);
	private Color diedcolor   = new Color(0,0,0,0.3f);	

	// Use this for initialization
	void Awake () {
		timecounter = gameObject.FindDeep("TimeCounter").gameObject.GetComponent<Text>(); 
		level       = gameObject.FindDeep("Level").gameObject.GetComponent<Text>();
		score   	= gameObject.FindDeep("Score").gameObject.GetComponent<Text>();
		startcount  = gameObject.FindDeep("StartCount").gameObject.GetComponent<RawImage>();
		result      = gameObject.FindDeep("Result").gameObject.GetComponent<RawImage>();
//		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		enabledResult(false);
	}
/*
	public void enabledStartGoalIcon(bool flag) {
		starticon.enabled   = flag;
		goalicon.enabled    = flag;
	}
*/
	public void enabledCount(bool flag) {
		timecounter.enabled = flag;
	}

	public void enabledCountDown(bool flag) {
		startcount.enabled = flag ;
	}
/*
	private void enabledRank(bool flag) {
		rank.enabled = flag;
	}
*/
	private void enabledResult(bool flag) {
		resultflag     = flag;
		result.enabled = flag;
	}
	/*
	public void enabledReverse(bool flag) {
		reverse.enabled = flag;
	}
	*/
	private void fadeDied() {
		gameObject.FindDeep("MainCamera").GetComponent<CameraFade>().StartFade(diedcolor, 5);
	}
	
	public void fadeIn(){
		gameObject.FindDeep("MainCamera").GetComponent<CameraFade>().StartFade(fadeincolor, 1);
	}
	
	public void fadeOut(){
		gameObject.FindDeep("MainCamera").GetComponent<CameraFade>().StartFade(fadeoutolor, 1);
	}

	public bool isResult() {
		return resultflag;
	}

	public void showCountDown(int count) {
		startcount.texture = Resources.Load<Texture> ("count/" + count);
	}

	 public void showNowLevel(int nowLevel) {
		if (!isResult()) {
			level.text = "LEVEL:" + nowLevel.ToString();
		}
	}
	
	public void showNowCount(int minutes, int seconds, int milliseconds) {
		if (!isResult()) {
			timecounter.text = minutes.ToString().PadLeft (2, '0') + ':' + seconds.ToString().PadLeft (2, '0') + ':' + milliseconds.ToString().PadLeft (3, '0');
		}
	}

	public void showNowScore(int nowScore) {
		if (!isResult()) {
			score.text = "SCORE:" + nowScore.ToString() + '\n'+ (Profiler.usedHeapSize / 1048576).ToString() + "/" + (SystemInfo.systemMemorySize).ToString() + " MB";;
		
		}
	}
}
